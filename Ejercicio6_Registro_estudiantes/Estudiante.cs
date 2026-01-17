public class Estudiante
{
    public string Cedula { get; set; }
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public string Correo { get; set; }
    public double Nota { get; set; }

    public bool Aprobado()
    {
        return Nota >= 7.0;
    }

    public override string ToString()
    {
        return $"{Cedula} | {Nombre} {Apellido} | {Correo} | Nota: {Nota}";
    }
}