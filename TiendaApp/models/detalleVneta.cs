namespace TiendaApp.Models
{
    public class DetalleVenta
    {
        public Articulo Producto { get; set; }
        public int Cantidad { get; set; }
        public decimal Subtotal { get; set; }
    }
}