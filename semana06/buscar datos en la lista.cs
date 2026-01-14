using System;

class NodoBuscar
{
    public int Dato;
    public NodoBuscar Siguiente;

    public NodoBuscar(int dato)
    {
        Dato = dato;
        Siguiente = null;
    }
}

class ListaBuscar
{
    private NodoBuscar cabeza;

    public void InsertarInicio(int dato)
    {
        NodoBuscar nuevo = new NodoBuscar(dato);
        nuevo.Siguiente = cabeza;
        cabeza = nuevo;
    }

    public int Buscar(int valor)
    {
        int contador = 0;
        NodoBuscar actual = cabeza;

        while (actual != null)
        {
            if (actual.Dato == valor)
                contador++;

            actual = actual.Siguiente;
        }

        if (contador == 0)
            Console.WriteLine("El dato no fue encontrado.");

        return contador;
    }
}
