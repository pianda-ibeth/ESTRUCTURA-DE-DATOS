using System;

class NodoContar
{
    public int Dato;
    public NodoContar Siguiente;

    public NodoContar(int dato)
    {
        Dato = dato;
        Siguiente = null;
    }
}

class ListaContar
{
    private NodoContar cabeza;

    public void InsertarInicio(int dato)
    {
        NodoContar nuevo = new NodoContar(dato);
        nuevo.Siguiente = cabeza;
        cabeza = nuevo;
    }

    public int ContarElementos()
    {
        int contador = 0;
        NodoContar actual = cabeza;

        while (actual != null)
        {
            contador++;
            actual = actual.Siguiente;
        }

        return contador;
    }

    public void Mostrar()
    {
        NodoContar actual = cabeza;
        while (actual != null)
        {
            Console.Write(actual.Dato + " ");
            actual = actual.Siguiente;
        }
        Console.WriteLine();
    }
}
