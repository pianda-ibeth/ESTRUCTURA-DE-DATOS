using System;
using System.Collections.Generic;

namespace Semana7
{
    class BalanceoExpresion
    {
        static bool EstaBalanceada(string expresion)
        {
            Stack<char> pila = new Stack<char>();

            foreach (char c in expresion)
            {
                if (c == '(' || c == '{' || c == '[')
                {
                    pila.Push(c);
                }
                else if (c == ')' || c == '}' || c == ']')
                {
                    if (pila.Count == 0)
                        return false;

                    char tope = pila.Pop();

                    if ((c == ')' && tope != '(') ||
                        (c == '}' && tope != '{') ||
                        (c == ']' && tope != '['))
                    {
                        return false;
                    }
                }
            }

            return pila.Count == 0;
        }

        // MÉTODO que se llama desde Program.cs
        public static void Ejecutar()
        {
            string expresion = "{7 + (8 * 5) - [(9 - 7) + (4 + 1)]}";

            if (EstaBalanceada(expresion))
                Console.WriteLine("Fórmula balanceada.");
            else
                Console.WriteLine("Fórmula NO balanceada.");
        }
    }
}


