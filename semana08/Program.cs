using System;
using System.Collections.Generic;
using System.Threading;

namespace CongresoAuditorio
{
    class Program
    {
        // Capacidad del auditorio
        private const int CAPACIDAD_AUDITORIO = 100;
        
        // Control de asientos disponibles (thread-safe)
        private static int asientosDisponibles = CAPACIDAD_AUDITORIO;
        private static object lockAsientos = new object();
        
        // Cola de asientos asignados en orden de llegada
        private static List<Asistente> registroAsientos = new List<Asistente>();
        
        static void Main(string[] args)
        {
            Console.WriteLine("═══════════════════════════════════════════════════════");
            Console.WriteLine("   SISTEMA DE REGISTRO - CONGRESO AUDITORIO");
            Console.WriteLine("   Capacidad: 100 asientos | 2 Líneas de registro");
            Console.WriteLine("═══════════════════════════════════════════════════════\n");
            
            MostrarMenu();
        }
        
        static void MostrarMenu()
        {
            while (true)
            {
                Console.WriteLine("\n--- MENÚ PRINCIPAL ---");
                Console.WriteLine("1. Registrar asistente (Línea 1)");
                Console.WriteLine("2. Registrar asistente (Línea 2)");
                Console.WriteLine("3. Ver asientos asignados");
                Console.WriteLine("4. Ver estadísticas");
                Console.WriteLine("5. Salir");
                Console.Write("\nSeleccione una opción: ");
                
                string opcion = Console.ReadLine();
                
                switch (opcion)
                {
                    case "1":
                        RegistrarAsistente(1);
                        break;
                    case "2":
                        RegistrarAsistente(2);
                        break;
                    case "3":
                        MostrarAsientosAsignados();
                        break;
                    case "4":
                        MostrarEstadisticas();
                        break;
                    case "5":
                        Console.WriteLine("\nGracias por usar el sistema. Hasta pronto.");
                        return;
                    default:
                        Console.WriteLine("\nOpción inválida. Intente nuevamente.");
                        break;
                }
            }
        }
        
        static void RegistrarAsistente(int linea)
        {
            lock (lockAsientos)
            {
                if (asientosDisponibles <= 0)
                {
                    Console.WriteLine($"\nAUDITORIO LLENO - No hay asientos disponibles");
                    return;
                }
            }
            
            Console.Write($"\n[Línea {linea}] Ingrese el nombre del asistente: ");
            string nombre = Console.ReadLine();
            
            if (string.IsNullOrWhiteSpace(nombre))
            {
                Console.WriteLine("El nombre no puede estar vacío.");
                return;
            }
            
            // Asignación de asiento (sección crítica)
            lock (lockAsientos)
            {
                if (asientosDisponibles > 0)
                {
                    int numeroAsiento = CAPACIDAD_AUDITORIO - asientosDisponibles + 1;
                    int ordenLlegada = registroAsientos.Count + 1;
                    asientosDisponibles--;
                    
                    Asistente nuevoAsistente = new Asistente
                    {
                        Nombre = nombre,
                        NumeroAsiento = numeroAsiento,
                        LineaRegistro = linea,
                        OrdenLlegada = ordenLlegada,
                        HoraRegistro = DateTime.Now
                    };
                    
                    registroAsientos.Add(nuevoAsistente);
                    
                    Console.WriteLine($"\nREGISTRO EXITOSO");
                    Console.WriteLine($"   Nombre: {nombre}");
                    Console.WriteLine($"   Orden de llegada: {ordenLlegada}");
                    Console.WriteLine($"   Asiento asignado: {numeroAsiento}");
                    Console.WriteLine($"   Línea de registro: {linea}");
                    Console.WriteLine($"   Asientos restantes: {asientosDisponibles}");
                }
                else
                {
                    Console.WriteLine($"\nAUDITORIO LLENO - No hay asientos disponibles");
                }
            }
        }
        
        static void MostrarAsientosAsignados()
        {
            Console.WriteLine("\n═══════════════════════════════════════════════════════");
            Console.WriteLine("           ASIENTOS ASIGNADOS (Orden de llegada)");
            Console.WriteLine("═══════════════════════════════════════════════════════");
            
            if (registroAsientos.Count == 0)
            {
                Console.WriteLine("\nNo hay asistentes registrados aún.");
                return;
            }
            
            Console.WriteLine($"\n{"Orden",-8} {"Asiento",-8} {"Nombre",-30} {"Línea",-6} {"Hora"}");
            Console.WriteLine(new string('-', 70));
            
            for (int i = 0; i < registroAsientos.Count; i++)
            {
                var asistente = registroAsientos[i];
                Console.WriteLine($"{asistente.OrdenLlegada,-8} {asistente.NumeroAsiento,-8} {asistente.Nombre,-30} " +
                                $"{asistente.LineaRegistro,-6} {asistente.HoraRegistro:HH:mm:ss}");
            }
            
            Console.WriteLine(new string('-', 70));
            Console.WriteLine($"Total registrados: {registroAsientos.Count}/{CAPACIDAD_AUDITORIO}");
        }
        
        static void MostrarEstadisticas()
        {
            Console.WriteLine("\n═══════════════════════════════════════════════════════");
            Console.WriteLine("                    ESTADÍSTICAS");
            Console.WriteLine("═══════════════════════════════════════════════════════");
            
            int totalLinea1 = 0;
            int totalLinea2 = 0;
            
            foreach (var asistente in registroAsientos)
            {
                if (asistente.LineaRegistro == 1)
                    totalLinea1++;
                else
                    totalLinea2++;
            }
            
            Console.WriteLine($"\nCapacidad total: {CAPACIDAD_AUDITORIO} asientos");
            Console.WriteLine($"Asientos ocupados: {registroAsientos.Count}");
            Console.WriteLine($"Asientos disponibles: {asientosDisponibles}");
            Console.WriteLine($"\nRegistros por línea:");
            Console.WriteLine($"  - Línea 1: {totalLinea1} asistentes ({(totalLinea1 * 100.0 / Math.Max(registroAsientos.Count, 1)):F1}%)");
            Console.WriteLine($"  - Línea 2: {totalLinea2} asistentes ({(totalLinea2 * 100.0 / Math.Max(registroAsientos.Count, 1)):F1}%)");
            Console.WriteLine($"\nOcupación del auditorio: {(registroAsientos.Count * 100.0 / CAPACIDAD_AUDITORIO):F1}%");
        }
    }
    
    // Clase para representar un asistente
    class Asistente
    {
        public string Nombre { get; set; }
        public int NumeroAsiento { get; set; }
        public int LineaRegistro { get; set; }
        public int OrdenLlegada { get; set; }
        public DateTime HoraRegistro { get; set; }
    }
}
