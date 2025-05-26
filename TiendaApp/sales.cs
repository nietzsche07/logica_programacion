using System;

public class Sale
{
    private string[] nombresArticulos = new string[5];
    private int[] cantidadesDisponibles = new int[5];

    public Sale()
    {
        IngresarInformacionArticulos();
    }

    public void ManageVentas()
    {
        bool salir = false;

        while (!salir)
        {
            Console.WriteLine("\n=== MENÚ DE GESTIÓN DE VENTAS ===");
            Console.WriteLine("1. Registrar venta");
            Console.WriteLine("2. Salir de Gestión de venta");
            Console.Write("Seleccione una opción: ");
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    RegistrarVenta();
                    break;

                case "2":
                    salir = true;
                    Console.WriteLine("Saliendo del módulo de ventas...");
                    break;

                default:
                    Console.WriteLine("Ingrese una opción del menú válida.");
                    break;
            }
        }
    }

    private void IngresarInformacionArticulos()
    {
        Console.WriteLine("\n=== BIENVENIDO MODULO VENTAS ===");
        Console.WriteLine("=== INGRESO DE ARTÍCULOS PARA VENTA ===");
        for (int i = 0; i < 5; i++)
        {
            Console.Write($"Nombre del artículo {i + 1}: ");
            nombresArticulos[i] = Console.ReadLine();

            bool cantidadValida = false;
            while (!cantidadValida)
            {
                Console.Write($"Cantidad disponible de '{nombresArticulos[i]}': ");
                string entrada = Console.ReadLine();

                if (int.TryParse(entrada, out int cantidad) && cantidad >= 0)
                {
                    cantidadesDisponibles[i] = cantidad;
                    cantidadValida = true;
                }
                else
                {
                    Console.WriteLine("Ingrese un número entero positivo válido.");
                }
            }
        }
    }

    private void RegistrarVenta()
    {
        int productosVendidos = 0;

        while (productosVendidos < 5)
        {
            Console.WriteLine("\n=== LISTA DE ARTÍCULOS DISPONIBLES ===");
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"{i + 1}. {nombresArticulos[i]} (Disponible: {cantidadesDisponibles[i]})");
            }

            Console.Write("Seleccione un artículo (1 al 5): ");
            string opcion = Console.ReadLine();

            if (int.TryParse(opcion, out int seleccion) && seleccion >= 1 && seleccion <= 5)
            {
                int indice = seleccion - 1;
                Console.Write($"Ingrese la cantidad que desea comprar de '{nombresArticulos[indice]}': ");
                string entradaCantidad = Console.ReadLine();

                if (int.TryParse(entradaCantidad, out int cantidadCompra) && cantidadCompra > 0)
                {
                    if (cantidadCompra <= cantidadesDisponibles[indice])
                    {
                        cantidadesDisponibles[indice] -= cantidadCompra;
                        productosVendidos++;

                        Console.WriteLine($"Venta registrada: {cantidadCompra} unidades de '{nombresArticulos[indice]}'");
                        Console.WriteLine($"Productos vendidos hasta ahora: {productosVendidos}/5");

                        if (productosVendidos < 5)
                        {
                            Console.Write("¿Desea ingresar un nuevo producto? (s/n): ");
                            string continuar = Console.ReadLine().ToLower();

                            if (continuar != "s")
                            {
                                break;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Solo se permiten hasta 5 productos por venta.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No hay suficiente stock disponible.");
                    }
                }
                else
                {
                    Console.WriteLine("Ingrese una cantidad válida.");
                }
            }
            else
            {
                Console.WriteLine("Ingrese una opción del menú válida.");
            }
        }
    }
}
