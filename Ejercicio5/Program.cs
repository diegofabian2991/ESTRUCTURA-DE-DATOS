using System;
using System.Collections.Generic;

class ListaNumeros
{
    private List<int> numeros;

    public ListaNumeros()
    {
        numeros = new List<int>();
        for (int i = 1; i <= 10; i++)
        {
            numeros.Add(i);
        }
    }

    public void MostrarInverso()
    {
        for (int i = numeros.Count - 1; i >= 0; i--)
        {
            Console.Write(numeros[i]);

            if (i != 0)
            {
                Console.Write(", ");
            }
        }
        Console.WriteLine();
    }
}

class Program
{
    static void Main(string[] args)
    {
        ListaNumeros lista = new ListaNumeros();
        lista.MostrarInverso();

        Console.ReadLine();
    }
}