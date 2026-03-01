using System;
using System.Collections.Generic;

class Program
{
    static Dictionary<string, List<string>> equipos =
        new Dictionary<string, List<string>>()
    {
        { "Barcelona", new List<string> 
            { "JavierBurrai", "MarioPineida", "DamiánDiaz", "FidelMartinez", "AdonisPreciado" } },

        { "LigaQuito", new List<string> 
            { "AlexanderDominguez", "EzequielPiovi", "LisandroAlzugaray", "PaoloGuerrero", "JoseQuintero" } },

        { "Emelec", new List<string> 
            { "PedroOrtiz", "MillerBolanos", "AlexisZapata", "AnibalLeguizamon", "BryanCarabali" } },

        { "UniversidadCatolica", new List<string> 
            { "RafaelRomero", "IsmaelDiaz", "FacundoMartinez", "AndresLopez" } },

        { "Aucas", new List<string> 
            { "HernanGalindez", "EdisonCaicedo", "JhonCifuente", "CarlosCuero", "VictorFigueroa" } },

        { "IndependienteDelValle", new List<string> 
            { "MoisesRamirez", "JuniorSornoza", "LautaroDiaz", "RichardSchunke", "LorenzoFaravelli" } },

        { "RealMadrid", new List<string> 
            { "ViniciusJunior", "Rodrygo", "LukaModric", "ThibautCourtois" } },

        { "ManchesterCity", new List<string> 
            { "ErlingHaaland", "KevinDeBruyne", "PhilFoden", "BernardoSilva", "Ederson" } }
    };

    static void Main(string[] args)
    {
        int opcion;

        do
        {
            Console.WriteLine("\n1. Registrar equipo");
            Console.WriteLine("2. Registrar jugador");
            Console.WriteLine("3. Mostrar equipos");
            Console.WriteLine("4. Eliminar jugador");
            Console.WriteLine("5. Salir");
            Console.Write("Seleccione una opción: ");

            int.TryParse(Console.ReadLine(), out opcion);

            switch (opcion)
            {
                case 1:
                    RegistrarEquipo();
                    break;

                case 2:
                    RegistrarJugador();
                    break;

                case 3:
                    MostrarEquipos();
                    break;

                case 4:
                    EliminarJugador();
                    break;

                case 5:
                    Console.WriteLine("Saliendo...");
                    break;

                default:
                    Console.WriteLine("Opción inválida.");
                    break;
            }

        } while (opcion != 5);
    }

    static void RegistrarEquipo()
    {
        Console.Write("Ingrese nombre del equipo: ");
        string nombre = Console.ReadLine();

        if (!equipos.ContainsKey(nombre))
        {
            equipos[nombre] = new List<string>();
            Console.WriteLine("Equipo registrado correctamente.");
        }
        else
        {
            Console.WriteLine("El equipo ya existe.");
        }
    }

    static void RegistrarJugador()
    {
        Console.Write("Ingrese nombre del equipo: ");
        string equipo = Console.ReadLine();

        if (!equipos.ContainsKey(equipo))
        {
            Console.WriteLine("Equipo no encontrado.");
            return;
        }

        Console.Write("Ingrese nombre del jugador: ");
        string jugador = Console.ReadLine();

        equipos[equipo].Add(jugador);
        Console.WriteLine("Jugador agregado correctamente.");
    }

    static void MostrarEquipos()
    {
        foreach (var equipo in equipos)
        {
            Console.WriteLine("\nEquipo: " + equipo.Key);

            foreach (var jugador in equipo.Value)
            {
                Console.WriteLine(" - " + jugador);
            }
        }
    }

    static void EliminarJugador()
    {
        Console.Write("Ingrese nombre del equipo: ");
        string equipo = Console.ReadLine();

        if (!equipos.ContainsKey(equipo))
        {
            Console.WriteLine("Equipo no encontrado.");
            return;
        }

        Console.Write("Ingrese nombre del jugador a eliminar: ");
        string jugador = Console.ReadLine();

        if (equipos[equipo].Remove(jugador))
        {
            Console.WriteLine("Jugador eliminado correctamente.");
        }
        else
        {
            Console.WriteLine("El jugador no existe.");
        }
    }
}