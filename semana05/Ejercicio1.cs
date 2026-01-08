using System;
using System.Collections.Generic;

class Ejercicio1
{
    public static void Run()
    {
        List<string> subjects = new List<string>
        {
            "Matemáticas", "Física", "Química", "Historia", "Lengua"
        };

        Console.WriteLine(string.Join(", ", subjects));
    }
}
