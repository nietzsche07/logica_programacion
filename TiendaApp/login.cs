public class Login
{
    public bool LoginUser()
    {
        string usuarioPorDefecto = "admin";
        string passwordPorDefecto = "admin123";
        string usuario;
        string password;

        Console.WriteLine("=== SISTEMA DE GESTIÓN DE TIENDA ===");

        while (true)
        {
            Console.Write("Ingrese usuario: ");
            usuario = Console.ReadLine();

            Console.Write("Ingrese contraseña: ");
            password = Console.ReadLine();

            if (usuario == usuarioPorDefecto && password == passwordPorDefecto)
            {
                Console.WriteLine("\n¡Bienvenido!");
                return true;
            }
            else
            {
                Console.WriteLine("\nUsuario o contraseña incorrectos. Intente de nuevo.\n");
            }
        }
    }
}
