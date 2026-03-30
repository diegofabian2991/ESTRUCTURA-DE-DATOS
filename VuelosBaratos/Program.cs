using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace VuelosBaratos
{
    class Arista
    {
        public string Destino;
        public int Costo;

        public Arista(string destino, int costo)
        {
            Destino = destino;
            Costo = costo;
        }
    }

    class Grafo
    {
        private Dictionary<string, List<Arista>> listaAdyacencia;

        public Grafo()
        {
            listaAdyacencia = new Dictionary<string, List<Arista>>();
        }

        public void AgregarVuelo(string origen, string destino, int costo)
        {
            if (!listaAdyacencia.ContainsKey(origen))
                listaAdyacencia[origen] = new List<Arista>();

            listaAdyacencia[origen].Add(new Arista(destino, costo));
        }

        public void CargarDesdeArchivo(string ruta)
        {
            if (!File.Exists(ruta))
            {
                Console.WriteLine($"Archivo no encontrado: {ruta}");
                return;
            }

            foreach (var linea in File.ReadAllLines(ruta))
            {
                var partes = linea.Split(',');
                string origen = partes[0].Trim();
                string destino = partes[1].Trim();
                int costo = int.Parse(partes[2].Trim());

                AgregarVuelo(origen, destino, costo);
            }
        }

        public bool ExisteCiudad(string ciudad)
        {
            if (listaAdyacencia.ContainsKey(ciudad))
                return true;

            foreach (var lista in listaAdyacencia.Values)
            {
                foreach (var arista in lista)
                {
                    if (arista.Destino == ciudad)
                        return true;
                }
            }
            return false;
        }

        public void MostrarVuelos()
        {
            foreach (var nodo in listaAdyacencia)
            {
                Console.Write(nodo.Key + " -> ");
                foreach (var arista in nodo.Value)
                {
                    Console.Write($"({arista.Destino}, ${arista.Costo}) ");
                }
                Console.WriteLine();
            }
        }

        public void RutaMasBarata(string inicio, string fin)
        {
            var distancias = new Dictionary<string, int>();
            var anteriores = new Dictionary<string, string>();

            // Inicializar distancias
            foreach (var nodo in listaAdyacencia.Keys)
                distancias[nodo] = int.MaxValue;
            distancias[inicio] = 0;

            var cola = new PriorityQueue<string, int>();
            cola.Enqueue(inicio, 0);

            while (cola.Count > 0)
            {
                var actual = cola.Dequeue();
                if (!listaAdyacencia.ContainsKey(actual))
                    continue;

                foreach (var vecino in listaAdyacencia[actual])
                {
                    int nuevaDistancia = distancias[actual] + vecino.Costo;
                    if (nuevaDistancia < distancias.GetValueOrDefault(vecino.Destino, int.MaxValue))
                    {
                        distancias[vecino.Destino] = nuevaDistancia;
                        anteriores[vecino.Destino] = actual;
                        cola.Enqueue(vecino.Destino, nuevaDistancia);
                    }
                }
            }

            if (!distancias.ContainsKey(fin) || distancias[fin] == int.MaxValue)
            {
                Console.WriteLine("No existe ruta.");
                return;
            }

            Console.WriteLine($"\nCosto mínimo: ${distancias[fin]}");

            List<string> ruta = new List<string>();
            string nodoActual = fin;
            while (nodoActual != null)
            {
                ruta.Add(nodoActual);
                anteriores.TryGetValue(nodoActual, out nodoActual);
            }
            ruta.Reverse();
            Console.WriteLine("Ruta: " + string.Join(" -> ", ruta));
            Console.WriteLine("Número de escalas: " + (ruta.Count - 1));
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Grafo grafo = new Grafo();
            bool cargado = false;
            string rutaArchivo = Path.Combine(AppContext.BaseDirectory, "..\\..\\..\\vuelos.txt"); // Ruta relativa al proyecto

            while (true)
            {
                Console.WriteLine("\n===== SISTEMA DE VUELOS BARATOS =====");
                Console.WriteLine("1. Cargar vuelos desde archivo");
                Console.WriteLine("2. Mostrar vuelos");
                Console.WriteLine("3. Buscar ruta más barata");
                Console.WriteLine("4. Medir tiempo de búsqueda de Quito a Manta");
                Console.WriteLine("0. Salir");

                Console.Write("Opción (número): ");
                string entrada = Console.ReadLine().Trim();

                if (!int.TryParse(entrada, out int opcion))
                {
                    Console.WriteLine("Ingrese un número válido.");
                    continue;
                }

                switch (opcion)
                {
                    case 1:
                        grafo.CargarDesdeArchivo(rutaArchivo);
                        cargado = true;
                        Console.WriteLine("Datos cargados correctamente.");
                        break;

                    case 2:
                        if (cargado)
                            grafo.MostrarVuelos();
                        else
                            Console.WriteLine("Primero carga los datos (opción 1).");
                        break;

                    case 3:
                        if (!cargado)
                        {
                            Console.WriteLine("Carga los datos primero (opción 1).");
                            break;
                        }
                        Console.Write("Ciudad origen: ");
                        string origen = Console.ReadLine().Trim();
                        Console.Write("Ciudad destino: ");
                        string destino = Console.ReadLine().Trim();

                        if (!grafo.ExisteCiudad(origen) || !grafo.ExisteCiudad(destino))
                        {
                            Console.WriteLine("Ciudad no válida. Intente de nuevo.");
                            break;
                        }

                        grafo.RutaMasBarata(origen, destino);
                        break;

                    case 4:
                        if (!cargado)
                        {
                            Console.WriteLine("Carga los datos primero (opción 1).");
                            break;
                        }

                        // Solicitar ciudades al usuario
                        Console.Write("Ciudad origen: ");
                        string origenTiempo = Console.ReadLine().Trim();
                        Console.Write("Ciudad destino: ");
                        string destinoTiempo = Console.ReadLine().Trim();

                        if (!grafo.ExisteCiudad(origenTiempo) || !grafo.ExisteCiudad(destinoTiempo))
                        {
                            Console.WriteLine("Ciudad no válida. Intente de nuevo.");
                            break;
                        }

                        // Medir tiempo
                        Stopwatch sw = new Stopwatch();
                        sw.Start();
                        grafo.RutaMasBarata(origenTiempo, destinoTiempo);
                        sw.Stop();
                        Console.WriteLine($"Tiempo de ejecución: {sw.ElapsedMilliseconds} ms");
                        break;
                        
                        
                        
                        if (!cargado)
                        {
                            Console.WriteLine("Carga los datos primero (opción 1).");
                            break;
                        }

                        Stopwatch sw = new Stopwatch();
                        sw.Start();
                        grafo.RutaMasBarata("Quito", "Manta");
                        sw.Stop();
                        Console.WriteLine($"Tiempo de ejecución: {sw.ElapsedMilliseconds} ms");
                        break;

                    case 0:
                        return;

                    default:
                        Console.WriteLine("Opción no válida. Intente de nuevo.");
                        break;
                }
            }
        }
    }
}