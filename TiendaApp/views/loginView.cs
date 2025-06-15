using TiendaApp.Services;

namespace TiendaApp.Views
{
    public class LoginView
    {
        private readonly AuthService _authService;

        public LoginView(AuthService authService)
        {
            _authService = authService;
        }

        public bool Mostrar()
        {
            System.Console.Clear();
            System.Console.WriteLine("=== INICIO DE SESIÓN ===");
            System.Console.Write("Usuario: ");
            string usuario = System.Console.ReadLine();
            System.Console.Write("Contraseña: ");
            string contraseña = System.Console.ReadLine();

            bool autenticado = _authService.Autenticar(usuario, contraseña);
            
            if (!autenticado)
            {
                System.Console.WriteLine("\nCredenciales incorrectas. Intente nuevamente.");
                System.Console.ReadKey();
            }
            
            return autenticado;
        }
    }
}