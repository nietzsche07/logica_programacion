using System;
using System.Collections.Generic;

public class User
{
    private List<string> nombres = new List<string>();
    private List<string> cedulas = new List<string>();

    public User()
    {
        Console.WriteLine($"\n=== BIENVENIDOS MODULO USUARIOS ===");
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine($"\n=== INGRESAR USUARIO {i + 1} ===");
            Console.Write("Nombre completo: ");
            nombres.Add(Console.ReadLine());
            Console.Write("Número de cédula: ");
            cedulas.Add(Console.ReadLine());
        }
    }

    public void ManageUsers()
    {
        bool salir = false;

        while (!salir)
        {
            Console.WriteLine("\n=== MENÚ DE GESTIÓN DE USUARIOS ===");
            Console.WriteLine("1. Ver lista de usuarios");
            Console.WriteLine("2. Nuevo usuario");
            Console.WriteLine("3. Editar información de usuario");
            Console.WriteLine("4. Salir de Gestión de usuarios");
            Console.Write("Seleccione una opción: ");
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    VerListaUsuarios();
                    break;
                case "2":
                    CrearUsuario();
                    break;
                case "3":
                    EditarUsuario();
                    break;
                case "4":
                    salir = true;
                    Console.WriteLine("Saliendo del módulo de Gestión de Usuarios...");
                    break;
                default:
                    Console.WriteLine("Ingrese una opción del menú válida.");
                    break;
            }
        }
    }

    private void VerListaUsuarios()
    {
        while (true)
        {
            Console.WriteLine("\n=== LISTA DE USUARIOS ===");
            for (int i = 0; i < cedulas.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {nombres[i]}");
            }

            Console.Write("Seleccione un número (1 al {0}) o 0 para volver: ", cedulas.Count);
            string input = Console.ReadLine();
            if (int.TryParse(input, out int seleccion) && seleccion >= 0 && seleccion <= cedulas.Count)
            {
                if (seleccion == 0) return;

                Console.WriteLine($"\nUsuario {seleccion}:");
                Console.WriteLine($"Nombre: {nombres[seleccion - 1]}");
                Console.WriteLine($"Cédula: {cedulas[seleccion - 1]}\n");
            }
            else
            {
                Console.WriteLine("Ingrese una opción del menú válida.");
            }
        }
    }

    private void CrearUsuario()
    {
        while (true)
        {
            Console.WriteLine("\n=== MENÚ NUEVO USUARIO ===");
            Console.WriteLine("1. Crear Usuario");
            Console.WriteLine("2. Salir");
            Console.Write("Seleccione una opción: ");
            string opcion = Console.ReadLine();

            if (opcion == "1")
            {
                Console.Write("Nombre del nuevo usuario: ");
                nombres.Add(Console.ReadLine());
                Console.Write("Cédula del nuevo usuario: ");
                cedulas.Add(Console.ReadLine());
                Console.WriteLine("¡Nuevo usuario agregado exitosamente!");
            }
            else if (opcion == "2")
            {
                return;
            }
            else
            {
                Console.WriteLine("Ingrese una opción del menú válida.");
            }
        }
    }

    private void EditarUsuario()
    {
        while (true)
        {
            Console.WriteLine("\n=== EDITAR USUARIO ===");
            for (int i = 0; i < cedulas.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {cedulas[i]}");
            }

            Console.Write("Seleccione un número (1 al {0}) o 0 para volver: ", cedulas.Count);
            string input = Console.ReadLine();

            if (int.TryParse(input, out int seleccion) && seleccion >= 0 && seleccion <= cedulas.Count)
            {
                if (seleccion == 0) return;

                Console.WriteLine($"\nEditando usuario {seleccion}:");
                Console.Write("Nuevo nombre: ");
                nombres[seleccion - 1] = Console.ReadLine();
                Console.Write("Nueva cédula: ");
                cedulas[seleccion - 1] = Console.ReadLine();
                Console.WriteLine("¡Usuario actualizado con éxito!");
            }
            else
            {
                Console.WriteLine("Ingrese una opción del menú válida.");
            }
        }
    }
}
