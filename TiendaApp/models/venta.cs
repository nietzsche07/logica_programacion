using System.Collections.Generic;

namespace TiendaApp.Models
{
    public class Venta
    {
        public Usuario Comprador { get; set; }
        public List<DetalleVenta> Detalles { get; set; } = new List<DetalleVenta>();
        public decimal Total { get; set; }
        public System.DateTime Fecha { get; set; } = System.DateTime.Now;
    }
}