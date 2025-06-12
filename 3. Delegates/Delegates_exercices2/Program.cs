namespace Delegates_exercices2;

public class MyDataStructure
{
    public int[] Values { get; private set; }
    public MyDataStructure(int[] values)
    {
        Values = values;
    }
    public void MyMap(Action<int> f)
    {
        foreach (var value in this.Values)
        {
            f(value);
        }
    }
    public MyDataStructure MyFilter(Predicate<int> f)
    {
        List<int> tab = new List<int>();
        foreach (var value in this.Values)
        {
            if (f(value))
            {
                tab.Add(value);
            }
        }
        return new MyDataStructure([.. tab]);
    }
}
class Program
{
    static void Main(string[] args)
    {
        int[] data = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }
        MyDataStructure myDataStructure = new MyDataStructure(data);
        myDataStructure.MyMap((int element) => Console.WriteLine($"Value is {element} and the action effect is double : {element * 2}");)
        MyDataStructure myDataStructure1 = myDataStructure.MyFilter((int element) => element % 2 == 0);

    }
}
/*
Utilisez les délégués prédéfinis pour permettre à la class MyDataStructure de
fournir une api pour effectuer les actions suivantes:
filtrer les valeurs à l'aide de Predicate<int>
appliquer Action<int> sur chaque élément de la liste
Ensuite, utilisez votre classe pour
créer un autre objet MyDataStructure qui ne comprend que les entiers
pairs
afficher chaque élément ainsi que son double
class MyDataStructure {
    public int[] Values { get; private set; }
    public MyDataStructure(int[] values) {
        Values = values;
    }
    public void MyMap(Action<int> f) { }
    public MyDataStructure MyFilter(Predicate<int> f) { }
}
*/
