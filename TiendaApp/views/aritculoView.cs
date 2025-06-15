using System;
using TiendaApp.Models;
using TiendaApp.Services;

namespace TiendaApp.Views
{
    public class ArticuloView
    {
        private readonly ArticuloService _articuloService;

        public ArticuloView(ArticuloService articuloService)
        {
            _articuloService = articuloService;
        }

        public void MostrarMenuArticulos()
        {
            bool salir = false;
            
            while (!salir)
            {
                Console.Clear();
                Console.WriteLine("=== GESTIÓN DE ARTÍCULOS ===");
                Console.WriteLine("1. Ver lista de artículos");
                Console.WriteLine("2. Nuevo artículo");
                Console.WriteLine("3. Editar información de artículo");
                Console.WriteLine("4. Volver al menú principal");
                Console.Write("Seleccione una opción: ");
                
                switch (Console.ReadLine())
                {
                    case "1":
                        ListarArticulos();
                        break;
                    case "2":
                        CrearArticulo();
                        break;
                    case "3":
                        EditarArticulo();
                        break;
                    case "4":
                        salir = true;
                        break;
                    default:
                        Console.WriteLine("Opción no válida");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private void ListarArticulos()
        {
            Console.Clear();
            Console.WriteLine("=== LISTA DE ARTÍCULOS ===");
            
            var articulos = _articuloService.ObtenerTodos();
            
            if (articulos.Count == 0)
            {
                Console.WriteLine("No hay artículos registrados.");
            }
            else
            {
                foreach (var articulo in articulos)
                {
                    Console.WriteLine(articulo);
                    Console.WriteLine("----------------------------------");
                }
            }
            
            Console.ReadKey();
        }

        private void CrearArticulo()
        {
            Console.Clear();
            Console.WriteLine("=== NUEVO ARTÍCULO ===");
            
            try
            {
                var articulo = new Articulo();
                
                Console.Write("Nombre: ");
                articulo.Nombre = Console.ReadLine();
                
                Console.Write("Valor unitario: ");
                if (!decimal.TryParse(Console.ReadLine(), out decimal valor) || valor <= 0)
                {
                    Console.WriteLine("Valor inválido. Debe ser un número positivo.");
                    Console.ReadKey();
                    return;
                }
                articulo.ValorUnitario = valor;
                
                Console.Write("Cantidad en stock: ");
                if (!int.TryParse(Console.ReadLine(), out int cantidad) || cantidad < 0)
                {
                    Console.WriteLine("Cantidad inválida. Debe ser un número entero positivo.");
                    Console.ReadKey();
                    return;
                }
                articulo.CantidadStock = cantidad;
                
                _articuloService.Crear(articulo);
                Console.WriteLine("\nArtículo creado exitosamente!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nError: {ex.Message}");
            }
            
            Console.ReadKey();
        }

        private void EditarArticulo()
        {
            Console.Clear();
            Console.WriteLine("=== EDITAR ARTÍCULO ===");
            
            Console.Write("Ingrese el ID del artículo a editar: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("ID inválido.");
                Console.ReadKey();
                return;
            }
            
            var articulo = _articuloService.BuscarPorId(id);
            
            if (articulo == null)
            {
                Console.WriteLine("Artículo no encontrado.");
                Console.ReadKey();
                return;
            }
            
            Console.WriteLine("\nSeleccione el dato a editar:");
            Console.WriteLine("1. Nombre");
            Console.WriteLine("2. Valor unitario");
            Console.WriteLine("3. Cantidad en stock");
            Console.Write("Opción: ");
            
            var opcion = Console.ReadLine();
            var articuloActualizado = new Articulo { Id = articulo.Id };
            
            switch (opcion)
            {
                case "1":
                    Console.Write("Nuevo nombre: ");
                    articuloActualizado.Nombre = Console.ReadLine();
                    articuloActualizado.ValorUnitario = articulo.ValorUnitario;
                    articuloActualizado.CantidadStock = articulo.CantidadStock;
                    break;
                case "2":
                    Console.Write("Nuevo valor unitario: ");
                    if (!decimal.TryParse(Console.ReadLine(), out decimal valor) || valor <= 0)
                    {
                        Console.WriteLine("Valor inválido.");
                        Console.ReadKey();
                        return;
                    }
                    articuloActualizado.ValorUnitario = valor;
                    articuloActualizado.Nombre = articulo.Nombre;
                    articuloActualizado.CantidadStock = articulo.CantidadStock;
                    break;
                case "3":
                    Console.Write("Nueva cantidad en stock: ");
                    if (!int.TryParse(Console.ReadLine(), out int cantidad) || cantidad < 0)
                    {
                        Console.WriteLine("Cantidad inválida.");
                        Console.ReadKey();
                        return;
                    }
                    articuloActualizado.CantidadStock = cantidad;
                    articuloActualizado.Nombre = articulo.Nombre;
                    articuloActualizado.ValorUnitario = articulo.ValorUnitario;
                    break;
                default:
                    Console.WriteLine("Opción no válida");
                    Console.ReadKey();
                    return;
            }
            
            try
            {
                _articuloService.Actualizar(articuloActualizado);
                Console.WriteLine("\nArtículo actualizado exitosamente!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nError: {ex.Message}");
            }
            
            Console.ReadKey();
        }
    }
}