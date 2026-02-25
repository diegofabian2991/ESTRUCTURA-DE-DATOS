using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class Traductor
{
    static void Main()
    {
        // Diccionario Español → Inglés
        Dictionary<string, string> diccionario = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
        {
            {"tiempo", "time"}, {"persona", "person"}, {"año", "year"}, {"camino", "way"},
            {"dia", "day"}, {"cosa", "thing"}, {"hombre", "man"}, {"mundo", "world"},
            {"vida", "life"}, {"mano", "hand"}, {"parte", "part"}, {"niño", "child"},
            {"ojo", "eye"}, {"mujer", "woman"}, {"lugar", "place"}, {"trabajo", "work"},
            {"semana", "week"}, {"caso", "case"}, {"tema", "point"}, {"gobierno", "government"},
            {"empresa", "company"}
        };

        int opcion = -1;

        while (opcion != 0)
        {
            Console.WriteLine("==================== MENÚ ====================");
            Console.WriteLine("1. Traducir una frase");
            Console.WriteLine("2. Agregar palabras al diccionario");
            Console.WriteLine("0. Salir");
            Console.Write("Seleccione una opción: ");

            if (!int.TryParse(Console.ReadLine(), out opcion))
            {
                Console.WriteLine("Por favor ingrese un número válido.\n");
                continue;
            }

            switch (opcion)
            {
                case 1:
                    TraducirFrase(diccionario);
                    break;

                case 2:
                    AgregarPalabra(diccionario);
                    break;

                case 0:
                    Console.WriteLine("Saliendo del programa...");
                    break;

                default:
                    Console.WriteLine("Opción no válida.\n");
                    break;
            }
        }
    }

    static void TraducirFrase(Dictionary<string, string> diccionario)
    {
        Console.Write("\nIngrese la frase a traducir: ");
        string frase = Console.ReadLine();

        string resultado = Regex.Replace(frase, @"\b\w+\b", match =>
        {
            string palabra = match.Value.ToLower();

            if (diccionario.ContainsKey(palabra))
                return diccionario[palabra];

            return match.Value; // mantiene palabra original si no existe
        });

        Console.WriteLine($"\nTraducción parcial: {resultado}\n");
    }

    static void AgregarPalabra(Dictionary<string, string> diccionario)
    {
        Console.Write("\nIngrese la palabra en español: ");
        string espanol = Console.ReadLine().Trim().ToLower();

        Console.Write("Ingrese la traducción en inglés: ");
        string ingles = Console.ReadLine().Trim().ToLower();

        if (diccionario.ContainsKey(espanol))
        {
            Console.WriteLine("La palabra ya existe en el diccionario.\n");
        }
        else
        {
            diccionario.Add(espanol, ingles);
            Console.WriteLine($"Palabra '{espanol}' agregada correctamente.\n");
        }
    }
}