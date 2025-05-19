public class Sale
{
    private string nombreArticulo;
    private int cantidadDisponible;
    
    public Sale()
    {
        nombreArticulo = "";
        cantidadDisponible = 0;
    }
    
    public bool ManageVentas()
    {
        IngresarInformacionArticulo();
        
        bool salir = false;
        while (!salir)
        {
            Console.WriteLine("\n=== GESTIÓN DE VENTAS ===");
            Console.WriteLine("1. Registrar venta");
            Console.WriteLine("2. Salir de Gestión de venta (Menú Principal)");
            Console.Write("Seleccione una opción: ");
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1": 
                    RegistrarVenta();
                    break;

                case "2": 
                    salir = true;
                    Console.WriteLine("Volviendo al menú principal...");
                    return true;

                default:
                    Console.WriteLine("Opción inválida. Por favor, seleccione 1 o 2.");
                    break;
            }
        }
        
        return false;
    }
    
    private void IngresarInformacionArticulo()
    {
        Console.WriteLine("\n=== INFORMACIÓN DEL ARTÍCULO ===");
        
        Console.Write("Ingrese el nombre del artículo: ");
        nombreArticulo = Console.ReadLine();
        
        bool cantidadValida = false;
        while (!cantidadValida)
        {
            Console.Write("Ingrese la cantidad de unidades disponibles: ");
            string cantidadStr = Console.ReadLine();
            
            if (int.TryParse(cantidadStr, out int cantidad) && cantidad >= 0)
            {
                cantidadDisponible = cantidad;
                cantidadValida = true;
            }
            else
            {
                Console.WriteLine("Error: Ingrese un número entero positivo válido.");
            }
        }
        
        Console.WriteLine($"\nArtículo '{nombreArticulo}' registrado con {cantidadDisponible} unidades disponibles.");
    }
    
    private void RegistrarVenta()
    {
        Console.WriteLine("\n=== REGISTRAR VENTA ===");
        Console.WriteLine($"Artículo seleccionado: {nombreArticulo}");
        Console.WriteLine($"Unidades disponibles: {cantidadDisponible}");
        
        bool cantidadValida = false;
        while (!cantidadValida)
        {
            Console.Write("Ingrese la cantidad de unidades a comprar: ");
            string cantidadStr = Console.ReadLine();
            
            if (int.TryParse(cantidadStr, out int cantidadCompra) && cantidadCompra > 0)
            {
                cantidadValida = true;
                
                if (cantidadCompra <= cantidadDisponible)
                {
                    cantidadDisponible -= cantidadCompra;
                    
                    Console.WriteLine("\n¡Usted puede comprar el artículo!");
                    Console.WriteLine($"Venta registrada: {cantidadCompra} unidades de '{nombreArticulo}'");
                    Console.WriteLine($"Unidades restantes: {cantidadDisponible}");
                }
                else
                {
                    Console.WriteLine("\nLo sentimos, no hay cantidad suficiente del artículo.");
                    Console.WriteLine($"Cantidad solicitada: {cantidadCompra}");
                    Console.WriteLine($"Cantidad disponible: {cantidadDisponible}");
                }
            }
            else
            {
                Console.WriteLine("Error: Ingrese un número entero positivo válido.");
            }
        }
    }
}