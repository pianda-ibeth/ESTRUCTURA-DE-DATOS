using System;

class Program
{
    static void Main()
    {
        // =====================
        // EJERCICIO 1
        // =====================
        Console.WriteLine("=====================");
        Console.WriteLine("EJERCICIO 1");
        Console.WriteLine("=====================");

        ListaContar lista1 = new ListaContar();
        lista1.InsertarInicio(10);
        lista1.InsertarInicio(20);
        lista1.InsertarInicio(30);

        Console.Write("Lista: ");
        lista1.Mostrar();
        Console.WriteLine("Cantidad de elementos: " + lista1.ContarElementos());

        Console.WriteLine(); // salto de línea

        // =====================
        // EJERCICIO 3
        // =====================
        Console.WriteLine("=====================");
        Console.WriteLine("EJERCICIO 3");
        Console.WriteLine("=====================");

        ListaBuscar lista2 = new ListaBuscar();
        lista2.InsertarInicio(5);
        lista2.InsertarInicio(10);
        lista2.InsertarInicio(5);
        lista2.InsertarInicio(20);

        int valor = 5;
        int veces = lista2.Buscar(valor);

        Console.WriteLine("Valor buscado: " + valor);
        Console.WriteLine("Se repite: " + veces + " veces");
    }
}
