using System;

class Palindromo
{
    public bool EsPalindromo(string palabra)
    {
        palabra = palabra.ToLower();
        int inicio = 0;
        int fin = palabra.Length - 1;

        while (inicio < fin)
        {
            if (palabra[inicio] != palabra[fin])
            {
                return false;
            }
            inicio++;
            fin--;
        }

        return true;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Ingrese una palabra: ");
        string palabra = Console.ReadLine();

        Palindromo verificador = new Palindromo();

        if (verificador.EsPalindromo(palabra))
        {
            Console.WriteLine("La palabra es un palíndromo.");
        }
        else
        {
            Console.WriteLine("La palabra no es un palíndromo.");
        }

        Console.ReadLine();
    }
}