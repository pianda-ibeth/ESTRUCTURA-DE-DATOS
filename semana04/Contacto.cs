using System;

namespace AgendaApp
{
    // CLASE CONTACTO
    // Representa el registro de datos individual
    public class Contacto
    {
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }

        public Contacto(string nombre, string telefono, string email)
        {
            Nombre = nombre;
            Telefono = telefono;
            Email = email;
        }

        // Método para facilitar la impresión de datos en una sola línea
        public override string ToString()
        {
            return $"Nombre: {Nombre} | Tel: {Telefono} | Email: {Email}";
        }
    }
}