using System;
using TiendaApp.Models;
using TiendaApp.Services;

namespace TiendaApp.Views
{
    public class UsuarioView
    {
        private readonly UsuarioService _usuarioService;

        public UsuarioView(UsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        public void MostrarMenuUsuarios()
        {
            bool salir = false;
            
            while (!salir)
            {
                Console.Clear();
                Console.WriteLine("=== GESTIÓN DE USUARIOS ===");
                Console.WriteLine("1. Ver lista de usuarios");
                Console.WriteLine("2. Nuevo usuario");
                Console.WriteLine("3. Editar información de usuario");
                Console.WriteLine("4. Volver al menú principal");
                Console.Write("Seleccione una opción: ");
                
                switch (Console.ReadLine())
                {
                    case "1":
                        ListarUsuarios();
                        break;
                    case "2":
                        CrearUsuario();
                        break;
                    case "3":
                        EditarUsuario();
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

        private void ListarUsuarios()
        {
            Console.Clear();
            Console.WriteLine("=== LISTA DE USUARIOS ===");
            
            var usuarios = _usuarioService.ObtenerTodos();

            if (usuarios.Count == 0)
            {
                Console.WriteLine("No hay usuarios registrados.");
            }
            else
            {
                foreach (var usuario in usuarios)
                {
                    Console.WriteLine(usuario);
                    Console.WriteLine($"Tel: {usuario.Telefono}, Dir: {usuario.Direccion}");
                    Console.WriteLine("----------------------------------");
                }
            }
            
            Console.ReadKey();
        }

        private void CrearUsuario()
        {
            Console.Clear();
            Console.WriteLine("=== NUEVO USUARIO ===");
            
            try
            {
                var usuario = new Usuario();
                
                Console.Write("Identificación: ");
                usuario.Identificacion = Console.ReadLine();
                
                Console.Write("Nombres: ");
                usuario.Nombres = Console.ReadLine();
                
                Console.Write("Apellidos: ");
                usuario.Apellidos = Console.ReadLine();
                
                Console.Write("Teléfono: ");
                usuario.Telefono = Console.ReadLine();
                
                Console.Write("Dirección: ");
                usuario.Direccion = Console.ReadLine();
                
                _usuarioService.Crear(usuario);
                Console.WriteLine("\nUsuario creado exitosamente!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nError: {ex.Message}");
            }
            
            Console.ReadKey();
        }

        private void EditarUsuario()
        {
            Console.Clear();
            Console.WriteLine("=== EDITAR USUARIO ===");
            
            Console.Write("Ingrese la identificación del usuario a editar: ");
            string id = Console.ReadLine();
            
            var usuario = _usuarioService.BuscarPorId(id);
            
            if (usuario == null)
            {
                Console.WriteLine("Usuario no encontrado.");
                Console.ReadKey();
                return;
            }
            
            Console.WriteLine("\nSeleccione el dato a editar:");
            Console.WriteLine("1. Nombres");
            Console.WriteLine("2. Apellidos");
            Console.WriteLine("3. Teléfono");
            Console.WriteLine("4. Dirección");
            Console.Write("Opción: ");
            
            var opcion = Console.ReadLine();
            var usuarioActualizado = new Usuario { Identificacion = usuario.Identificacion };
            
            switch (opcion)
            {
                case "1":
                    Console.Write("Nuevos nombres: ");
                    usuarioActualizado.Nombres = Console.ReadLine();
                    usuarioActualizado.Apellidos = usuario.Apellidos;
                    usuarioActualizado.Telefono = usuario.Telefono;
                    usuarioActualizado.Direccion = usuario.Direccion;
                    break;
                case "2":
                    Console.Write("Nuevos apellidos: ");
                    usuarioActualizado.Apellidos = Console.ReadLine();
                    usuarioActualizado.Nombres = usuario.Nombres;
                    usuarioActualizado.Telefono = usuario.Telefono;
                    usuarioActualizado.Direccion = usuario.Direccion;
                    break;
                case "3":
                    Console.Write("Nuevo teléfono: ");
                    usuarioActualizado.Telefono = Console.ReadLine();
                    usuarioActualizado.Nombres = usuario.Nombres;
                    usuarioActualizado.Apellidos = usuario.Apellidos;
                    usuarioActualizado.Direccion = usuario.Direccion;
                    break;
                case "4":
                    Console.Write("Nueva dirección: ");
                    usuarioActualizado.Direccion = Console.ReadLine();
                    usuarioActualizado.Nombres = usuario.Nombres;
                    usuarioActualizado.Apellidos = usuario.Apellidos;
                    usuarioActualizado.Telefono = usuario.Telefono;
                    break;
                default:
                    Console.WriteLine("Opción no válida");
                    Console.ReadKey();
                    return;
            }
            
            try
            {
                _usuarioService.Actualizar(usuarioActualizado);
                Console.WriteLine("\nUsuario actualizado exitosamente!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nError: {ex.Message}");
            }
            
            Console.ReadKey();
        }
    }
}