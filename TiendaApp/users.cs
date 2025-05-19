
public class User
{
    private string nombre1, nombre2, nombre3, nombre4, nombre5;
    private string cedula1, cedula2, cedula3, cedula4, cedula5;
    private int totalUsuarios = 0;
    
    public bool ManageUsers()
    {
        // Menú de gestión de usuarios
        bool salir = false;
        while (!salir)
        {
            Console.WriteLine("\n=== GESTIÓN DE USUARIOS ===");
            Console.WriteLine("1. Ver lista de usuarios");
            Console.WriteLine("2. Agregar nuevo usuario");
            Console.WriteLine("3. Editar información de usuario (buscar por c.c)");
            Console.WriteLine("4. Salir de Gestión de usuarios (Menú principal)");
            Console.Write("Seleccione una opción: ");
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1": 
                    MostrarUsuarios();
                    break;

                case "2": 
                    AgregarNuevoUsuario();
                    break;

                case "3": 
                    EditarUsuario();
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
    
    private void MostrarUsuarios()
    {
        Console.WriteLine("\n=== LISTA DE USUARIOS ===");
        
        if (totalUsuarios == 0)
        {
            Console.WriteLine("No hay usuarios registrados.");
            return;
        }
        
        if (!string.IsNullOrEmpty(nombre1))
            Console.WriteLine($"{cedula1} - {nombre1}");
            
        if (!string.IsNullOrEmpty(nombre2))
            Console.WriteLine($"{cedula2} - {nombre2}");
            
        if (!string.IsNullOrEmpty(nombre3))
            Console.WriteLine($"{cedula3} - {nombre3}");
            
        if (!string.IsNullOrEmpty(nombre4))
            Console.WriteLine($"{cedula4} - {nombre4}");
            
        if (!string.IsNullOrEmpty(nombre5))
            Console.WriteLine($"{cedula5} - {nombre5}");
    }
    
    private void AgregarNuevoUsuario()
    {
        if (totalUsuarios >= 5)
        {
            Console.WriteLine("\n¡Lo sentimos! Solo se permiten 5 usuarios en esta versión.");
            Console.WriteLine("Debe editar un usuario existente en su lugar.");
            return;
        }
        
        totalUsuarios++;
        
        switch (totalUsuarios)
        {
            case 1:
                Console.WriteLine("\n=== AGREGAR USUARIO 1 ===");
                Console.Write("Nombre Usuario 1: ");
                nombre1 = Console.ReadLine();
                Console.Write("Cédula Usuario 1: ");
                cedula1 = Console.ReadLine();
                break;
                
            case 2:
                Console.WriteLine("\n=== AGREGAR USUARIO 2 ===");
                Console.Write("Nombre Usuario 2: ");
                nombre2 = Console.ReadLine();
                Console.Write("Cédula Usuario 2: ");
                cedula2 = Console.ReadLine();
                break;
                
            case 3:
                Console.WriteLine("\n=== AGREGAR USUARIO 3 ===");
                Console.Write("Nombre Usuario 3: ");
                nombre3 = Console.ReadLine();
                Console.Write("Cédula Usuario 3: ");
                cedula3 = Console.ReadLine();
                break;
                
            case 4:
                Console.WriteLine("\n=== AGREGAR USUARIO 4 ===");
                Console.Write("Nombre Usuario 4: ");
                nombre4 = Console.ReadLine();
                Console.Write("Cédula Usuario 4: ");
                cedula4 = Console.ReadLine();
                break;
                
            case 5:
                Console.WriteLine("\n=== AGREGAR USUARIO 5 ===");
                Console.Write("Nombre Usuario 5: ");
                nombre5 = Console.ReadLine();
                Console.Write("Cédula Usuario 5: ");
                cedula5 = Console.ReadLine();
                break;
        }
        
        Console.WriteLine("\n¡Usuario agregado con éxito!");
    }
    
    private void EditarUsuario()
    {
        if (totalUsuarios == 0)
        {
            Console.WriteLine("\nNo hay usuarios registrados para editar.");
            return;
        }
        
        Console.Write("\nIngrese la cédula a buscar: ");
        string cedulaBuscar = Console.ReadLine();
        bool encontrado = false;

        if (!string.IsNullOrEmpty(cedula1) && cedula1 == cedulaBuscar)
        {
            Console.WriteLine($"\nUsuario encontrado: {nombre1} ({cedula1})");
            Console.Write("Nuevo nombre: ");
            nombre1 = Console.ReadLine();
            Console.Write("Nueva cédula: ");
            cedula1 = Console.ReadLine();
            encontrado = true;
        }
        else if (!string.IsNullOrEmpty(cedula2) && cedula2 == cedulaBuscar)
        {
            Console.WriteLine($"\nUsuario encontrado: {nombre2} ({cedula2})");
            Console.Write("Nuevo nombre: ");
            nombre2 = Console.ReadLine();
            Console.Write("Nueva cédula: ");
            cedula2 = Console.ReadLine();
            encontrado = true;
        }
        else if (!string.IsNullOrEmpty(cedula3) && cedula3 == cedulaBuscar)
        {
            Console.WriteLine($"\nUsuario encontrado: {nombre3} ({cedula3})");
            Console.Write("Nuevo nombre: ");
            nombre3 = Console.ReadLine();
            Console.Write("Nueva cédula: ");
            cedula3 = Console.ReadLine();
            encontrado = true;
        }
        else if (!string.IsNullOrEmpty(cedula4) && cedula4 == cedulaBuscar)
        {
            Console.WriteLine($"\nUsuario encontrado: {nombre4} ({cedula4})");
            Console.Write("Nuevo nombre: ");
            nombre4 = Console.ReadLine();
            Console.Write("Nueva cédula: ");
            cedula4 = Console.ReadLine();
            encontrado = true;
        }
        else if (!string.IsNullOrEmpty(cedula5) && cedula5 == cedulaBuscar)
        {
            Console.WriteLine($"\nUsuario encontrado: {nombre5} ({cedula5})");
            Console.Write("Nuevo nombre: ");
            nombre5 = Console.ReadLine();
            Console.Write("Nueva cédula: ");
            cedula5 = Console.ReadLine();
            encontrado = true;
        }

        if (!encontrado)
            Console.WriteLine("Usuario no encontrado.");
        else
            Console.WriteLine("¡Usuario actualizado con éxito!");
    }
}