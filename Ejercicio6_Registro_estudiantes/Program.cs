using System;

class Program
{
    static void Main()
    {
        ListaEnlazada lista = new ListaEnlazada();
        int opcion;

        do
        {
            Console.WriteLine("\n--- REDES III - LISTAS ENLAZADAS ---");
            Console.WriteLine("1. Agregar estudiante");
            Console.WriteLine("2. Buscar estudiante por cédula");
            Console.WriteLine("3. Eliminar estudiante");
            Console.WriteLine("4. Total aprobados");
            Console.WriteLine("5. Total reprobados");
            Console.WriteLine("6. Mostrar lista");
            Console.WriteLine("0. Salir");
            Console.Write("Opción: ");
            opcion = int.Parse(Console.ReadLine()!);

            switch (opcion)
            {
                case 1:
                    Estudiante e = new Estudiante();
                    Console.Write("Cédula: ");
                    e.Cedula = Console.ReadLine()!;
                    Console.Write("Nombre: ");
                    e.Nombre = Console.ReadLine()!;
                    Console.Write("Apellido: ");
                    e.Apellido = Console.ReadLine()!;
                    Console.Write("Correo: ");
                    e.Correo = Console.ReadLine()!;
                    Console.Write("Nota (1-10): ");
                    e.Nota = double.Parse(Console.ReadLine()!);

                    lista.Agregar(e);
                    Console.WriteLine("Estudiante agregado correctamente.");
                    break;

                case 2:
                    Console.Write("Ingrese cédula: ");
                    string cedulaBuscar = Console.ReadLine()!;
                    var encontrado = lista.Buscar(cedulaBuscar);
                    Console.WriteLine(encontrado != null ? encontrado.ToString() : "No encontrado");
                    break;

                case 3:
                    Console.Write("Ingrese cédula a eliminar: ");
                    string cedulaEliminar = Console.ReadLine()!;
                    Console.WriteLine(lista.Eliminar(cedulaEliminar)
                        ? "Estudiante eliminado"
                        : "No se encontró el estudiante");
                    break;

                case 4:
                    Console.WriteLine($"Total aprobados: {lista.TotalAprobados()}");
                    break;

                case 5:
                    Console.WriteLine($"Total reprobados: {lista.TotalReprobados()}");
                    break;

                case 6:
                    lista.Mostrar();
                    break;
            }

        } while (opcion != 0);
    }
}