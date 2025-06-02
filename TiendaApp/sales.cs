using System;

public class Sale
{
    private string[,] articulosInfo = new string[2, 5];
    private string[,] ventaActual = new string[2, 5];
    private int articulosEnVenta = 0;

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
            articulosInfo[0, i] = Console.ReadLine();

            bool valorValido = false;
            while (!valorValido)
            {
                Console.Write($"Valor unitario de '{articulosInfo[0, i]}': ");
                string entrada = Console.ReadLine();

                if (double.TryParse(entrada, out double valor) && valor >= 0)
                {
                    articulosInfo[1, i] = valor.ToString(); 
                    valorValido = true;
                }
                else
                {
                    Console.WriteLine("Ingrese un valor numérico positivo válido.");
                }
            }
        }

        Console.WriteLine("\n=== INFORMACIÓN DE ARTÍCULOS REGISTRADA ===");
        Console.WriteLine("Artículo\t\tValor Unitario");
        Console.WriteLine("------------------------------------");
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine($"{articulosInfo[0, i]}\t\t${articulosInfo[1, i]}");
        }
    }

    private void RegistrarVenta()
    {
        LimpiarVentaActual();
        
        Console.WriteLine("\n=== REGISTRO DE VENTA ===");
        Console.Write("Ingrese el nombre del comprador: ");
        string nombreComprador = Console.ReadLine();
        
        Console.Write("Ingrese el número de cédula: ");
        string cedula = Console.ReadLine();

        bool continuarVenta = true;
        
        while (continuarVenta && articulosEnVenta < 5)
        {
            MostrarMenuArticulos();
            
            int opcionArticulo = SeleccionarArticulo();
            if (opcionArticulo != -1)
            {
                int cantidad = IngresarCantidad(opcionArticulo);
                if (cantidad > 0)
                {
                    AgregarArticuloAVenta(opcionArticulo, cantidad);
                    
                    if (articulosEnVenta < 5)
                    {
                        Console.Write("¿Desea agregar otro artículo a la venta? (s/n): ");
                        string respuesta = Console.ReadLine().ToLower();
                        continuarVenta = (respuesta == "s" || respuesta == "si");
                    }
                    else
                    {
                        Console.WriteLine("No se pueden registrar más artículos para la venta (máximo 5).");
                        continuarVenta = false;
                    }
                }
            }
        }

        if (articulosEnVenta > 0)
        {
            MostrarFactura(nombreComprador, cedula);
        }
        else
        {
            Console.WriteLine("No se registraron artículos en la venta.");
        }
    }

    private void MostrarMenuArticulos()
    {
        Console.WriteLine("\n=== LISTA DE ARTÍCULOS ===");
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine($"{i + 1}. {articulosInfo[0, i]} - ${articulosInfo[1, i]}");
        }
    }

    private int SeleccionarArticulo()
    {
        int opcion = -1;
        bool opcionValida = false;
        
        while (!opcionValida)
        {
            Console.Write("Seleccione un artículo (1-5): ");
            string entrada = Console.ReadLine();
            
            if (int.TryParse(entrada, out opcion) && opcion >= 1 && opcion <= 5)
            {
                opcionValida = true;
                return opcion - 1;
            }
            else
            {
                Console.WriteLine("Ingrese una opción del menú válida");
            }
        }
        
        return opcion;
    }

    private int IngresarCantidad(int indiceArticulo)
    {
        int cantidad = 0;
        bool cantidadValida = false;
        
        while (!cantidadValida)
        {
            Console.Write($"Ingrese la cantidad que desea comprar de '{articulosInfo[0, indiceArticulo]}': ");
            string entrada = Console.ReadLine();
            
            if (int.TryParse(entrada, out cantidad) && cantidad > 0)
            {
                cantidadValida = true;
            }
            else
            {
                Console.WriteLine("Ingrese una cantidad válida (número entero positivo).");
            }
        }
        
        return cantidad;
    }

    private void AgregarArticuloAVenta(int indiceArticulo, int cantidad)
    {
        if (articulosEnVenta < 5)
        {
            int posicionExistente = -1;
            for (int i = 0; i < articulosEnVenta; i++)
            {
                if (ventaActual[0, i] == articulosInfo[0, indiceArticulo])
                {
                    posicionExistente = i;
                    break;
                }
            }

            if (posicionExistente != -1)
            {
                double valorAnterior = double.Parse(ventaActual[1, posicionExistente]);
                double valorUnitario = double.Parse(articulosInfo[1, indiceArticulo]);
                double nuevoValor = valorAnterior + (cantidad * valorUnitario);
                ventaActual[1, posicionExistente] = nuevoValor.ToString();
                Console.WriteLine($"Cantidad actualizada para '{articulosInfo[0, indiceArticulo]}'");
            }
            else
            {
                ventaActual[0, articulosEnVenta] = articulosInfo[0, indiceArticulo];
                double valorUnitario = double.Parse(articulosInfo[1, indiceArticulo]);
                double subtotal = cantidad * valorUnitario;
                ventaActual[1, articulosEnVenta] = subtotal.ToString(); 
                articulosEnVenta++;
                Console.WriteLine($"Artículo agregado: {cantidad} x {articulosInfo[0, indiceArticulo]} = ${subtotal}");
            }
        }
    }

    private void MostrarFactura(string nombreComprador, string cedula)
    {
        Console.WriteLine("\n=== FACTURA DE VENTA ===");
        Console.WriteLine($"Cliente: {nombreComprador}");
        Console.WriteLine($"Cédula: {cedula}");
        Console.WriteLine("========================");
        Console.WriteLine("Producto\t\tSubtotal");
        Console.WriteLine("------------------------");
        
        double total = 0;
        
        for (int i = 0; i < articulosEnVenta; i++)
        {
            double subtotal = double.Parse(ventaActual[1, i]);
            Console.WriteLine($"{ventaActual[0, i]}\t\t${subtotal}");
            total += subtotal;
        }
        
        Console.WriteLine("------------------------");
        Console.WriteLine($"Total venta: ${total}");
        Console.WriteLine("========================");
    }

    private void LimpiarVentaActual()
    {
        for (int i = 0; i < 5; i++)
        {
            ventaActual[0, i] = null;
            ventaActual[1, i] = null;
        }
        articulosEnVenta = 0;
    }
}
