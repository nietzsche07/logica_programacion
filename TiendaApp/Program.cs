using TiendaApp.Services;
using TiendaApp.Views;

class Program
{
    static void Main()
    {
        // Inicializar servicios
        var authService = new AuthService();
        var usuarioService = new UsuarioService();
        var articuloService = new ArticuloService();
        var ventaService = new VentaService();
        
        // Inicializar vistas
        var loginView = new LoginView(authService);
        var usuarioView = new UsuarioView(usuarioService);
        var articuloView = new ArticuloView(articuloService);
        var ventaView = new VentaView(ventaService, usuarioService, articuloService);
        var menuView = new MenuView(usuarioView, articuloView, ventaView);
        
        // Lógica de autenticación
        bool autenticado = false;
        while (!autenticado)
        {
            autenticado = loginView.Mostrar();
        }
        
        // Mostrar menú principal
        menuView.MostrarMenuPrincipal();
    }
}