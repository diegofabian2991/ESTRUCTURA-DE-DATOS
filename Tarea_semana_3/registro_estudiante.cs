using System;

// Clase que modela los datos de un estudiante
class Estudiante
{
    public int ID;
    public string Nombres;
    public string Apellidos;
    public string Direccion;

    // Arreglo para almacenar los tres números de teléfono
    public string[] Telefonos = new string[3];

    // Método para mostrar la información registrada
    public void MostrarInfo()
    {
        Console.WriteLine("----- Información del Estudiante -----");
        Console.WriteLine("ID: " + ID);
        Console.WriteLine("Nombres: " + Nombres);
        Console.WriteLine("Apellidos: " + Apellidos);
        Console.WriteLine("Dirección: " + Direccion);

        Console.WriteLine("Teléfonos:");
        for (int i = 0; i < Telefonos.Length; i++)
        {
            Console.WriteLine($"Teléfono {i+1}: {Telefonos[i]}");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Crear un nuevo objeto de tipo Estudiante
        Estudiante est = new Estudiante();

        // Captura de datos del usuario
        Console.Write("Ingrese ID: ");
        est.ID = int.Parse(Console.ReadLine());

        Console.Write("Ingrese nombres: ");
        est.Nombres = Console.ReadLine();

        Console.Write("Ingrese apellidos: ");
        est.Apellidos = Console.ReadLine();

        Console.Write("Ingrese dirección: ");
        est.Direccion = Console.ReadLine();

        // Ingreso de los tres teléfonos utilizando un arreglo
        for (int i = 0; i < 3; i++)
        {
            Console.Write($"Ingrese teléfono {i + 1}: ");
            est.Telefonos[i] = Console.ReadLine();
        }

        // Mostrar la información ingresada
        Console.WriteLine("\n");
        est.MostrarInfo();

        Console.WriteLine("\nPresione ENTER para finalizar...");
        Console.ReadLine();
    }
}