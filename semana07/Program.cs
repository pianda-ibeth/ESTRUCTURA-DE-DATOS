using System;

namespace Semana7
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== EJERCICIO 1: PARÉNTESIS BALANCEADOS ===\n");
            BalanceoExpresion.Ejecutar();

            Console.WriteLine("\n=== EJERCICIO 2: TORRES DE HANOI ===\n");
            TorresDeHanoi.Ejecutar();

            Console.ReadKey();
        }
    }
}
