using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class TraductorCompleto
{
    // Diccionario Inglés → Español
    static Dictionary<string, string> inglesEspanol = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
    {
        {"book", "libro"},
        {"house", "casa"},
        {"water", "agua"},
        {"food", "comida"},
        {"friend", "amigo"},
        {"school", "escuela"},
        {"city", "ciudad"},
        {"family", "familia"},
        {"music", "música"},
        {"love", "amor"},
        {"car", "carro"},
        {"dog", "perro"},
        {"sun", "sol"},
        {"moon", "luna"},
        {"river", "río"},
        {"mountain", "montaña"},
        {"computer", "computadora"},
        {"phone", "teléfono"},
        {"teacher", "profesor"},
        {"student", "estudiante"},
        {"work", "trabajo"},
        {"life", "vida"},
        {"world", "mundo"},
        {"time", "tiempo"}
    };

    // Diccionario Español → Inglés
    static Dictionary<string, string> espanolIngles = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

    static void Main()
    {
        InicializarDiccionarioInverso();
        MostrarMenu();
    }

    static void InicializarDiccionarioInverso()
    {
        foreach (var par in inglesEspanol)
        {
            if (!espanolIngles.ContainsKey(par.Value))
                espanolIngles.Add(par.Value, par.Key);
        }
    }

    static void MostrarMenu()
    {
        int opcion;

        do
        {
            Console.WriteLine("\n==================== MENÚ ====================");
            Console.WriteLine("1. Traducir una frase");
            Console.WriteLine("2. Agregar palabras al diccionario");
            Console.WriteLine("3. Ver total de palabras");
            Console.WriteLine("0. Salir");
            Console.Write("\nSeleccione una opción: ");

            if (!int.TryParse(Console.ReadLine(), out opcion))
            {
                Console.WriteLine("Debe ingresar un número válido.");
                continue;
            }

            switch (opcion)
            {
                case 1:
                    TraducirFrase();
                    break;
                case 2:
                    AgregarPalabra();
                    break;
                case 3:
                    Console.WriteLine($"Total palabras registradas: {inglesEspanol.Count}");
                    break;
                case 0:
                    Console.WriteLine("Gracias por usar el traductor.");
                    break;
                default:
                    Console.WriteLine("Opción inválida.");
                    break;
            }

        } while (opcion != 0);
    }

    static void TraducirFrase()
    {
        Console.Write("\nIngrese la frase a traducir: ");
        string frase = Console.ReadLine();

        string resultado = Regex.Replace(frase, @"\b[\wáéíóúñÁÉÍÓÚÑ]+\b", match =>
        {
            string palabraOriginal = match.Value;
            string palabraLower = palabraOriginal.ToLower();

            if (inglesEspanol.ContainsKey(palabraLower))
                return AjustarMayuscula(palabraOriginal, inglesEspanol[palabraLower]);

            if (espanolIngles.ContainsKey(palabraLower))
                return AjustarMayuscula(palabraOriginal, espanolIngles[palabraLower]);

            return palabraOriginal;
        });

        Console.WriteLine("\nTraducción: " + resultado);
    }

    static void AgregarPalabra()
    {
        Console.Write("\nIngrese la palabra en inglés: ");
        string ingles = Console.ReadLine().ToLower();

        Console.Write("Ingrese la traducción en español: ");
        string espanol = Console.ReadLine().ToLower();

        if (string.IsNullOrWhiteSpace(ingles) || string.IsNullOrWhiteSpace(espanol))
        {
            Console.WriteLine("No se permiten campos vacíos.");
            return;
        }

        if (!inglesEspanol.ContainsKey(ingles))
        {
            inglesEspanol.Add(ingles, espanol);

            if (!espanolIngles.ContainsKey(espanol))
                espanolIngles.Add(espanol, ingles);

            Console.WriteLine("Palabra agregada correctamente.");
        }
        else
        {
            Console.WriteLine("La palabra ya existe.");
        }
    }

    static string AjustarMayuscula(string original, string traducida)
    {
        if (char.IsUpper(original[0]))
            return char.ToUpper(traducida[0]) + traducida.Substring(1);

        return traducida;
    }
}