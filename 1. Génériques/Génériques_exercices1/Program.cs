using System.ComponentModel.DataAnnotations;

namespace Génériques_exercices;
//1
public class Box<T>
{
    public T? Value { get; set; }

    public void Display()
    {
        Console.WriteLine(this.Value);
    }
}

//3
public class Comparer<T> where T : IComparable<T>
{
    public bool IsGreaterThan(T a, T b)
    {
        if (a.CompareTo(b) > 0)
        {
            return true;
        }
        return false;
    }
}

//4 
public class MyList<T>
{
    private List<T> values = new List<T>();
    public void Add(T item)
    {
        this.values.Add(item);
    }

    public T? Get(int index)
    {
        return this.values[index];
    }
}
//5

public interface IStorage<T>
{
    void Store(T item);
}

public class MemoryStorage<T> : IStorage<T>
{
    private List<T> values = new List<T>();
    public void Store(T item)
    {
        this.values.Add(item);
    }

}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }

    //2
    public static void Swap<T>(ref T a, ref T b)
    {
        var temp = a;
        a = b;
        b = temp;
    }
}

/* 
✅ Exercice 1 : Créer une classe générique "Box"
Objectif : Comprendre la syntaxe d'une classe générique.

Consigne :
Crée une classe générique Box<T> avec une propriété Value de type T. Ajoute une méthode Display() qui affiche la valeur.



✅ Exercice 2 : Méthode générique "Swap"
Objectif : Manipuler des méthodes génériques.

Consigne :
Écris une méthode générique Swap<T>(ref T a, ref T b) qui échange deux variables de n'importe quel type.



✅ Exercice 3 : Générique avec contrainte
Objectif : Utiliser des contraintes de type.

Consigne :
Crée une classe générique Comparer<T> avec une méthode IsGreaterThan(T a, T b) qui retourne true si a > b. 
Ajoute une contrainte pour que T implémente IComparable<T>.



✅ Exercice 4 : Liste personnalisée générique
Objectif : Créer une collection personnalisée.

Consigne :
Crée une classe MyList<T> avec une méthode Add(T item) et une méthode Get(int index) pour accéder à un élément.



✅ Exercice 5 : Interface générique
Objectif : Apprendre à créer et implémenter des interfaces génériques.

Consigne :
Déclare une interface IStorage<T> avec une méthode void Store(T item). 
Implémente-la dans une classe MemoryStorage<T> qui stocke les éléments dans une liste.
*/
