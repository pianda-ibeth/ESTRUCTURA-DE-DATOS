using System;

namespace AgendaApp
{
    // CLASE AGENDA
    // Maneja la lógica de almacenamiento usando Vectores (Arrays)
    public class Agenda
    {
        private Contacto[] listaContactos; // Vector de objetos
        private int contador; // Puntero para controlar la posición libre
        private int capacidadMaxima = 100; // Tamaño fijo del vector

        public Agenda()
        {
            listaContactos = new Contacto[capacidadMaxima];
            contador = 0;
        }

        // Método para agregar un contacto al vector
        public void AgregarContacto(Contacto nuevo)
        {
            if (contador < capacidadMaxima)
            {
                listaContactos[contador] = nuevo;
                contador++;
                Console.WriteLine(">> Contacto registrado con éxito.");
            }
            else
            {
                Console.WriteLine(">> Error: La agenda está llena (Límite del vector alcanzado).");
            }
        }

        // Método para recorrer y mostrar el vector
        public void MostrarContactos()
        {
            Console.WriteLine("\n--- LISTA DE CONTACTOS ---");
            if (contador == 0)
            {
                Console.WriteLine("No hay contactos registrados.");
            }
            else
            {
                for (int i = 0; i < contador; i++)
                {
                    Console.WriteLine($"[{i + 1}] {listaContactos[i].ToString()}");
                }
            }
            Console.WriteLine("--------------------------");
        }

        // Método de búsqueda lineal (recorrido secuencial)
        public void BuscarContacto(string nombreBusqueda)
        {
            bool encontrado = false;
            Console.WriteLine($"\n--- BUSCANDO: {nombreBusqueda} ---");
            for (int i = 0; i < contador; i++)
            {
                // Compara ignorando mayúsculas/minúsculas
                if (listaContactos[i].Nombre.ToLower().Contains(nombreBusqueda.ToLower()))
                {
                    Console.WriteLine(listaContactos[i].ToString());
                    encontrado = true;
                }
            }
            if (!encontrado) Console.WriteLine(">> No se encontraron coincidencias.");
        }

        // Método para eliminar y reorganizar el vector
        public void EliminarContacto(string nombreEliminar)
        {
            int indice = -1;
            
            // 1. Buscar el índice del elemento a eliminar
            for (int i = 0; i < contador; i++)
            {
                if (listaContactos[i].Nombre.Equals(nombreEliminar, StringComparison.OrdinalIgnoreCase))
                {
                    indice = i;
                    break;
                }
            }

            // 2. Eliminar y desplazar elementos hacia la izquierda
            if (indice != -1)
            {
                for (int i = indice; i < contador - 1; i++)
                {
                    listaContactos[i] = listaContactos[i + 1];
                }
                
                // Limpiar la última posición duplicada y reducir contador
                listaContactos[contador - 1] = null; 
                contador--;
                
                Console.WriteLine($">> Contacto '{nombreEliminar}' eliminado correctamente.");
            }
            else
            {
                Console.WriteLine(">> Contacto no encontrado. Verifique el nombre.");
            }
        }
    }
}