using System;
using System.Collections.Generic;

class Asistente
{
    public string Nombre;

    public Asistente(string nombre)
    {
        Nombre = nombre;
    }
}

class Auditorio
{
    private int asientosDisponibles = 100;
    private Queue<Asistente> colaA = new Queue<Asistente>();
    private Queue<Asistente> colaB = new Queue<Asistente>();

    public void RegistrarColaA(string nombre)
    {
        colaA.Enqueue(new Asistente(nombre));
    }

    public void RegistrarColaB(string nombre)
    {
        colaB.Enqueue(new Asistente(nombre));
    }

    public void AsignarAsientos()
    {
        int asiento = 1;

        while (asientosDisponibles > 0 && (colaA.Count > 0 || colaB.Count > 0))
        {
            if (colaA.Count > 0)
            {
                Asistente a = colaA.Dequeue();
                Console.WriteLine("Asiento " + asiento + ": " + a.Nombre + " (Cola A)");
                asiento++;
                asientosDisponibles--;
            }

            if (colaB.Count > 0 && asientosDisponibles > 0)
            {
                Asistente b = colaB.Dequeue();
                Console.WriteLine("Asiento " + asiento + ": " + b.Nombre + " (Cola B)");
                asiento++;
                asientosDisponibles--;
            }
        }

        Console.WriteLine("\nAsientos disponibles restantes: " + asientosDisponibles);
    }
}

class Program
{
    static void Main(string[] args)
    {
        Auditorio auditorio = new Auditorio();

        // 25 personas con nombres
        auditorio.RegistrarColaA("Ana");
        auditorio.RegistrarColaB("Luis");
        auditorio.RegistrarColaA("Carlos");
        auditorio.RegistrarColaB("María");
        auditorio.RegistrarColaA("Pedro");
        auditorio.RegistrarColaB("Sofía");
        auditorio.RegistrarColaA("Juan");
        auditorio.RegistrarColaB("Lucía");
        auditorio.RegistrarColaA("Miguel");
        auditorio.RegistrarColaB("Valeria");
        auditorio.RegistrarColaA("Andrés");
        auditorio.RegistrarColaB("Daniela");
        auditorio.RegistrarColaA("José");
        auditorio.RegistrarColaB("Paula");
        auditorio.RegistrarColaA("Fernando");
        auditorio.RegistrarColaB("Camila");
        auditorio.RegistrarColaA("Diego");
        auditorio.RegistrarColaB("Elena");
        auditorio.RegistrarColaA("Ricardo");
        auditorio.RegistrarColaB("Natalia");
        auditorio.RegistrarColaA("Jorge");
        auditorio.RegistrarColaB("Karla");
        auditorio.RegistrarColaA("Héctor");
        auditorio.RegistrarColaB("Rosa");
        auditorio.RegistrarColaA("Pablo");

        Console.WriteLine("ASIGNACIÓN DE ASIENTOS\n");
        auditorio.AsignarAsientos();

        Console.ReadKey();
    }
}

