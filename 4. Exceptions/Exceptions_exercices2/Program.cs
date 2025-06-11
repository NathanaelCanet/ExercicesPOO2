namespace Exceptions_exercices2;

public class SoldeNegatifException : Exception
{
    public SoldeNegatifException(string message) : base(message) { }
}

public class SoldeTropGrandException : Exception
{
    public SoldeTropGrandException(string message) : base(message) { }
}

public class RetraitNullException : Exception
{
    public RetraitNullException(string message) : base(message) { }
}

public class RetraitNegatifException : Exception
{
    public RetraitNegatifException(string message) : base(message) { }
}

public class DepotNegatifException : Exception
{
    public DepotNegatifException(string message) : base(message) { }
}

public class CompteBancaire {
    private double __solde;
    private double __maxValue;

    public void Depot(double montant)
    {
        if (montant < 0)
        {
            throw new DepotNegatifException("Dépot négatif");
        }
        if (this.__solde + montant > this.__maxValue)
        {
            throw new SoldeTropGrandException("Solde trop grand");
        }

        this.__solde += montant;
    }

    public void Retrait(double montant)
    {
        if (montant < 0)
        {
            throw new RetraitNegatifException("Retrait doit être négatif");
        }

        if (montant == 0)
        {
            throw new RetraitNullException("Montant = 0");
        }

        if (this.__solde - montant < 0) {
            throw new SoldeNegatifException("Solde négatif");
        }
        this.__solde -= montant;
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
Vous devez implémenter une classe CompteBancaire qui représente un
compte bancaire avec les fonctionnalités suivantes :
- Dépôt : Ajouter de l'argent au compte.
- Retrait : Retirer de l'argent du compte.
- Solde : Consulter le solde actuel.
Limites du compte
- Le solde ne peut jamais être négatif.
- Le solde ne peut jamais dépasser 10 000 €.
- Si un retrait de 0€ est effectué, une exception doit être levée.
*/
