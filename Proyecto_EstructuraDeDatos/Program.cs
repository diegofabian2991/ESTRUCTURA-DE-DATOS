using System;
using System.Collections.Generic;

namespace Proyecto_EstructuraDeDatos
{
    class Persona
    {
        public string Nombre { get; set; }
        public int Turno { get; set; }

        public Persona(string nombre, int turno)
        {
            Nombre = string.IsNullOrWhiteSpace(nombre) ? $"Persona {turno}" : nombre;
            Turno = turno;
        }
    }

    class Atraccion
    {
        private Persona[] Asientos;
        private int TotalAsientos;

        public Atraccion(int totalAsientos)
        {
            TotalAsientos = totalAsientos;
            Asientos = new Persona[totalAsientos];
        }

        public bool SubirPersona(Persona p)
        {
            for (int i = 0; i < TotalAsientos; i++)
            {
                if (Asientos[i] == null)
                {
                    Asientos[i] = p;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"{p.Nombre} se sentó en el asiento {i + 1}");
                    Console.ResetColor();
                    return true;
                }
            }
            return false;
        }

        public void MostrarAsientos()
        {
            Console.WriteLine("\n=== Estado final de los asientos ===");
            for (int i = 0; i < TotalAsientos; i++)
            {
                string ocupante = Asientos[i]?.Nombre ?? "Libre";
                Console.ForegroundColor = Asientos[i] != null ? ConsoleColor.Green : ConsoleColor.Gray;
                Console.Write($"[{i + 1}:{ocupante}] ".PadRight(20));
                Console.ResetColor();
                if ((i + 1) % 6 == 0)
                    Console.WriteLine();
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Simulación de asignación de 30 asientos en orden de llegada ===\n");

            Queue<Persona> cola = new Queue<Persona>();
            int numeroDePersonas = 35;

            Console.WriteLine("Ingrese los nombres de las personas (dejar vacío para nombre automático):\n");
            for (int i = 1; i <= numeroDePersonas; i++)
            {
                Console.Write($"Nombre persona {i}: ");
                string nombre = Console.ReadLine();
                cola.Enqueue(new Persona(nombre, i));
            }

            Console.WriteLine("\n=== Cola de espera ===");
            foreach (var persona in cola)
            {
                Console.Write($"{persona.Nombre} ");
            }
            Console.WriteLine("\n");

            Atraccion montanaRusa = new Atraccion(30);
            List<Persona> personasFuera = new List<Persona>();

            while (cola.Count > 0)
            {
                Persona p = cola.Dequeue();
                bool subio = montanaRusa.SubirPersona(p);
                if (!subio)
                    personasFuera.Add(p);
            }

            montanaRusa.MostrarAsientos();

            Console.WriteLine($"\nPersonas que no pudieron subir: {personasFuera.Count}");
            if (personasFuera.Count > 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Nombres de las personas que no subieron:");
                foreach (var p in personasFuera)
                {
                    Console.WriteLine($"- {p.Nombre}");
                }
                Console.ResetColor();
            }

            Console.WriteLine("\nSimulación finalizada. Presione cualquier tecla para salir.");
            Console.ReadKey();
        }
    }
}