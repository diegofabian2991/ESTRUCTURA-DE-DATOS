using System;
using System.Collections.Generic;

class Asignatura
{
    public string Nombre { get; set; }
    public double Nota { get; set; }

    public Asignatura(string nombre)
    {
        Nombre = nombre;
    }
}

class Curso
{
    private List<Asignatura> asignaturas;

    public Curso()
    {
        asignaturas = new List<Asignatura>
        {
            new Asignatura("Matemáticas"),
            new Asignatura("Física"),
            new Asignatura("Química"),
            new Asignatura("Historia"),
            new Asignatura("Lengua")
        };
    }

    public void PedirNotas()
    {
        foreach (var asignatura in asignaturas)
        {
            Console.Write($"Ingrese la nota de {asignatura.Nombre}: ");
            asignatura.Nota = Convert.ToDouble(Console.ReadLine());
        }
    }

    public void MostrarResultados()
    {
        Console.WriteLine("\nResultados:");
        foreach (var asignatura in asignaturas)
        {
            Console.WriteLine($"En {asignatura.Nombre} has sacado {asignatura.Nota}");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Curso curso = new Curso();
        curso.PedirNotas();
        curso.MostrarResultados();

        Console.ReadLine();
    }
}