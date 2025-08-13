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
        if (stack == null || stack.Count == 0) return queue;

        // Enmuerar la pila (de cima a fondo) 
        foreach (uint x in stack)
        {
            queue.Enqueue(x);
        }

        return queue;
    }



    internal static List<uint> StackToList(Stack<uint> stack)
    {
        List<uint> list = new List<uint>();
        if (stack == null || stack.Count == 0) return list;

        // Enumerar la pila (de cima a fondo) y agregar a la lista en ese orden
        foreach (uint x in stack)
        {
            list.Add(x);
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
