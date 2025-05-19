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
                Console.WriteLine("\n=== MENÚ PRINCIPAL ===");
                Console.WriteLine("1. Gestión de usuarios");
                Console.WriteLine("2. Gestión de artículos");
                Console.WriteLine("3. Gestión de ventas");
                Console.WriteLine("4. Salir del programa");
                Console.Write("Seleccione una opción: ");
                string opcion = Console.ReadLine();
                
                switch (opcion)
                {
                    case "1":
                        User userManager = new User();
                        userManager.ManageUsers();
                        break;
                        
                    case "2":
                        Article articleManager = new Article();
                        articleManager.ManageArticles();
                        break;
                        
                    case "3":
                        Sale saleManager = new Sale();
                        saleManager.ManageVentas();
                        break;
                        
                    case "4":
                        continuar = false;
                        Console.WriteLine("\nGracias por usar el sistema. ¡Hasta pronto!");
                        break;
                        
                    default:
                        Console.WriteLine("\nOpción inválida. Intente de nuevo.");
                        break;
                }
            }
        }
        else
        {
            Console.WriteLine("Demasiados intentos fallidos. El programa se cerrará.");
        }
    }
}