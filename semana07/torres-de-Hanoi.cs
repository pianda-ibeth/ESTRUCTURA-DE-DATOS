using System;
using System.Collections.Generic;

namespace Semana7
{
    class TorresDeHanoi
    {
        static void MoverDiscos(
            int n,
            Stack<int> origen,
            Stack<int> destino,
            Stack<int> auxiliar,
            string nombreOrigen,
            string nombreDestino,
            string nombreAuxiliar)
        {
            if (n == 1)
            {
                int disco = origen.Pop();
                destino.Push(disco);
                Console.WriteLine($"Mover disco {disco} de {nombreOrigen} a {nombreDestino}");
                return;
            }

            MoverDiscos(n - 1, origen, auxiliar, destino,
                        nombreOrigen, nombreAuxiliar, nombreDestino);

            int discoMayor = origen.Pop();
            destino.Push(discoMayor);
            Console.WriteLine($"Mover disco {discoMayor} de {nombreOrigen} a {nombreDestino}");

            MoverDiscos(n - 1, auxiliar, destino, origen,
                        nombreAuxiliar, nombreDestino, nombreOrigen);
        }

        // MÉTODO que se llama desde Program.cs
        public static void Ejecutar()
        {
            int numeroDiscos = 3;

            Stack<int> torreA = new Stack<int>();
            Stack<int> torreB = new Stack<int>();
            Stack<int> torreC = new Stack<int>();

            for (int i = numeroDiscos; i >= 1; i--)
            {
                torreA.Push(i);
            }

            Console.WriteLine("Movimientos de las Torres de Hanoi:\n");

            MoverDiscos(numeroDiscos, torreA, torreC, torreB,
                        "Torre A", "Torre C", "Torre B");
        }
    }
}
