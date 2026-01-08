using System;
using System.Collections.Generic;

class Ejercicio5
{
    public static void Run()
    {
        List<int> numbers = new List<int>
        { 1,2,3,4,5,6,7,8,9,10 };

        for (int i = numbers.Count - 1; i >= 0; i--)
        {
            Console.Write(numbers[i] + ", ");
        }
        Console.WriteLine();
    }
}
