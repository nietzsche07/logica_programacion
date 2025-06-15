using System;
using System.Collections.Generic;
using TiendaApp.Models;
using TiendaApp.Services;

namespace TiendaApp.Views
{
    public class VentaView
    {
        private readonly VentaService _ventaService;
        private readonly UsuarioService _usuarioService;
        private readonly ArticuloService _articuloService;

        public VentaView(VentaService ventaService, UsuarioService usuarioService, ArticuloService articuloService)
        {
            _ventaService = ventaService;
            _usuarioService = usuarioService;
            _articuloService = articuloService;
        }

        public void MostrarMenuVentas()
        {
            bool salir = false;
            
            while (!salir)
            {
                Console.Clear();
                Console.WriteLine("=== GESTIÓN DE VENTAS ===");
                Console.WriteLine("1. Generar factura");
                Console.WriteLine("2. Volver al menú principal");
                Console.Write("Seleccione una opción: ");
                
                switch (Console.ReadLine())
                {
                    case "1":
                        GenerarFactura();
                        break;
                    case "2":
                        salir = true;
                        break;
                    default:
                        Console.WriteLine("Opción no válida");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private void GenerarFactura()
        {
            Console.Clear();
            Console.WriteLine("=== GENERAR FACTURA ===");
            
            // Buscar usuario
            Console.Write("Ingrese identificación del comprador: ");
            string idUsuario = Console.ReadLine();
            
            var comprador = _usuarioService.BuscarPorId(idUsuario);
            if (comprador == null)
            {
                Console.WriteLine("Usuario no encontrado.");
                Console.ReadKey();
                return;
            }
            
            // Seleccionar productos
            var detalles = new List<DetalleVenta>();
            bool continuar = true;
            
            while (continuar && detalles.Count < 10)
            {
                Console.WriteLine("\n=== SELECCIONAR PRODUCTO ===");
                Console.Write("Ingrese ID del producto (0 para terminar): ");
                if (!int.TryParse(Console.ReadLine(), out int idArticulo))
                {
                    Console.WriteLine("ID inválido.");
                    continue;
                }
                
                if (idArticulo == 0)
                {
                    continuar = false;
                    break;
                }
                
                var articulo = _articuloService.BuscarPorId(idArticulo);
                if (articulo == null)
                {
                    Console.WriteLine("Artículo no encontrado.");
                    continue;
                }
                
                Console.WriteLine($"Artículo: {articulo.Nombre}");
                Console.WriteLine($"Stock: {articulo.CantidadStock}, Valor: {articulo.ValorUnitario:C}");
                
                Console.Write("Cantidad a comprar: ");
                if (!int.TryParse(Console.ReadLine(), out int cantidad) || cantidad <= 0)
                {
                    Console.WriteLine("Cantidad inválida.");
                    continue;
                }
                
                try
                {
                    _articuloService.ReducirStock(articulo.Id, cantidad);
                    
                    detalles.Add(new DetalleVenta
                    {
                        Producto = articulo,
                        Cantidad = cantidad,
                        Subtotal = articulo.ValorUnitario * cantidad
                    });
                    
                    Console.WriteLine("Producto agregado a la factura.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
            
            if (detalles.Count == 0)
            {
                Console.WriteLine("No se agregaron productos a la factura.");
                Console.ReadKey();
                return;
            }
            
            // Generar factura
            try
            {
                var venta = _ventaService.CrearVenta(comprador, detalles);
                MostrarFactura(venta);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al generar factura: {ex.Message}");
            }
            
            Console.ReadKey();
        }

        private void MostrarFactura(Venta venta)
        {
            Console.Clear();
            Console.WriteLine("=== FACTURA ===");
            Console.WriteLine($"Fecha: {venta.Fecha}");
            Console.WriteLine($"Cliente: {venta.Comprador.Nombres} {venta.Comprador.Apellidos}");
            Console.WriteLine($"Identificación: {venta.Comprador.Identificacion}");
            Console.WriteLine("----------------------------------");
            Console.WriteLine("PRODUCTOS:");
            
            foreach (var detalle in venta.Detalles)
            {
                Console.WriteLine($"{detalle.Producto.Nombre}");
                Console.WriteLine($"  Cantidad: {detalle.Cantidad}");
                Console.WriteLine($"  Valor unitario: {detalle.Producto.ValorUnitario:C}");
                Console.WriteLine($"  Subtotal: {detalle.Subtotal:C}");
                Console.WriteLine("----------------------------------");
            }
            
            Console.WriteLine($"TOTAL A PAGAR: {venta.Total:C}");
            Console.WriteLine("\nFactura generada exitosamente!");
        }
    }
}