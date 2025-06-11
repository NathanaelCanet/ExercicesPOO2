namespace Exercices_Linq4;
class Produit
{
    public string Code { get; set; }
    public string Nom { get; set; }
}
class Program
{
    static void Main(string[] args)
    {

        List<Produit> produits = new List<Produit>
        {
            new Produit { Code = "P001", Nom = "Ordinateur portable" },
            new Produit { Code = "P002", Nom = "Souris sans fil" },
            new Produit { Code = "P003", Nom = "Clavier mécanique" },
            new Produit { Code = "P004", Nom = "Écran 27 pouces" },
            new Produit { Code = "P005", Nom = "Webcam HD" }
        };

        Dictionary<string, Produit> produitsDictionary = produits.ToDictionary(p => p.Code);

        foreach (var produit in produitsDictionary)
        {
            Console.WriteLine($"Clé: {produit.Key}, Valeur: {produit.Value.Nom}");
        }
    }
}
/*
Création d’un dictionnaire
class Produit
{
    public string Code { get; set; }
    public string Nom { get; set; }
}
Créer un dictionnaire Dictionary<string, Produit> avec Code comme clé.
*/