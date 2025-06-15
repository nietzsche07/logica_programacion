using System.Collections.Generic;
using TiendaApp.Models;

namespace TiendaApp.Services
{
    public class VentaService
    {
        private List<Venta> _ventas = new List<Venta>();
        private const int MaxProductosPorVenta = 10;

        public Venta CrearVenta(Usuario comprador, List<DetalleVenta> detalles)
        {
            if (detalles.Count > MaxProductosPorVenta)
                throw new System.Exception($"No se pueden agregar más de {MaxProductosPorVenta} productos por venta.");
                
            var venta = new Venta
            {
                Comprador = comprador,
                Detalles = detalles,
                Total = detalles.Sum(d => d.Subtotal)
            };
            
            _ventas.Add(venta);
            return venta;
        }
    }
}