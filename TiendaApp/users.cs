using System;

public class User
{
    private string[,] matrizUsuarios = new string[2, 10];
    private int totalUsuarios = 0; 

    public User()
    {
        Console.WriteLine("\n=== BIENVENIDOS MODULO USUARIOS ===");
        
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine($"\n=== INGRESAR USUARIO {i + 1} ===");
            Console.Write("Número de cédula: ");
            matrizUsuarios[0, i] = Console.ReadLine(); 
            Console.Write("Nombre completo: ");
            matrizUsuarios[1, i] = Console.ReadLine(); 
        }
        totalUsuarios = 5; 
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
            
            string opcion;
            bool opcionValida = false;
            
            while (!opcionValida)
            {
                Console.Write("Seleccione una opción: ");
                opcion = Console.ReadLine();
                
                switch (opcion)
                {
                    case "1":
                        VerListaUsuarios();
                        opcionValida = true;
                        break;
                    case "2":
                        CrearUsuario();
                        opcionValida = true;
                        break;
                    case "3":
                        EditarUsuario();
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

    private void VerListaUsuarios()
    {
        bool salir = false;
        
        while (!salir)
        {
            Console.WriteLine($"\nLista de usuarios (Total: {totalUsuarios}):");
            
            for (int i = 0; i < totalUsuarios; i++)
            {
                Console.WriteLine($"{i + 1}. {matrizUsuarios[0, i]}");
            }
            
            if (totalUsuarios == 0)
            {
                Console.WriteLine("No hay usuarios registrados.");
                return;
            }
            
            string opcion;
            bool opcionValida = false;
            
            while (!opcionValida)
            {
                Console.Write($"Seleccione una opción (1-{totalUsuarios}) o 0 para volver: ");
                opcion = Console.ReadLine();
                
                if (opcion == "0")
                {
                    salir = true;
                    opcionValida = true;
                }
                else if (int.TryParse(opcion, out int numeroOpcion) && numeroOpcion >= 1 && numeroOpcion <= totalUsuarios)
                {
                    int indice = numeroOpcion - 1;
                    Console.WriteLine($"\nInformación del usuario {numeroOpcion}:");
                    Console.WriteLine($"Cédula: {matrizUsuarios[0, indice]}");
                    Console.WriteLine($"Nombre: {matrizUsuarios[1, indice]}\n");
                    opcionValida = true;
                }
                else
                {
                    Console.WriteLine("Ingrese una opción del menú válida");
                }
            }
        }
    }

    private void CrearUsuario()
    {
        bool salir = false;
        
        while (!salir)
        {
            Console.WriteLine("\n=== MENÚ NUEVO USUARIO ===");
            Console.WriteLine("1. Crear nuevo usuario");
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
                        if (totalUsuarios < 10) 
                        {
                            Console.Write("Número de cédula: ");
                            string nuevaCedula = Console.ReadLine();
                            
                            bool cedulaExiste = false;
                            for (int i = 0; i < totalUsuarios; i++)
                            {
                                if (matrizUsuarios[0, i] == nuevaCedula)
                                {
                                    cedulaExiste = true;
                                    break;
                                }
                            }
                            
                            if (cedulaExiste)
                            {
                                Console.WriteLine("Error: Ya existe un usuario con esa cédula.");
                            }
                            else
                            {
                                matrizUsuarios[0, totalUsuarios] = nuevaCedula;
                                Console.Write("Nombre completo: ");
                                matrizUsuarios[1, totalUsuarios] = Console.ReadLine();
                                totalUsuarios++;
                                Console.WriteLine("¡Nuevo usuario agregado exitosamente!");
                                
                                if (totalUsuarios == 10)
                                {
                                    Console.WriteLine("Se ha alcanzado el límite máximo de 10 usuarios.");
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("No se pueden crear más usuarios. Límite alcanzado (10 usuarios).");
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

    private void EditarUsuario()
    {
        Console.WriteLine("\n=== EDITAR INFORMACIÓN DE USUARIO ===");
        
        if (totalUsuarios == 0)
        {
            Console.WriteLine("No hay usuarios registrados para editar.");
            return;
        }
        
        Console.Write("Ingrese el número de cédula a buscar: ");
        string cedulaIngresada = Console.ReadLine();
        
        bool usuarioEncontrado = false;
        
        for (int i = 0; i < totalUsuarios; i++)
        {
            if (matrizUsuarios[0, i] == cedulaIngresada)
            {
                Console.WriteLine("Usuario encontrado");
                Console.WriteLine($"Cédula: {matrizUsuarios[0, i]}");
                Console.WriteLine($"Nombre: {matrizUsuarios[1, i]}");
                
                Console.Write("Ingrese el nuevo nombre: ");
                string nuevoNombre = Console.ReadLine();
                
                if (!string.IsNullOrWhiteSpace(nuevoNombre))
                {
                    matrizUsuarios[1, i] = nuevoNombre;
                    Console.WriteLine("¡Usuario actualizado con éxito!");
                }
                else
                {
                    Console.WriteLine("El nombre no puede estar vacío. No se realizaron cambios.");
                }
                
                usuarioEncontrado = true;
                break;
            }
        }
        
        if (!usuarioEncontrado)
        {
            Console.WriteLine("Usuario no encontrado");
        }
    }
}
