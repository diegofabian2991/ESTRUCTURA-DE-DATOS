using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        // 1️⃣ Conjunto universal: 500 ciudadanos
        HashSet<string> ciudadanos = new HashSet<string>();

        for (int i = 1; i <= 500; i++)
        {
            ciudadanos.Add($"Ciudadano {i}");
        }

        // 2️⃣ 75 vacunados con Pfizer
        HashSet<string> pfizer = new HashSet<string>();
        for (int i = 1; i <= 75; i++)
        {
            pfizer.Add($"Ciudadano {i}");
        }

        // 3️⃣ 75 vacunados con AstraZeneca
        HashSet<string> astraZeneca = new HashSet<string>();
        for (int i = 50; i < 125; i++)
        {
            astraZeneca.Add($"Ciudadano {i}");
        }

        // 🔹 Operaciones de conjuntos

        // Unión P ∪ A
        HashSet<string> unionVacunados = new HashSet<string>(pfizer);
        unionVacunados.UnionWith(astraZeneca);

        // Intersección P ∩ A (ambas dosis)
        HashSet<string> ambasDosis = new HashSet<string>(pfizer);
        ambasDosis.IntersectWith(astraZeneca);

        // No vacunados U - (P ∪ A)
        HashSet<string> noVacunados = new HashSet<string>(ciudadanos);
        noVacunados.ExceptWith(unionVacunados);

        // Solo Pfizer P - A
        HashSet<string> soloPfizer = new HashSet<string>(pfizer);
        soloPfizer.ExceptWith(astraZeneca);

        // Solo AstraZeneca A - P
        HashSet<string> soloAstra = new HashSet<string>(astraZeneca);
        soloAstra.ExceptWith(pfizer);

        // 📊 Resultados
        Console.WriteLine($"Total ciudadanos: {ciudadanos.Count}");
        Console.WriteLine($"Vacunados Pfizer: {pfizer.Count}");
        Console.WriteLine($"Vacunados AstraZeneca: {astraZeneca.Count}");
        Console.WriteLine($"Ambas dosis: {ambasDosis.Count}");
        Console.WriteLine($"Solo Pfizer: {soloPfizer.Count}");
        Console.WriteLine($"Solo AstraZeneca: {soloAstra.Count}");
        Console.WriteLine($"No vacunados: {noVacunados.Count}");
    }
}