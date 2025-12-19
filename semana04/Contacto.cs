using System;

public class Contacto
{
    public int Id;
    public string Nombres = "";
    public string Apellidos = "";
    public string Direccion = "";
    public string[] Telefonos = Array.Empty<string>();

    public void MostrarContacto()
    {
        Console.WriteLine("ID: " + Id);
        Console.WriteLine("Nombres: " + Nombres);
        Console.WriteLine("Apellidos: " + Apellidos);
        Console.WriteLine("Dirección: " + Direccion);
        Console.WriteLine("Teléfonos:");

        for (int i = 0; i < Telefonos.Length; i++)
        {
            Console.WriteLine(" - " + Telefonos[i]);
        }

        Console.WriteLine("-----------------------------");
    }
}
