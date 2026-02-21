using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        // Universo: 500 ciudadanos
        HashSet<string> ciudadanos = new HashSet<string>();

        for (int i = 1; i <= 500; i++)
        {
            ciudadanos.Add($"Ciudadano {i}");
        }

        // Conjunto vacunados con Pfizer (75)
        HashSet<string> pfizer = new HashSet<string>();

        for (int i = 1; i <= 75; i++)
        {
            pfizer.Add($"Ciudadano {i}");
        }

        // Conjunto vacunados con AstraZeneca (75)
        HashSet<string> astraZeneca = new HashSet<string>();

        for (int i = 51; i <= 125; i++)
        {
            astraZeneca.Add($"Ciudadano {i}");
        }

        // Unión: P ∪ A
        HashSet<string> unionVacunados = new HashSet<string>(pfizer);
        unionVacunados.UnionWith(astraZeneca);

        // No vacunados: U - (P ∪ A)
        HashSet<string> noVacunados = new HashSet<string>(ciudadanos);
        noVacunados.ExceptWith(unionVacunados);

        // Ambas dosis: P ∩ A
        HashSet<string> ambasDosis = new HashSet<string>(pfizer);
        ambasDosis.IntersectWith(astraZeneca);

        // Solo Pfizer: P - A
        HashSet<string> soloPfizer = new HashSet<string>(pfizer);
        soloPfizer.ExceptWith(astraZeneca);

        // Solo AstraZeneca: A - P
        HashSet<string> soloAstra = new HashSet<string>(astraZeneca);
        soloAstra.ExceptWith(pfizer);

        // Mostrar resultados
        Console.WriteLine("Ciudadanos no vacunados: " + noVacunados.Count);
        Console.WriteLine("Ciudadanos con ambas dosis: " + ambasDosis.Count);
        Console.WriteLine("Ciudadanos solo Pfizer: " + soloPfizer.Count);
        Console.WriteLine("Ciudadanos solo AstraZeneca: " + soloAstra.Count);

        Console.ReadLine();
    }
}