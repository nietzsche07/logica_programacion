namespace TiendaApp.Models
{
    public class Articulo
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal ValorUnitario { get; set; }
        public int CantidadStock { get; set; }
        
        public override string ToString()
        {
            return $"{Id} - {Nombre} (${ValorUnitario}) - Stock: {CantidadStock}";
        }
    }
}