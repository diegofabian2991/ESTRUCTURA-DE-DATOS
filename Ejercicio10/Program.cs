using System;
using System.Collections.Generic;

class ListaPrecios
{
    private List<int> precios;

    public ListaPrecios()
    {
        precios = new List<int> { 50, 75, 46, 22, 80, 65, 8 };
    }

    public int ObtenerMenor()
    {
        int menor = precios[0];
        foreach (int precio in precios)
        {
            if (precio < menor)
            {
                menor = precio;
            }
        }
        return menor;
    }

    public int ObtenerMayor()
    {
        int mayor = precios[0];
        foreach (int precio in precios)
        {
            if (precio > mayor)
            {
                mayor = precio;
            }
        }
        return mayor;
    }
}

class Program
{
    static void Main(string[] args)
    {
        ListaPrecios lista = new ListaPrecios();

        Console.WriteLine($"El precio menor es: {lista.ObtenerMenor()}");
        Console.WriteLine($"El precio mayor es: {lista.ObtenerMayor()}");

        Console.ReadLine();
    }
}