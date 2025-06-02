public class Login
{
    public bool LoginUser()
    {
        string[] credencialesPorDefecto = new string[2];
        credencialesPorDefecto[0] = "admin";
        credencialesPorDefecto[1] = "admin123"; 
        
        string usuario;
        string password;

        Console.WriteLine("=== SISTEMA DE GESTIÓN DE TIENDA ===");

        while (true)
        {
            Console.Write("Ingrese usuario: ");
            usuario = Console.ReadLine();

            Console.Write("Ingrese contraseña: ");
            password = Console.ReadLine();

            if (usuario == credencialesPorDefecto[0] && password == credencialesPorDefecto[1])
            {
                Console.WriteLine("\n¡Bienvenido!");
                Console.WriteLine("Accediendo al Menú Principal...\n");
                return true;
            }
            else
            {
                Console.WriteLine("\nError de autenticación: Usuario o contraseña incorrectos.");
                Console.WriteLine("Intente de nuevo.\n");
            }
        }
    }
}