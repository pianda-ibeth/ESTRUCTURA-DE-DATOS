using System;
using System.Collections.Generic;

class Ejercicio4
{
    public static void Run()
    {
        List<int> awarded = new List<int>();

        for (int i = 0; i < 6; i++)
        {
            Console.Write("Introduce un número ganador: ");
            awarded.Add(int.Parse(Console.ReadLine()));
        }

        awarded.Sort();
        Console.WriteLine("Los números ganadores son: " +
            string.Join(", ", awarded));
    }
}
