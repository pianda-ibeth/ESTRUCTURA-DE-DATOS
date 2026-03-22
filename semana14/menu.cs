class Program
{
    static void Main()
    {
        ArbolBST arbol = new ArbolBST();
        int opcion, valor;

        do
        {
            Console.WriteLine("\n--- MENU BST ---");
            Console.WriteLine("1. Insertar");
            Console.WriteLine("2. Buscar");
            Console.WriteLine("3. Eliminar");
            Console.WriteLine("4. Recorridos");
            Console.WriteLine("5. Minimo, Maximo, Altura");
            Console.WriteLine("6. Limpiar árbol");
            Console.WriteLine("0. Salir");
            Console.Write("Seleccione: ");
            opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    Console.Write("Ingrese valor: ");
                    valor = int.Parse(Console.ReadLine());
                    arbol.Insertar(valor);
                    break;

                case 2:
                    Console.Write("Valor a buscar: ");
                    valor = int.Parse(Console.ReadLine());
                    Console.WriteLine(arbol.Buscar(valor) ? "Encontrado" : "No encontrado");
                    break;

                case 3:
                    Console.Write("Valor a eliminar: ");
                    valor = int.Parse(Console.ReadLine());
                    arbol.Eliminar(valor);
                    break;

                case 4:
                    Console.WriteLine("Inorden:");
                    arbol.Inorden(arbol.Raiz);
                    Console.WriteLine("\nPreorden:");
                    arbol.Preorden(arbol.Raiz);
                    Console.WriteLine("\nPostorden:");
                    arbol.Postorden(arbol.Raiz);
                    Console.WriteLine();
                    break;

                case 5:
                    if (arbol.Raiz != null)
                    {
                        Console.WriteLine("Minimo: " + arbol.Minimo(arbol.Raiz));
                        Console.WriteLine("Maximo: " + arbol.Maximo(arbol.Raiz));
                        Console.WriteLine("Altura: " + arbol.Altura(arbol.Raiz));
                    }
                    else
                        Console.WriteLine("Árbol vacío");
                    break;

                case 6:
                    arbol.Limpiar();
                    Console.WriteLine("Árbol limpiado");
                    break;
            }

        } while (opcion != 0);
    }
}