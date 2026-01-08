using System;

class Ejercicio8
{
    public static void Run()
    {
        Console.Write("Introduce una palabra: ");
        string word = Console.ReadLine();

        char[] original = word.ToCharArray();
        char[] reversed = word.ToCharArray();
        Array.Reverse(reversed);

        if (new string(original) == new string(reversed))
            Console.WriteLine("Es un palíndromo");
        else
            Console.WriteLine("No es un palíndromo");
    }
}
