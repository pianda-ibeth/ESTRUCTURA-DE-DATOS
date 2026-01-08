using System;

namespace AgendaApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Instancia de la clase Agenda
            Agenda miAgenda = new Agenda();
            bool continuar = true;

            while (continuar)
            {
                
                Console.WriteLine("\n=== GESTIÓN DE AGENDA TELEFÓNICA ===");
                Console.ResetColor();
                Console.WriteLine("1. Agregar Contacto");
                Console.WriteLine("2. Mostrar Todos");
                Console.WriteLine("3. Buscar Contacto");
                Console.WriteLine("4. Eliminar Contacto");
                Console.WriteLine("5. Salir");
                Console.Write("Seleccione una opción: ");

                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        Console.WriteLine("\n[NUEVO CONTACTO]");
                        Console.Write("Ingrese Nombre: ");
                        string nom = Console.ReadLine();
                        Console.Write("Ingrese Teléfono: ");
                        string tel = Console.ReadLine();
                        Console.Write("Ingrese Email: ");
                        string email = Console.ReadLine();

                        // Validación simple
                        if (!string.IsNullOrEmpty(nom))
                        {
                            // Crea el objeto y lo pasa a la agenda
                            Contacto nuevoContacto = new Contacto(nom, tel, email);
                            miAgenda.AgregarContacto(nuevoContacto);
                        }
                        else
                        {
                            Console.WriteLine(">> Error: El nombre es obligatorio.");
                        }
                        break;

                    case "2":
                        miAgenda.MostrarContactos();
                        break;

                    case "3":
                        Console.Write("Ingrese nombre a buscar: ");
                        string busqueda = Console.ReadLine();
                        miAgenda.BuscarContacto(busqueda);
                        break;

                    case "4":
                        Console.Write("Ingrese nombre EXACTO a eliminar: ");
                        string eliminar = Console.ReadLine();
                        miAgenda.EliminarContacto(eliminar);
                        break;

                    case "5":
                        continuar = false;
                        Console.WriteLine("Cerrando sistema...");
                        break;

                    default:
                        Console.WriteLine("Opción no válida. Intente de nuevo.");
                        break;
                }
            }
        }
    }
}