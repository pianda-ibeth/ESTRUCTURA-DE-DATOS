using System;
using System.Collections.Generic;

class Ejercicio10
{
    public static void Run()
    {
        List<int> prices = new List<int>
        { 50, 75, 46, 22, 80, 65, 8 };

        int min = prices[0];
        int max = prices[0];

        foreach (int price in prices)
        {
            if (price < min)
                min = price;
            else if (price > max)
                max = price;
        }

        Console.WriteLine("El mínimo es " + min);
        Console.WriteLine("El máximo es " + max);
    }
}
