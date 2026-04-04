using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SistemaVuelosBaratos
{
    // ==================== CLASE DEL GRAFO ====================
    public class GrafoVuelos
    {
        private Dictionary<string, List<Tuple<string, int>>> grafo;

        public GrafoVuelos()
        {
            grafo = new Dictionary<string, List<Tuple<string, int>>>();
        }

        public void AgregarVuelo(string origen, string destino, int precio)
        {
            if (!grafo.ContainsKey(origen))
            {
                grafo[origen] = new List<Tuple<string, int>>();
            }
            grafo[origen].Add(new Tuple<string, int>(destino, precio));
            Console.WriteLine("[OK] Vuelo agregado: " + origen + " -> " + destino + " ($" + precio + ")");
        }

        public void CargarDesdeArchivo(string nombreArchivo)
        {
            try
            {
                if (File.Exists(nombreArchivo))
                {
                    string[] lineas = File.ReadAllLines(nombreArchivo);
                    int contador = 0;

                    foreach (string linea in lineas)
                    {
                        if (!string.IsNullOrWhiteSpace(linea) && !linea.StartsWith("#"))
                        {
                            string[] partes = linea.Split(',');
                            if (partes.Length == 3)
                            {
                                string origen = partes[0].Trim();
                                string destino = partes[1].Trim();
                                int precio;
                                if (int.TryParse(partes[2].Trim(), out precio))
                                {
                                    if (!grafo.ContainsKey(origen))
                                    {
                                        grafo[origen] = new List<Tuple<string, int>>();
                                    }
                                    grafo[origen].Add(new Tuple<string, int>(destino, precio));
                                    contador++;
                                }
                            }
                        }
                    }
                    Console.WriteLine("[OK] Datos cargados desde " + nombreArchivo + " (" + contador + " rutas)");
                }
                else
                {
                    Console.WriteLine("[ADVERTENCIA] No se encontro " + nombreArchivo + ", cargando datos de ejemplo...");
                    CargarDatosEjemplo();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("[ERROR] " + ex.Message);
                CargarDatosEjemplo();
            }
        }

        public void CargarDatosEjemplo()
        {
            AgregarVuelo("Quito", "Guayaquil", 80);
            AgregarVuelo("Quito", "Cuenca", 100);
            AgregarVuelo("Quito", "Manta", 120);
            AgregarVuelo("Guayaquil", "Cuenca", 50);
            AgregarVuelo("Guayaquil", "Manta", 70);
            AgregarVuelo("Guayaquil", "Galapagos", 200);
            AgregarVuelo("Cuenca", "Guayaquil", 55);
            AgregarVuelo("Cuenca", "Manta", 90);
            AgregarVuelo("Manta", "Quito", 115);
            AgregarVuelo("Quito", "Loja", 150);
            AgregarVuelo("Loja", "Cuenca", 85);
        }

        public Tuple<int, List<string>> VueloMasBarato(string inicio, string fin)
        {
            if (!grafo.ContainsKey(inicio))
                return new Tuple<int, List<string>>(int.MaxValue, new List<string>());

            Dictionary<string, int> distancias = new Dictionary<string, int>();
            Dictionary<string, string> padres = new Dictionary<string, string>();
            HashSet<string> noVisitados = new HashSet<string>();

            foreach (string ciudad in grafo.Keys)
            {
                distancias[ciudad] = int.MaxValue;
                padres[ciudad] = null;
                noVisitados.Add(ciudad);
            }

            foreach (string ciudad in grafo.Values.SelectMany(x => x.Select(y => y.Item1)))
            {
                if (!distancias.ContainsKey(ciudad))
                {
                    distancias[ciudad] = int.MaxValue;
                    padres[ciudad] = null;
                    noVisitados.Add(ciudad);
                }
            }

            distancias[inicio] = 0;

            while (noVisitados.Count > 0)
            {
                string ciudadActual = null;
                int menorDistancia = int.MaxValue;

                foreach (string ciudad in noVisitados)
                {
                    if (distancias.ContainsKey(ciudad) && distancias[ciudad] < menorDistancia)
                    {
                        menorDistancia = distancias[ciudad];
                        ciudadActual = ciudad;
                    }
                }

                if (ciudadActual == null) break;
                if (ciudadActual == fin) break;

                noVisitados.Remove(ciudadActual);

                if (grafo.ContainsKey(ciudadActual))
                {
                    foreach (Tuple<string, int> vecino in grafo[ciudadActual])
                    {
                        string ciudadVecino = vecino.Item1;
                        int precio = vecino.Item2;

                        if (noVisitados.Contains(ciudadVecino))
                        {
                            int nuevaDistancia = distancias[ciudadActual] + precio;
                            if (nuevaDistancia < distancias[ciudadVecino])
                            {
                                distancias[ciudadVecino] = nuevaDistancia;
                                padres[ciudadVecino] = ciudadActual;
                            }
                        }
                    }
                }
            }

            if (!distancias.ContainsKey(fin) || distancias[fin] == int.MaxValue)
                return new Tuple<int, List<string>>(int.MaxValue, new List<string>());

            List<string> ruta = new List<string>();
            string actual = fin;
            while (actual != null)
            {
                ruta.Insert(0, actual);
                actual = padres[actual];
            }

            return new Tuple<int, List<string>>(distancias[fin], ruta);
        }

        public void ListarTodasLasRutas()
        {
            if (grafo.Count == 0)
            {
                Console.WriteLine("\n[ADVERTENCIA] No hay rutas disponibles");
                return;
            }

            Console.WriteLine("\n" + new string('=', 50));
            Console.WriteLine("LISTADO DE RUTAS");
            Console.WriteLine(new string('=', 50));
            Console.WriteLine(string.Format("{0,-15} {1,-15} {2,10}", "Origen", "Destino", "Precio"));
            Console.WriteLine(new string('-', 42));

            int total = 0;
            foreach (string origen in grafo.Keys.OrderBy(x => x))
            {
                foreach (Tuple<string, int> destino in grafo[origen].OrderBy(x => x.Item2))
                {
                    Console.WriteLine(string.Format("{0,-15} {1,-15} ${2,8}", origen, destino.Item1, destino.Item2));
                    total++;
                }
            }
            Console.WriteLine(new string('-', 42));
            Console.WriteLine("Total: " + total + " rutas");
        }

        public void VerConexiones(string ciudad)
        {
            if (!grafo.ContainsKey(ciudad))
            {
                Console.WriteLine("\n[ERROR] Ciudad '" + ciudad + "' no encontrada");
                Console.WriteLine("Ciudades disponibles: " + string.Join(", ", ObtenerCiudades()));
                return;
            }

            Console.WriteLine("\nVUELOS DESDE " + ciudad.ToUpper() + ":");
            Console.WriteLine(new string('-', 35));
            Console.WriteLine(string.Format("{0,-15} {1,10}", "Destino", "Precio"));
            Console.WriteLine(new string('-', 35));

            foreach (Tuple<string, int> v in grafo[ciudad].OrderBy(x => x.Item2))
                Console.WriteLine(string.Format("{0,-15} ${1,8}", v.Item1, v.Item2));

            Console.WriteLine(new string('-', 35));
            Console.WriteLine("Total: " + grafo[ciudad].Count + " vuelos");
        }

        public List<string> ObtenerCiudades()
        {
            HashSet<string> ciudades = new HashSet<string>();
            foreach (string o in grafo.Keys)
            {
                ciudades.Add(o);
                foreach (Tuple<string, int> d in grafo[o])
                    ciudades.Add(d.Item1);
            }
            return ciudades.OrderBy(x => x).ToList();
        }

        public void MostrarEstadisticas()
        {
            List<string> ciudades = ObtenerCiudades();
            int totalRutas = grafo.Values.Sum(x => x.Count);
            Console.WriteLine("\nESTADISTICAS DEL SISTEMA");
            Console.WriteLine(new string('=', 30));
            Console.WriteLine("Ciudades: " + ciudades.Count);
            Console.WriteLine("Rutas totales: " + totalRutas);
            if (ciudades.Count > 1)
            {
                double densidad = (double)totalRutas / (ciudades.Count * (ciudades.Count - 1)) * 100;
                Console.WriteLine("Densidad del grafo: " + densidad.ToString("F2") + "%");
            }
            if (grafo.Count > 0)
            {
                var top = grafo.OrderByDescending(x => x.Value.Count).First();
                Console.WriteLine("Ciudad con mas vuelos de salida: " + top.Key + " (" + top.Value.Count + " vuelos)");
            }
        }

        public bool GuardarEnArchivo(string nombre)
        {
            try
            {
                List<string> lineas = new List<string>(); 
                lineas.Add("# Archivo de vuelos - Formato: Origen, Destino, Precio");
                lineas.Add("# Generado automaticamente");
                lineas.Add("");
                foreach (string o in grafo.Keys.OrderBy(x => x))
                    foreach (Tuple<string, int> d in grafo[o].OrderBy(x => x.Item2))
                        lineas.Add(o + ", " + d.Item1 + ", " + d.Item2);
                File.WriteAllLines(nombre, lineas);
                Console.WriteLine("[OK] Datos guardados en " + nombre);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("[ERROR] " + ex.Message);
                return false;
            }
        }
    }

    // ==================== PROGRAMA PRINCIPAL ====================
    class Program
    {
        static GrafoVuelos sistema;
        static string archivo = "vuelos.txt";

        static void Main(string[] args)
        {
            Console.Title = "Sistema de Vuelos Baratos";
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("");
            Console.WriteLine("==================================================");
            Console.WriteLine("    SISTEMA DE VUELOS BARATOS - C#");
            Console.WriteLine("    Algoritmo de Dijkstra - Grafos Ponderados");
            Console.WriteLine("==================================================");
            Console.WriteLine("");

            sistema = new GrafoVuelos();
            sistema.CargarDesdeArchivo(archivo);
            Menu();
        }

        static void Menu()
        {
            while (true)
            {
                Console.WriteLine("\n" + new string('=', 50));
                Console.WriteLine("MENU PRINCIPAL");
                Console.WriteLine(new string('=', 50));
                Console.WriteLine("1. Listar todas las rutas");
                Console.WriteLine("2. Buscar vuelo mas barato");
                Console.WriteLine("3. Ver conexiones por ciudad");
                Console.WriteLine("4. Agregar nueva ruta");
                Console.WriteLine("5. Ver estadisticas");
                Console.WriteLine("6. Guardar datos en archivo");
                Console.WriteLine("7. Limpiar pantalla");
                Console.WriteLine("8. Salir");
                Console.WriteLine(new string('-', 50));
                Console.Write("Seleccione una opcion (1-8): ");

                string op = Console.ReadLine();
                if (op == null) op = "";
                op = op.Trim();
                Console.WriteLine();

                if (op == "1")
                {
                    sistema.ListarTodasLasRutas();
                }
                else if (op == "2")
                {
                    BuscarVuelo();
                }
                else if (op == "3")
                {
                    VerConexiones();
                }
                else if (op == "4")
                {
                    AgregarRuta();
                }
                else if (op == "5")
                {
                    sistema.MostrarEstadisticas();
                }
                else if (op == "6")
                {
                    sistema.GuardarEnArchivo(archivo);
                }
                else if (op == "7")
                {
                    Console.Clear();
                    Console.WriteLine("==================================================");
                    Console.WriteLine("    SISTEMA DE VUELOS BARATOS - C#");
                    Console.WriteLine("==================================================");
                }
                else if (op == "8")
                {
                    Console.WriteLine("\n[INFO] Gracias por usar el sistema. Hasta luego!\n");
                    break;
                }
                else
                {
                    Console.WriteLine("[ERROR] Opcion invalida. Intente nuevamente.");
                }

                Console.WriteLine("\nPresione cualquier tecla para continuar...");
                Console.ReadKey();
            }
        }

        static void BuscarVuelo()
        {
            Console.WriteLine("BUSCAR VUELO MAS BARATO");
            Console.WriteLine(new string('-', 40));
            
            List<string> ciudades = sistema.ObtenerCiudades();
            if (ciudades.Count > 0)
            {
                Console.WriteLine("Ciudades disponibles: " + string.Join(", ", ciudades));
            }
            
            Console.Write("\nCiudad de origen: ");
            string origen = Console.ReadLine();
            if (origen == null) origen = "";
            origen = origen.Trim();
            
            Console.Write("Ciudad de destino: ");
            string destino = Console.ReadLine();
            if (destino == null) destino = "";
            destino = destino.Trim();

            if (string.IsNullOrEmpty(origen) || string.IsNullOrEmpty(destino))
            {
                Console.WriteLine("\n[ERROR] Las ciudades no pueden estar vacias");
                return;
            }

            origen = char.ToUpper(origen[0]) + origen.Substring(1).ToLower();
            destino = char.ToUpper(destino[0]) + destino.Substring(1).ToLower();

            Console.WriteLine("\nCalculando ruta mas barata...\n");

            Tuple<int, List<string>> resultado = sistema.VueloMasBarato(origen, destino);
            int precio = resultado.Item1;
            List<string> ruta = resultado.Item2;

            if (precio == int.MaxValue)
            {
                Console.WriteLine("[ERROR] No existe ruta disponible de " + origen + " a " + destino);
            }
            else
            {
                Console.WriteLine("[OK] Ruta encontrada!");
                Console.WriteLine("Ruta completa: " + string.Join(" -> ", ruta));
                Console.WriteLine("Precio total: $" + precio);
                Console.WriteLine("Numero de escalas: " + (ruta.Count - 2));
            }
        }

        static void VerConexiones()
        {
            Console.WriteLine("CONSULTAR CONEXIONES POR CIUDAD");
            Console.WriteLine(new string('-', 40));
            
            List<string> ciudades = sistema.ObtenerCiudades();
            if (ciudades.Count > 0)
            {
                Console.WriteLine("Ciudades disponibles: " + string.Join(", ", ciudades));
            }
            
            Console.Write("\nIngrese el nombre de la ciudad: ");
            string ciudad = Console.ReadLine();
            if (ciudad == null) ciudad = "";
            ciudad = ciudad.Trim();

            if (!string.IsNullOrEmpty(ciudad))
            {
                ciudad = char.ToUpper(ciudad[0]) + ciudad.Substring(1).ToLower();
                sistema.VerConexiones(ciudad);
            }
            else
            {
                Console.WriteLine("[ERROR] Nombre de ciudad no valido");
            }
        }

        static void AgregarRuta()
        {
            Console.WriteLine("AGREGAR NUEVA RUTA");
            Console.WriteLine(new string('-', 40));
            
            Console.Write("Ciudad de origen: ");
            string origen = Console.ReadLine();
            if (origen == null) origen = "";
            origen = origen.Trim();
            
            Console.Write("Ciudad de destino: ");
            string destino = Console.ReadLine();
            if (destino == null) destino = "";
            destino = destino.Trim();
            
            Console.Write("Precio del vuelo: ");
            string precioInput = Console.ReadLine();
            if (precioInput == null) precioInput = "";
            
            int precio;
            if (int.TryParse(precioInput.Trim(), out precio) && precio > 0)
            {
                if (!string.IsNullOrEmpty(origen) && !string.IsNullOrEmpty(destino))
                {
                    origen = char.ToUpper(origen[0]) + origen.Substring(1).ToLower();
                    destino = char.ToUpper(destino[0]) + destino.Substring(1).ToLower();
                    sistema.AgregarVuelo(origen, destino, precio);
                }
                else
                {
                    Console.WriteLine("[ERROR] Las ciudades no pueden estar vacias");
                }
            }
            else
            {
                Console.WriteLine("[ERROR] Precio invalido. Debe ser un numero entero positivo.");
            }
        }
    }
}