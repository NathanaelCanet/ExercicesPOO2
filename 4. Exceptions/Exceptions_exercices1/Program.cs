namespace Exceptions_exercices1;

public class OverLimitException : Exception
{
    public OverLimitException(string message) : base(message) { }
}

public class SubLimitException : Exception
{
    public SubLimitException(string message) : base(message) { }
}

public class NotIntegerException : Exception
{
    public NotIntegerException(string message) : base(message) { }
}

public class MauvaiseCalculatrice
{
    private int minValue = 0;
    private int maxValue = 9999;

    public void ValidValues(int a, int b, int result)
    {
        if (a < this.minValue || b < this.minValue || result < this.minValue)
        {
            throw new SubLimitException("En dessous de la limite");
        }
        if (a > this.maxValue || b > this.maxValue || result > this.maxValue)
        {
            throw new OverLimitException("Au dessus de la limite");
        }
    }

    public int Division(int a, int b)
    {
        if (a % b != 0)
        {
            throw new NotIntegerException("Divison non entière");
        }
        int result;
        try
        {
            result = a / b;
        }
        catch (DivideByZeroException _ex)
        {
            result = 42;
        }
        ValidValues(a, b, result);
        return result;
    }
}
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}

/*
On vous demande d'implémenter une mauvaise calculatrice en C#. Cettecalculatrice supporte les opérations suivantes : + , - ,*, / .
Règles de la calculatrice
Limites des valeurs
- Aucune valeur (entrée ou résultat) ne peut dépasser 9999.
- Aucune valeur (entrée ou résultat) ne peut être inférieure à 0.
- Si le résultat de la division n'est pas un entier, l'opération est interdite.
- Si une division par zéro est tentée, la calculatrice doit retourner 42.
Gestion des erreurs
- Utilisez des exceptions pour gérer les cas d'erreur (valeurs hors limites,division non entière, etc.).
*/
