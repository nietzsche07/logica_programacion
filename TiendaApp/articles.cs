using System;

public class Article
{
    private string[,] matrizArticulos = new string[2, 5];
    private string[,] matrizNuevosArticulos = new string[2, 5];
    private int contadorNuevosArticulos = 0;

    public Article()
    {
        Console.WriteLine("\n==== BIENVENIDOS AL MODULO DE ARTÍCULOS ===");
        Console.WriteLine("=== INGRESO INICIAL DE 5 ARTÍCULOS ===");
        
        for (int i = 0; i < 5; i++)
        {
            Console.Write($"Ingrese el nombre del artículo {i + 1}: ");
            matrizArticulos[0, i] = Console.ReadLine();
            Console.Write($"Ingrese el valor unitario del artículo {i + 1}: ");
            matrizArticulos[1, i] = Console.ReadLine();
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
            Console.WriteLine("3. Editar información del artículo (buscar por id)");
            Console.WriteLine("4. Salir de Gestión de Artículos (Menú Principal)");
            
            string opcion;
            bool opcionValida = false;
            
            while (!opcionValida)
            {
                Console.Write("Seleccione una opción: ");
                opcion = Console.ReadLine();
                
                switch (opcion)
                {
                    case "1":
                        VerListaArticulos();
                        opcionValida = true;
                        break;
                    case "2":
                        NuevoArticulo();
                        opcionValida = true;
                        break;
                    case "3":
                        EditarArticulo();
                        opcionValida = true;
                        break;
                    case "4":
                        salir = true;
                        opcionValida = true;
                        Console.WriteLine("Regresando al Menú Principal...");
                        break;
                    default:
                        Console.WriteLine("Ingrese una opción del menú válida");
                        break;
                }
            }
        }
    }

    private void VerListaArticulos()
    {
        bool salir = false;
        
        while (!salir)
        {
            Console.WriteLine("\nLista de Artículos:");
            
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"{i + 1}. {matrizArticulos[0, i]}");
            }
            
            string opcion;
            bool opcionValida = false;
            
            while (!opcionValida)
            {
                Console.Write("Seleccione una opción (1-5) o 0 para volver: ");
                opcion = Console.ReadLine();
                
                if (opcion == "0")
                {
                    salir = true;
                    opcionValida = true;
                }
                else if (opcion == "1" || opcion == "2" || opcion == "3" || opcion == "4" || opcion == "5")
                {
                    int indice = int.Parse(opcion) - 1;
                    Console.WriteLine($"\nInformación del artículo {opcion}:");
                    Console.WriteLine($"Nombre: {matrizArticulos[0, indice]}");
                    Console.WriteLine($"Valor unitario: {matrizArticulos[1, indice]}\n");
                    opcionValida = true;
                }
                else
                {
                    Console.WriteLine("Ingrese una opción del menú válida");
                }
            }
        }
    }

    private void NuevoArticulo()
    {
        bool salir = false;
        
        while (!salir)
        {
            Console.WriteLine("\n=== MENÚ NUEVO ARTÍCULO ===");
            Console.WriteLine("1. Crear nuevo artículo");
            Console.WriteLine("2. Salir");
            
            string opcion;
            bool opcionValida = false;
            
            while (!opcionValida)
            {
                Console.Write("Seleccione una opción: ");
                opcion = Console.ReadLine();
                
                switch (opcion)
                {
                    case "1":
                        if (contadorNuevosArticulos < 5)
                        {
                            Console.Write("Nombre del nuevo artículo: ");
                            matrizNuevosArticulos[0, contadorNuevosArticulos] = Console.ReadLine();
                            Console.Write("Valor unitario del nuevo artículo: ");
                            matrizNuevosArticulos[1, contadorNuevosArticulos] = Console.ReadLine();
                            contadorNuevosArticulos++;
                            Console.WriteLine("¡Artículo agregado exitosamente!");
                            
                            if (contadorNuevosArticulos == 5)
                            {
                                Console.WriteLine("Se ha alcanzado el límite máximo de 5 nuevos artículos.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("No se pueden crear más artículos. Límite alcanzado (5 artículos).");
                        }
                        opcionValida = true;
                        break;
                        
                    case "2":
                        salir = true;
                        opcionValida = true;
                        break;
                        
                    default:
                        Console.WriteLine("Ingrese una opción del menú válida");
                        break;
                }
            }
        }
    }

    private void EditarArticulo()
    {
        Console.WriteLine("\n=== EDITAR INFORMACIÓN DEL ARTÍCULO ===");
        Console.Write("Ingrese el nombre del artículo a buscar: ");
        string nombreArticuloIngresado = Console.ReadLine();
        
        bool articuloEncontrado = false;
        
        for (int i = 0; i < 5; i++)
        {
            if (matrizArticulos[0, i] == nombreArticuloIngresado)
            {
                Console.WriteLine("Artículo encontrado");
                Console.WriteLine($"Nombre: {matrizArticulos[0, i]}");
                Console.WriteLine($"Valor unitario: {matrizArticulos[1, i]}");
                
                Console.Write("Ingrese el nuevo valor unitario: ");
                matrizArticulos[1, i] = Console.ReadLine();
                Console.WriteLine("¡Artículo actualizado con éxito!");
                
                articuloEncontrado = true;
                break;
            }
        }
        
        if (!articuloEncontrado)
        {
            Console.WriteLine("Artículo no encontrado");
        }
    }
}