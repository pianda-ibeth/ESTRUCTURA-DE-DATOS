using System;

class Estudiante
{
    public int ID { get; set; }
    public string Nombres { get; set; }
    public string Apellidos { get; set; }
    public string Direccion { get; set; }
    public string[] Telefonos { get; set; }

    public Estudiante(int id, string nombres, string apellidos, string direccion, string[] telefonos)
    {
        ID = id;
        Nombres = nombres;
        Apellidos = apellidos;
        Direccion = direccion;
        Telefonos = telefonos;
    }

    public void MostrarDatos()
    {
        Console.WriteLine("\n----- Datos del Estudiante -----");
        Console.WriteLine($"ID: {ID}");
        Console.WriteLine($"Nombres: {Nombres}");
        Console.WriteLine($"Apellidos: {Apellidos}");
        Console.WriteLine($"Dirección: {Direccion}");
        Console.WriteLine("Teléfonos registrados:");
        
        for (int i = 0; i < Telefonos.Length; i++)
        {
            Console.WriteLine($"Teléfono {i + 1}: {Telefonos[i]}");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Datos ya llenos
        int id = 101;
        string nombres = "Maly Estefanía";
        string apellidos = "Pianda López";
        string direccion = "Barrio Central, Quito";
        string[] telefonos = { "0987654321", "0991122334", "022547890" };

        // Crear objeto estudiante con los datos ya definidos
        Estudiante estudiante = new Estudiante(id, nombres, apellidos, direccion, telefonos);

        // Mostrar los datos
        estudiante.MostrarDatos();

        Console.WriteLine("\nProceso finalizado.");
    }
}
