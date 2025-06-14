namespace TiendaApp.Models
{
    public class Usuario
    {
        public string Identificacion { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        
        public override string ToString()
        {
            return $"{Identificacion} - {Nombres} {Apellidos}";
        }
    }
}