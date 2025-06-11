using System.ComponentModel;

namespace Linked_List_exercices;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}

public class Node<T>
{
    public T? Value { get; set; }
    public Node<T>? NextValue { get; set; }
    public Node(T value)
    {
        this.Value = value;
        this.NextValue = null;
    }
}

public class LinkedList<T> where T : IComparable<T>
{
    private Node<T>? __head;
    public int Counter { get; private set; }
    public T? MaxValue { get; private set; }
    public LinkedList()
    {
        this.__head = null;
    }

    public void Add(T value) // O(n)
    {
        Node<T> newNode = new Node<T>(value);

        if (this.__head == null)
        {
            __head = newNode;
        }
        else
        {
            var current = this.__head;
            while (current.NextValue != null)
            {
                current = current.NextValue;
            }
            current.NextValue = newNode;
        }
    }

    public int Size() // O(n)
    {
        int counter = 0;
        var current = this.__head;
        while (current != null)
        {
            counter++;
            current = current.NextValue;
        }
        return counter;
    }

    //complexité trop grande => LIFO 

    public void Stack(T value)
    {
        Node<T> nextValue = new Node<T>(value);
        Node<T>? tmp = this.__head;
        this.__head = nextValue;
        nextValue.NextValue = tmp;
        this.Counter++;
        if (this.__head.Value != null && (this.MaxValue == null || this.__head.Value.CompareTo(this.MaxValue) > 0))
        {
            this.MaxValue = this.__head.Value;
        } //conditions à modifier
    }// O(1)

    public int Count()
    {
        return this.Counter;
    }// O(1)

    //méthode Drop permettant LIFO
    public void Drop()
    {
        if (this.__head != null)
        {
            this.__head = this.__head.NextValue;
            this.Counter--;
        }
    }// O(1)

    //méthode Pop permettant de supprimer le last in et de le récupérer
    public T Pop()
    {
        if (this.__head == null)
        {
            throw new InvalidOperationException("LinkedList vide");
        }
        if (this.__head!.Value == null)
        {
            throw new InvalidOperationException("Node value is null");
        }
        // ajout de si valeur de pop = max => GetMax();
        T value = this.__head.Value;
        this.__head = this.__head.NextValue;
        this.Counter--;
        return value;
    }// O(1)

    public T? GetMax()
    {
        if (this.__head == null)
        {
            throw new InvalidOperationException("LinkedList vide");
        }
        if (this.__head.NextValue != null)
        {
            T? value = this.__head.Value;
            Node<T> current = this.__head.NextValue;
            while (current != null && current.NextValue != null && current.NextValue.Value != null)
            {
                if (current.Value != null && current.Value.CompareTo(value) > 0)
                {
                    value = current.Value;
                }
                current = current.NextValue;
            }
            return current != null ? current.Value : value;
        }
        return this.__head.Value;
    }
}// O(n)
