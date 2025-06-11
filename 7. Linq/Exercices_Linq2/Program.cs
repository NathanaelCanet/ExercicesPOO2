namespace Exercices_Linq2;

class Commande
{
    public string Client { get; set; }
    public decimal Montant { get; set; }
}

class Program
{
    static void Main(string[] args)
    {
        List<Commande> commandes = new List<Commande>
        {
            new Commande { Client = "Alice", Montant = 150.00m },
            new Commande { Client = "Bob", Montant = 75.50m },
            new Commande { Client = "Alice", Montant = 200.00m },
            new Commande { Client = "Charlie", Montant = 120.00m },
            new Commande { Client = "Bob", Montant = 45.99m },
            new Commande { Client = "David", Montant = 95.00m },
            new Commande { Client = "Charlie", Montant = 180.00m }
        };

        decimal montantTotalCommande = commandes.Sum(com => com.Montant);
        int nbClientOver100 = commandes.Where(com => com.Montant > 100).Distinct().Count();

        System.Console.WriteLine(montantTotalCommande);
        System.Console.WriteLine(nbClientOver100);
    }
}
/*
Agréger des données
class Commande
{
    public string Client { get; set; }
    public decimal Montant { get; set; }
}
Calculer le montant total des commandes.
Combien de clients ont passé au moins une commande de plus de 100 €
?
*/