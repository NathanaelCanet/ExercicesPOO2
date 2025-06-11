namespace Delegates_exercices3;

public enum MyComparison
{
    Less,
    Equal,
    More,
}

public delegate MyComparison DocumentedSortDelegate<T>(T a, T b);
public class MyDataStructure<T> where T : struct
{
    public T[] Values { get; private set; }
    public MyDataStructure(T[] values)
    {
        Values = values;
    }
    public void MyMap(Action<T> f)
    {
        foreach (value in this.Values)
        {
            f(value);
        }
    }
    public MyDataStructure MyFilter(Predicate<T> f)
    {
        List<T> tab = new List<T>();
        foreach (value in this.Values)
        {
            if (f(value))
            {
                tab.Add(value);
            }
        }
        return new MyDataStructure([.. tab]);
    }

    public void Sort(DocumentedSortDelegate<T> f)
    {
        for (int i = 0; i < Values.Length - 1; i++)
        {
            for (int j = i + 1; j < Values.Length; j++)
            {
                MyComparison comp = f(Values[i], Values[j]);
                if (comp == MyComparison.More)
                {
                    (Values[i], Values[j]) = (Values[j], Values[i]);
                }
            }
        }
    }
}
class Program
{
    static void Main(string[] args)
    {
        var data = new MyDataStructure<int>(new int[] { 4, 2, 5, 1 });

        data.MyPreciseSort((a, b) =>
        {
            if (a < b) return MyComparison.Less;
            if (a > b) return MyComparison.More;
            return MyComparison.Equal;
        });
    }
}
/*
Même exercice que précédemment, mais pour une classe MyDataStructure
qui accepte des génériques
filtrer les valeurs à l'aide de Predicate<int>
appliquer Action<int> sur chaque élément de la liste
implémenter une méthode sort qui utilise un delegate en tant que
méthode de tri
Ensuite, utilisez votre classe pour
créer un autre objet MyDataStructure qui ne comprend que les entiers
pairs
afficher chaque élément ainsi que son double
trier les éléments
*/