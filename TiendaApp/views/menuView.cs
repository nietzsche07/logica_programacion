using System;

namespace TiendaApp.Views
{
    public class MenuView
    {
        private readonly UsuarioView _usuarioView;
        private readonly ArticuloView _articuloView;
        private readonly VentaView _ventaView;

        public MenuView(UsuarioView usuarioView, ArticuloView articuloView, VentaView ventaView)
        {
            _usuarioView = usuarioView;
            _articuloView = articuloView;
            _ventaView = ventaView;
        }

        public void MostrarMenuPrincipal()
        {
            bool salir = false;
            
            while (!salir)
            {
                Console.Clear();
                Console.WriteLine("=== MENÚ PRINCIPAL ===");
                Console.WriteLine("1. Gestión de usuarios");
                Console.WriteLine("2. Gestión de artículos");
                Console.WriteLine("3. Gestión de ventas");
                Console.WriteLine("4. Salir del programa");
                Console.Write("Seleccione una opción: ");
                
                switch (Console.ReadLine())
                {
                    case "1":
                        _usuarioView.MostrarMenuUsuarios();
                        break;
                    case "2":
                        _articuloView.MostrarMenuArticulos();
                        break;
                    case "3":
                        _ventaView.MostrarMenuVentas();
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
    }
}