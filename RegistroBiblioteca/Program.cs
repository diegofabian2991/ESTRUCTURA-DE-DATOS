using System;
using System.Collections.Generic;

class Libro
{
    public string ISBN { get; set; }
    public string Titulo { get; set; }
    public string Autor { get; set; }

    public Libro(string isbn, string titulo, string autor)
    {
        ISBN = isbn;
        Titulo = titulo;
        Autor = autor;
    }

    public override string ToString()
    {
        return $"ISBN: {ISBN} | Título: {Titulo} | Autor: {Autor}";
    }
}

class Biblioteca
{
    private HashSet<string> conjuntoISBN = new HashSet<string>();
    private Dictionary<string, Libro> mapaLibros = new Dictionary<string, Libro>();

    public void AgregarLibro()
    {
        Console.Write("Ingrese ISBN: ");
        string isbn = Console.ReadLine();

        if (!conjuntoISBN.Add(isbn))
        {
            Console.WriteLine("⚠ Error: El ISBN ya está registrado.");
            return;
        }

        Console.Write("Ingrese Título: ");
        string titulo = Console.ReadLine();

        Console.Write("Ingrese Autor: ");
        string autor = Console.ReadLine();

        Libro libro = new Libro(isbn, titulo, autor);
        mapaLibros.Add(isbn, libro);

        Console.WriteLine("✔ Libro agregado correctamente.\n");
    }

    public void ConsultarLibro()
    {
        Console.Write("Ingrese ISBN a consultar: ");
        string isbn = Console.ReadLine();

        if (mapaLibros.ContainsKey(isbn))
        {
            Console.WriteLine("\nLibro encontrado:");
            Console.WriteLine(mapaLibros[isbn]);
        }
        else
        {
            Console.WriteLine("❌ Libro no encontrado.");
        }
        Console.WriteLine();
    }

    public void ListarLibros()
    {
        if (mapaLibros.Count == 0)
        {
            Console.WriteLine("No hay libros registrados.\n");
            return;
        }

        Console.WriteLine("\n--- LISTADO DE LIBROS ---");
        foreach (var libro in mapaLibros.Values)
        {
            Console.WriteLine(libro);
        }

        Console.WriteLine("\n--- REPORTE GENERAL ---");
        Console.WriteLine($"Total de libros registrados: {mapaLibros.Count}");

        Console.WriteLine("\n--- CONJUNTO DE ISBN REGISTRADOS ---");
        foreach (var isbn in conjuntoISBN)
        {
            Console.WriteLine(isbn);
        }

        Console.WriteLine();
    }
}   // 👈 ESTA LLAVE CIERRA LA CLASE Biblioteca

class Program
{
    static void Main()
    {
        Biblioteca biblioteca = new Biblioteca();
        int opcion;

        do
        {
            Console.WriteLine("===== SISTEMA DE BIBLIOTECA =====");
            Console.WriteLine("1. Agregar libro");
            Console.WriteLine("2. Consultar libro");
            Console.WriteLine("3. Listar libros");
            Console.WriteLine("4. Salir");
            Console.Write("Seleccione una opción: ");

            if (!int.TryParse(Console.ReadLine(), out opcion))
            {
                Console.WriteLine("Entrada inválida.\n");
                continue;
            }

            Console.WriteLine();

            switch (opcion)
            {
                case 1:
                    biblioteca.AgregarLibro();
                    break;
                case 2:
                    biblioteca.ConsultarLibro();
                    break;
                case 3:
                    biblioteca.ListarLibros();
                    break;
                case 4:
                    Console.WriteLine("Saliendo del sistema...");
                    break;
                default:
                    Console.WriteLine("Opción inválida.\n");
                    break;
            }

        } while (opcion != 4);
    }
}