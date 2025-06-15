namespace TiendaApp.Services
{
    public class AuthService
    {
        public bool Autenticar(string usuario, string contraseña)
        {
            // Credenciales por defecto
            return usuario == "admin" && contraseña == "admin123";
        }
    }
}