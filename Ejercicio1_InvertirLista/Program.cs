using System;

class Program
{
    static void Main()
    {
        ListaEnlazada lista = new ListaEnlazada();

        lista.Insertar(1);
        lista.Insertar(2);
        lista.Insertar(3);
        lista.Insertar(4);
        lista.Insertar(5);
        lista.Insertar(6);
        lista.Insertar(7);
        lista.Insertar(8);
        lista.Insertar(9);
        lista.Insertar(10);

        Console.WriteLine("Lista original:");
        lista.Mostrar();

        lista.Invertir();

        Console.WriteLine("\nLista invertida:");
        lista.Mostrar();
    }
}