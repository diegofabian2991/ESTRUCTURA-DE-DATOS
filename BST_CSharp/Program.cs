using System;

class Nodo
{
    public int Valor;
    public Nodo Izquierdo;
    public Nodo Derecho;

    public Nodo(int valor)
    {
        Valor = valor;
        Izquierdo = Derecho = null;
    }
}

class ArbolBST
{
    public Nodo Raiz;

    // Insertar
    public Nodo Insertar(Nodo nodo, int valor)
    {
        if (nodo == null)
            return new Nodo(valor);

        if (valor < nodo.Valor)
            nodo.Izquierdo = Insertar(nodo.Izquierdo, valor);
        else if (valor > nodo.Valor)
            nodo.Derecho = Insertar(nodo.Derecho, valor);

        return nodo;
    }

    // Buscar
    public bool Buscar(Nodo nodo, int valor)
    {
        if (nodo == null) return false;

        if (valor == nodo.Valor) return true;
        if (valor < nodo.Valor)
            return Buscar(nodo.Izquierdo, valor);
        else
            return Buscar(nodo.Derecho, valor);
    }

    // Mínimo
    public Nodo Minimo(Nodo nodo)
    {
        while (nodo.Izquierdo != null)
            nodo = nodo.Izquierdo;
        return nodo;
    }

    // Eliminar
    public Nodo Eliminar(Nodo nodo, int valor)
    {
        if (nodo == null) return nodo;

        if (valor < nodo.Valor)
            nodo.Izquierdo = Eliminar(nodo.Izquierdo, valor);
        else if (valor > nodo.Valor)
            nodo.Derecho = Eliminar(nodo.Derecho, valor);
        else
        {
            // Caso 1: sin hijos
            if (nodo.Izquierdo == null && nodo.Derecho == null)
                return null;

            // Caso 2: un hijo
            if (nodo.Izquierdo == null)
                return nodo.Derecho;
            else if (nodo.Derecho == null)
                return nodo.Izquierdo;

            // Caso 3: dos hijos
            Nodo temp = Minimo(nodo.Derecho);
            nodo.Valor = temp.Valor;
            nodo.Derecho = Eliminar(nodo.Derecho, temp.Valor);
        }

        return nodo;
    }

    // Recorridos
    public void InOrden(Nodo nodo)
    {
        if (nodo != null)
        {
            InOrden(nodo.Izquierdo);
            Console.Write(nodo.Valor + " ");
            InOrden(nodo.Derecho);
        }
    }

    public void PreOrden(Nodo nodo)
    {
        if (nodo != null)
        {
            Console.Write(nodo.Valor + " ");
            PreOrden(nodo.Izquierdo);
            PreOrden(nodo.Derecho);
        }
    }

    public void PostOrden(Nodo nodo)
    {
        if (nodo != null)
        {
            PostOrden(nodo.Izquierdo);
            PostOrden(nodo.Derecho);
            Console.Write(nodo.Valor + " ");
        }
    }

    // Máximo
    public Nodo Maximo(Nodo nodo)
    {
        while (nodo.Derecho != null)
            nodo = nodo.Derecho;
        return nodo;
    }

    // Altura
    public int Altura(Nodo nodo)
    {
        if (nodo == null) return -1;

        int izq = Altura(nodo.Izquierdo);
        int der = Altura(nodo.Derecho);

        return Math.Max(izq, der) + 1;
    }

    // Limpiar
    public void Limpiar()
    {
        Raiz = null;
    }
}

class Program
{
    static void Main()
    {
        ArbolBST arbol = new ArbolBST();
        int opcion, valor;

        do
        {
            Console.WriteLine("\n--- MENU BST ---");
            Console.WriteLine("1. Insertar");
            Console.WriteLine("2. Buscar");
            Console.WriteLine("3. Eliminar");
            Console.WriteLine("4. Recorridos");
            Console.WriteLine("5. Minimo, Maximo, Altura");
            Console.WriteLine("6. Limpiar arbol");
            Console.WriteLine("0. Salir");
            Console.Write("Opcion: ");
            opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    Console.Write("Valor a insertar: ");
                    valor = int.Parse(Console.ReadLine());
                    arbol.Raiz = arbol.Insertar(arbol.Raiz, valor);
                    break;

                case 2:
                    Console.Write("Valor a buscar: ");
                    valor = int.Parse(Console.ReadLine());
                    Console.WriteLine(arbol.Buscar(arbol.Raiz, valor) ? "Existe" : "No existe");
                    break;

                case 3:
                    Console.Write("Valor a eliminar: ");
                    valor = int.Parse(Console.ReadLine());
                    arbol.Raiz = arbol.Eliminar(arbol.Raiz, valor);
                    break;

                case 4:
                    Console.WriteLine("InOrden:");
                    arbol.InOrden(arbol.Raiz);
                    Console.WriteLine("\nPreOrden:");
                    arbol.PreOrden(arbol.Raiz);
                    Console.WriteLine("\nPostOrden:");
                    arbol.PostOrden(arbol.Raiz);
                    Console.WriteLine();
                    break;

                case 5:
                    if (arbol.Raiz != null)
                    {
                        Console.WriteLine("Minimo: " + arbol.Minimo(arbol.Raiz).Valor);
                        Console.WriteLine("Maximo: " + arbol.Maximo(arbol.Raiz).Valor);
                        Console.WriteLine("Altura: " + arbol.Altura(arbol.Raiz));
                    }
                    else
                        Console.WriteLine("Arbol vacio");
                    break;

                case 6:
                    arbol.Limpiar();
                    Console.WriteLine("Arbol eliminado");
                    break;
            }

        } while (opcion != 0);
    }
}