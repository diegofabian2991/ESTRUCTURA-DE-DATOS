using System;

public class ListaEnlazada
{
    private Nodo? cabeza;

    public ListaEnlazada()
    {
        cabeza = null;
    }

    // a) Agregar estudiante
    public void Agregar(Estudiante estudiante)
    {
        Nodo nuevo = new Nodo(estudiante);

        if (cabeza == null)
        {
            cabeza = nuevo;
            return;
        }

        if (estudiante.Aprobado())
        {
            // Insertar al inicio
            nuevo.Siguiente = cabeza;
            cabeza = nuevo;
        }
        else
        {
            // Insertar al final
            Nodo actual = cabeza;
            while (actual.Siguiente != null)
            {
                actual = actual.Siguiente;
            }
            actual.Siguiente = nuevo;
        }
    }

    // b) Buscar por cédula
    public Estudiante? Buscar(string cedula)
    {
        Nodo? actual = cabeza;
        while (actual != null)
        {
            if (actual.Dato.Cedula == cedula)
                return actual.Dato;

            actual = actual.Siguiente;
        }
        return null;
    }

    // c) Eliminar estudiante
    public bool Eliminar(string cedula)
    {
        if (cabeza == null) return false;

        if (cabeza.Dato.Cedula == cedula)
        {
            cabeza = cabeza.Siguiente;
            return true;
        }

        Nodo actual = cabeza;
        while (actual.Siguiente != null)
        {
            if (actual.Siguiente.Dato.Cedula == cedula)
            {
                actual.Siguiente = actual.Siguiente.Siguiente;
                return true;
            }
            actual = actual.Siguiente;
        }
        return false;
    }

    // d) Total aprobados
    public int TotalAprobados()
    {
        int contador = 0;
        Nodo? actual = cabeza;
        while (actual != null)
        {
            if (actual.Dato.Aprobado())
                contador++;
            actual = actual.Siguiente;
        }
        return contador;
    }

    // e) Total reprobados
    public int TotalReprobados()
    {
        int contador = 0;
        Nodo? actual = cabeza;
        while (actual != null)
        {
            if (!actual.Dato.Aprobado())
                contador++;
            actual = actual.Siguiente;
        }
        return contador;
    }

    // Mostrar lista
    public void Mostrar()
    {
        Nodo? actual = cabeza;
        while (actual != null)
        {
            Console.WriteLine(actual.Dato);
            actual = actual.Siguiente;
        }
    }
}