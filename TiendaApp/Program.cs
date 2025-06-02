class Program
{
    static void Main(string[] args)
    {
        Login login = new Login();
        bool isLoggedIn = login.LoginUser();
        
        if (isLoggedIn)
        {
            bool continuar = true;
            while (continuar)
            {
                Console.WriteLine("\n=== BIENVENIDO AL MENÚ PRINCIPAL ===");
                Console.WriteLine("1. Gestión de usuarios");
                Console.WriteLine("2. Gestión de artículos");
                Console.WriteLine("3. Gestión de ventas");
                Console.WriteLine("4. Salir del programa");
                
                string opcion;
                bool opcionValida = false;
                
                while (!opcionValida)
                {
                    Console.Write("Seleccione una opción: ");
                    opcion = Console.ReadLine();
                    
                    switch (opcion)
                    {
                        case "1":
                            Console.WriteLine("\n¡Bienvenido al módulo Gestión de usuarios!");
                            opcionValida = true;
                            
                            User userManager = new User();
                            userManager.ManageUsers();
                            break;
                            
                        case "2":
                            Console.WriteLine("\n¡Bienvenido al módulo Gestión de artículos!");
                            opcionValida = true;
                            
                            Article articleManager = new Article();
                            articleManager.ManageArticles();
                            break;
                            
                        case "3":
                            Console.WriteLine("\n¡Bienvenido al módulo Gestión de ventas!");
                            opcionValida = true;
                            
                            Sale saleManager = new Sale();
                            saleManager.ManageVentas();
                            break;
                            
                        case "4":
                            Console.WriteLine("\nSe ha cerrado sesión en el programa.");
                            Console.WriteLine("Gracias por usar el sistema. ¡Hasta pronto!");
                            continuar = false;
                            opcionValida = true;
                            break;
                            
                        default:
                            Console.WriteLine("\nIngrese una opción del menú válida");
                            break;
                    }
                }
            }
        }
        else
        {
            Console.WriteLine("Demasiados intentos fallidos. El programa se cerrará.");
        }
    }
}