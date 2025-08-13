using System;
using System.Collections.Generic;

internal static class TestMethods
{
    
    internal static uint StackFirstPrime(Stack<uint> stack)
    {
        if (stack == null || stack.Count == 0)
            return 0;

        // Se usa una pila auxiliar para no perder los elementos
        Stack<uint> temp = new Stack<uint>();
        uint foundPrime = 0;

        while (stack.Count > 0)
        {
            uint top = stack.Pop();
            temp.Push(top);
            if (foundPrime == 0 && IsPrime(top))
            {
                foundPrime = top;
            }
        }

        // Restaurar la pila original
        while (temp.Count > 0)
        {
            stack.Push(temp.Pop());
        }

        return foundPrime;
    }

    private static bool IsPrime(uint num)
    {
        if (num < 2) return false;
        if (num == 2) return true;
        if (num % 2 == 0) return false;
        for (uint i = 3; i * i <= num; i += 2)
        {
            if (num % i == 0) return false;
        }
        return true;
    }

 
    internal static Stack<uint> RemoveFirstPrime(Stack<uint> stack)
    {
        if (stack == null || stack.Count == 0)
            return stack;

        Stack<uint> temp = new Stack<uint>();
        bool removed = false;

        while (stack.Count > 0)
        {
            uint top = stack.Pop();
            if (!removed && IsPrime(top))
            {
                removed = true;
                continue; // No se guarda, se elimina
            }
            temp.Push(top);
        }

        while (temp.Count > 0)
        {
            stack.Push(temp.Pop());
        }

        return stack;
    }


    internal static Queue<uint> CreateQueueFromStack(Stack<uint> stack)
    {
        Queue<uint> queue = new Queue<uint>();
        if (stack == null || stack.Count == 0)
            return queue;

        // Pila temporal para invertir una vez
        Stack<uint> temp = new Stack<uint>();

        // Pasamos de stack a temp (esto invierte el orden)
        while (stack.Count > 0)
        {
            temp.Push(stack.Pop());
        }

        // Ahora devolvemos los elementos a stack y los añadimos a queue
        while (temp.Count > 0)
        {
            uint val = temp.Pop();
            stack.Push(val);    // restauramos la pila original
            queue.Enqueue(val); // encolamos en el orden correcto
        }

        return queue;
    }



    internal static List<uint> StackToList(Stack<uint> stack)
    {
        List<uint> list = new List<uint>();
        if (stack == null || stack.Count == 0)
            return list;

        Stack<uint> temp = new Stack<uint>();

        // Sacar de la pila a temp (invierte el orden)
        while (stack.Count > 0)
        {
            temp.Push(stack.Pop());
        }

        // Devolver a la pila y llenar lista en el mismo orden
        while (temp.Count > 0)
        {
            uint val = temp.Pop();
            stack.Push(val);  // restauramos la pila
            list.Add(val);    // añadimos a lista respetando orden
        }

        return list;
    }



    internal static bool FoundElementAfterSorted(List<int> list, int number)
    {
        if (list == null || list.Count == 0)
            return false;

        // Ordenamiento manual
        for (int i = 0; i < list.Count - 1; i++)
        {
            for (int j = 0; j < list.Count - i - 1; j++)
            {
                if (list[j] > list[j + 1])
                {
                    int temp = list[j];
                    list[j] = list[j + 1];
                    list[j + 1] = temp;
                }
            }
        }

        // Busqueda lineal
        for (int i = 0; i < list.Count; i++)
        {
            if (list[i] == number)
                return true;
        }
        return false;
    }
}
