using System;
using System.Collections.Generic;

public class Article
{
    private List<string> nombresArticulos = new List<string>();
    private List<string> preciosArticulos = new List<string>();

    public Article()
    {
        Console.WriteLine("=== INGRESO INICIAL DE 5 ARTÍCULOS ===");
        for (int i = 0; i < 5; i++)
        {
            Console.Write($"Ingrese el nombre del artículo {i + 1}: ");
            nombresArticulos.Add(Console.ReadLine());
            Console.Write($"Ingrese el precio del artículo {i + 1}: ");
            preciosArticulos.Add(Console.ReadLine());
        }
    }

    public void ManageArticles()
    {
        bool salir = false;

        while (!salir)
        {
            Console.WriteLine("\n=== MENÚ DE GESTIÓN DE ARTÍCULOS ===");
            Console.WriteLine("1. Ver lista de artículos");
            Console.WriteLine("2. Nuevo artículo");
            Console.WriteLine("3. Editar información del artículo");
            Console.WriteLine("4. Salir de Gestión de Artículos");
            Console.Write("Seleccione una opción: ");
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    VerListaArticulos();
                    break;

                case "2":
                    NuevoArticulo();
                    break;

                case "3":
                    EditarArticulo();
                    break;

                case "4":
                    salir = true;
                    Console.WriteLine("Saliendo del módulo de Gestión de Artículos...");
                    break;

                default:
                    Console.WriteLine("Ingrese una opción del menú válida.");
                    break;
            }
        }
    }

    private void VerListaArticulos()
    {
        while (true)
        {
            Console.WriteLine("\n=== LISTA DE ARTÍCULOS ===");

            for (int i = 0; i < nombresArticulos.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {nombresArticulos[i]}");
            }

            Console.Write($"Seleccione un artículo (1 al {nombresArticulos.Count}) o 0 para volver: ");
            string entrada = Console.ReadLine();

            if (int.TryParse(entrada, out int opcion) &&
                opcion >= 0 && opcion <= nombresArticulos.Count)
            {
                if (opcion == 0) return;

                Console.WriteLine($"\nArtículo {opcion}:");
                Console.WriteLine($"Nombre: {nombresArticulos[opcion - 1]}");
                Console.WriteLine($"Precio: {preciosArticulos[opcion - 1]}\n");
            }
            else
            {
                Console.WriteLine("Ingrese una opción del menú válida.");
            }
        }
    }

    private void NuevoArticulo()
    {
        while (true)
        {
            Console.WriteLine("\n=== MENÚ NUEVO ARTÍCULO ===");
            Console.WriteLine("1. Crear Artículo");
            Console.WriteLine("2. Salir");
            Console.Write("Seleccione una opción: ");
            string entrada = Console.ReadLine();

            if (entrada == "1")
            {
                Console.Write("Nombre del nuevo artículo: ");
                nombresArticulos.Add(Console.ReadLine());
                Console.Write("Precio del nuevo artículo: ");
                preciosArticulos.Add(Console.ReadLine());

                Console.WriteLine("¡Artículo agregado exitosamente!");
            }
            else if (entrada == "2")
            {
                return;
            }
            else
            {
                Console.WriteLine("Ingrese una opción del menú válida.");
            }
        }
    }

    private void EditarArticulo()
    {
        while (true)
        {
            Console.WriteLine("\n=== EDITAR INFORMACIÓN DEL ARTÍCULO ===");

            for (int i = 0; i < nombresArticulos.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {nombresArticulos[i]}");
            }

            Console.Write($"Seleccione un artículo (1 al {nombresArticulos.Count}) o 0 para volver: ");
            string entrada = Console.ReadLine();

            if (int.TryParse(entrada, out int opcion) &&
                opcion >= 0 && opcion <= nombresArticulos.Count)
            {
                if (opcion == 0) return;

                Console.Write($"Nuevo precio para {nombresArticulos[opcion - 1]}: ");
                preciosArticulos[opcion - 1] = Console.ReadLine();

                Console.WriteLine("¡Precio actualizado con éxito!");
            }
            else
            {
                Console.WriteLine("Ingrese una opción del menú válida.");
            }
        }
    }
}
