using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("EJERCICIOS – SEMANA05");
        Console.WriteLine("1. Ejercicio1");
        Console.WriteLine("4. Ejercicio4");
        Console.WriteLine("5. Ejercicio5");
        Console.WriteLine("8. Ejercicio8");
        Console.WriteLine("10. Ejercicio10");
        Console.WriteLine("0. Salir");

        Console.Write("Seleccione una opción: ");
        string opcion = Console.ReadLine();

        Console.WriteLine();

        switch (opcion)
        {
            case "1":
                Ejercicio1.Run();
                break;
            case "4":
                Ejercicio4.Run();
                break;
            case "5":
                Ejercicio5.Run();
                break;
            case "8":
                Ejercicio8.Run();
                break;
            case "10":
                Ejercicio10.Run();
                break;
            default:
                Console.WriteLine("Fin del programa.");
                break;
        }
    }
}
