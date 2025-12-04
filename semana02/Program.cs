using System;

class Program
{
    static void Main(string[] args)
    {
        // Prueba del círculo
        Circulo c = new Circulo(4);
        Console.WriteLine("==== Círculo ====");
        Console.WriteLine("Área: " + c.CalcularArea());
        Console.WriteLine("Perímetro: " + c.CalcularPerimetro());

        // Prueba del rectángulo
        Rectangulo r = new Rectangulo(5, 3);
        Console.WriteLine("\n==== Rectángulo ====");
        Console.WriteLine("Área: " + r.CalcularArea());
        Console.WriteLine("Perímetro: " + r.CalcularPerimetro());
    }
}
