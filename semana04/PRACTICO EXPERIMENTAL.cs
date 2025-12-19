using System;

class Program
{
    static void Main(string[] args)
    {
        Contacto[] agenda = new Contacto[12];

        agenda[0] = new Contacto { Id = 1, Nombres = "Madelin Ibeth", Apellidos = "Pianda Rosado", Direccion = "Barrio El Chisparo, Manabí", Telefonos = new string[] { "0994693440", "0990327340" } };
        agenda[1] = new Contacto { Id = 2, Nombres = "Juan Carlos", Apellidos = "Gómez López", Direccion = "Centro de la ciudad", Telefonos = new string[] { "0987654321" } };
        agenda[2] = new Contacto { Id = 3, Nombres = "María Fernanda", Apellidos = "Pérez Ruiz", Direccion = "Av. Amazonas", Telefonos = new string[] { "0971122334" } };
        agenda[3] = new Contacto { Id = 4, Nombres = "Luis Alberto", Apellidos = "Mendoza", Direccion = "Barrio San Juan", Telefonos = new string[] { "0962233445" } };
        agenda[4] = new Contacto { Id = 5, Nombres = "Ana Cristina", Apellidos = "Torres Vega", Direccion = "Cdla. Universitaria", Telefonos = new string[] { "0953344556" } };
        agenda[5] = new Contacto { Id = 6, Nombres = "Carlos Andrés", Apellidos = "Villacís", Direccion = "Sector Norte", Telefonos = new string[] { "0944455667" } };
        agenda[6] = new Contacto { Id = 7, Nombres = "Daniela", Apellidos = "Flores Ortiz", Direccion = "Barrio Central", Telefonos = new string[] { "0935566778" } };
        agenda[7] = new Contacto { Id = 8, Nombres = "José Miguel", Apellidos = "Cedeño", Direccion = "Av. Principal", Telefonos = new string[] { "0926677889" } };
        agenda[8] = new Contacto { Id = 9, Nombres = "Paola Andrea", Apellidos = "Ríos", Direccion = "Sector Sur", Telefonos = new string[] { "0917788990" } };
        agenda[9] = new Contacto { Id = 10, Nombres = "Ricardo", Apellidos = "Zambrano", Direccion = "Cdla. Los Álamos", Telefonos = new string[] { "0908899001" } };
        agenda[10] = new Contacto { Id = 11, Nombres = "Katherine", Apellidos = "López", Direccion = "Barrio El Recreo", Telefonos = new string[] { "0999988776" } };
        agenda[11] = new Contacto { Id = 12, Nombres = "Fernando", Apellidos = "Muñoz", Direccion = "Av. Universitaria", Telefonos = new string[] { "0988877665" } };

        Console.WriteLine("AGENDA TELEFÓNICA\n");

        for (int i = 0; i < agenda.Length; i++)
        {
            agenda[i].MostrarContacto();
        }

        Console.ReadKey();
    }
}
