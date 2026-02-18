public class Program
{
    public static void Main(string[] args)
    {
        Circulo c = new Circulo(7);
        Console.WriteLine("Círculo:");
        Console.WriteLine("Área: " + c.CalcularArea());
        Console.WriteLine("Perímetro: " + c.CalcularPerimetro());

        Console.WriteLine();

        Rectangulo r = new Rectangulo(5, 8);
        Console.WriteLine("Rectángulo:");
        Console.WriteLine("Área: " + r.CalcularArea());
        Console.WriteLine("Perímetro: " + r.CalcularPerimetro());
    }
}