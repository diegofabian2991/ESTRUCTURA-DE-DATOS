public class Nodo
{
    public Estudiante Dato;
    public Nodo? Siguiente;

    public Nodo(Estudiante estudiante)
    {
        Dato = estudiante;
        Siguiente = null;
    }
}