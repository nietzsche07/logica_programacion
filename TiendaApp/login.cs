public class Login
{
    public bool LoginUser()
    {
        Console.WriteLine("=== SISTEMA DE GESTIÓN DE TIENDA ===");
        Console.Write("Ingrese usuario: ");
        string usuario = Console.ReadLine();
        Console.Write("Ingrese contraseña: ");
        string password = Console.ReadLine();
        if (usuario == "admin" && password == "admin123")
        {
              Console.WriteLine("\n¡Inicio de sesión exitoso!");
            return true;
        }else
        {
            Console.WriteLine("\nUsuario o contraseña incorrectos.");
            return false;
        }
    }
}