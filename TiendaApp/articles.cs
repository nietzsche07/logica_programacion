
public class Article
{
    private string articulo1, articulo2, articulo3, articulo4, articulo5;
    private string precio1, precio2, precio3, precio4, precio5;
    private int id1 = 1, id2 = 2, id3 = 3, id4 = 4, id5 = 5;
    private int totalArticulos = 0;
    
    public bool ManageArticles()
    {
        bool salir = false;
        while (!salir)
        {
            Console.WriteLine("\n=== GESTIÓN DE ARTICULOS ===");
            Console.WriteLine("1. Ver lista de articulos");
            Console.WriteLine("2. Agregar nuevo articulo");
            Console.WriteLine("3. Editar información de articulo (buscar por id)");
            Console.WriteLine("4. Salir de Gestión de articulos (Menú principal)");
            Console.Write("Seleccione una opción: ");
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1": 
                    MostrarArticulos();
                    break;

                case "2": 
                    AgregarNuevoArticulo();
                    break;

                case "3": 
                    EditarArticulo();
                    break;

                case "4": 
                    salir = true;
                    Console.WriteLine("Volviendo al menú principal...");
                    return true;

                default:
                    Console.WriteLine("Opción inválida.");
                    break;
            }
        }
        
        return false;
    }
    
    private void MostrarArticulos()
    {
        Console.WriteLine("\n=== LISTA DE ARTICULOS ===");
        
        if (totalArticulos == 0)
        {
            Console.WriteLine("No hay articulos registrados.");
            return;
        }
        
        if (!string.IsNullOrEmpty(articulo1))
            Console.WriteLine($"{precio1} - {articulo1} - {id1}");
            
        if (!string.IsNullOrEmpty(articulo2))
            Console.WriteLine($"{precio2} - {articulo2} - {id2}");
            
        if (!string.IsNullOrEmpty(articulo3))
            Console.WriteLine($"{precio3} - {articulo3}- {id3}");
            
        if (!string.IsNullOrEmpty(articulo4))
            Console.WriteLine($"{precio4} - {articulo4}- {id4}");
            
        if (!string.IsNullOrEmpty(articulo5))
            Console.WriteLine($"{precio5} - {articulo5}- {id5}");
    }
    
    private void AgregarNuevoArticulo()
    {
        if (totalArticulos >= 5)
        {
            Console.WriteLine("\n¡Lo sentimos! Solo se permiten 5 articulos.");
            Console.WriteLine("Debe editar un usuario existente en su lugar.");
            return;
        }
        
        totalArticulos++;
        
        switch (totalArticulos)
        {
            case 1:
                Console.WriteLine("\n=== AGREGAR ARTICULO 1 ===");
                Console.WriteLine($"ID del artículo: {id1} (asignado automáticamente)");
                Console.Write("Nombre articulo 1: ");
                articulo1 = Console.ReadLine();
                Console.Write("Precio articulo 1: ");
                precio1 = Console.ReadLine();
                break;
                
            case 2:
                 Console.WriteLine("\n=== AGREGAR ARTICULO 2 ===");
                 Console.WriteLine($"ID del artículo: {id2} (asignado automáticamente)");
                Console.Write("Nombre articulo 2: ");
                articulo2 = Console.ReadLine();
                Console.Write("Precio articulo 2: ");
                precio2 = Console.ReadLine();
                break;
                
            case 3:
                Console.WriteLine("\n=== AGREGAR ARTICULO 3 ===");
                Console.WriteLine($"ID del artículo: {id3} (asignado automáticamente)");
                Console.Write("Nombre articulo 3: ");
                articulo3 = Console.ReadLine();
                Console.Write("Precio articulo 3: ");
                precio3 = Console.ReadLine();
                break;
                
            case 4:
                Console.WriteLine("\n=== AGREGAR ARTICULO 4 ===");
                Console.WriteLine($"ID del artículo: {id4} (asignado automáticamente)");
                Console.Write("Nombre articulo 4: ");
                articulo4 = Console.ReadLine();
                Console.Write("Precio articulo 4: ");
                precio4 = Console.ReadLine();
                break;
                
            case 5:
                Console.WriteLine("\n=== AGREGAR ARTICULO 5 ===");
                Console.WriteLine($"ID del artículo: {id5} (asignado automáticamente)");
                Console.Write("Nombre articulo 5: ");
                articulo5 = Console.ReadLine();
                Console.Write("Precio articulo 5: ");
                precio5 = Console.ReadLine();
                break;
        }
        
        Console.WriteLine("\n¡Articulo agregado con éxito!");
    }

    private void EditarArticulo()
    {
        if (totalArticulos == 0)
        {
            Console.WriteLine("\nNo hay articulos registrados para editar.");
            return;
        }

        Console.Write("\nIngrese el id a buscar: ");
        string idBuscar = Console.ReadLine();
        bool encontrado = false;

        if (id1.ToString() == idBuscar)
        {
            Console.WriteLine($"\nArticulo encontrado: {articulo1}  {precio1} ({id1})");
            Console.Write("Nuevo nombre: ");
            articulo1 = Console.ReadLine();
            Console.Write("Nueva precio: ");
            precio1 = Console.ReadLine();
            encontrado = true;
        }
        else if (id2.ToString() == idBuscar)
        {
            Console.WriteLine($"\nArticulo encontrado: {articulo2} {precio2} ({id2})");
            Console.Write("Nuevo nombre: ");
            articulo2 = Console.ReadLine();
            Console.Write("Nueva precio: ");
            precio2 = Console.ReadLine();
            encontrado = true;
        }
        else if (id3.ToString() == idBuscar)
        {
            Console.WriteLine($"\nArticulo encontrado: {articulo3} {precio3} ({id3})");
            Console.Write("Nuevo nombre: ");
            articulo3 = Console.ReadLine();
            Console.Write("Nueva precio: ");
            precio3 = Console.ReadLine();
            encontrado = true;
        }
        else if (id4.ToString() == idBuscar)
        {
            Console.WriteLine($"\nArticulo encontrado: {articulo4} {precio4} ({id4})");
            Console.Write("Nuevo nombre: ");
            articulo4 = Console.ReadLine();
            Console.Write("Nueva precio: ");
            precio4 = Console.ReadLine();
            encontrado = true;
        }
        else if (id5.ToString() == idBuscar)
        {
            Console.WriteLine($"\nArticulo encontrado: {articulo5} {precio5} ({id5})");
            Console.Write("Nuevo nombre: ");
            articulo5 = Console.ReadLine();
            Console.Write("Nueva precio: ");
            precio5 = Console.ReadLine();
            encontrado = true;
        }

        if (!encontrado)
            Console.WriteLine("Articulo no encontrado.");
        else
            Console.WriteLine("Articulo actualizado con éxito!");
    }
}