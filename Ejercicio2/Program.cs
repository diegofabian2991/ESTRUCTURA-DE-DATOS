using System;
using System.Collections.Generic;

class Curso
{
    private List<string> asignaturas;

    public Curso()
    {
        asignaturas = new List<string>
        {
            "Matemáticas",
            "Física",
            "Química",
            "Historia",
            "Lengua"
        };
    }

    public void MostrarAsignaturas()
    {
        foreach (string asignatura in asignaturas)
        {
            Console.WriteLine($"Yo estudio {asignatura}");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Curso curso = new Curso();
        curso.MostrarAsignaturas();

        Console.ReadLine();
    }
}