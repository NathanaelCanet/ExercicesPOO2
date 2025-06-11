using System.Linq;

namespace Exercices_Linq1;

class Produit
{
    public string Nom { get; set; }
    public decimal Prix { get; set; }
    public int Stock { get; set; }
}

class Program
{
    static void Main(string[] args)
    {

        List<Produit> produits = new List<Produit>
        {
            new Produit { Nom = "Ordinateur portable", Prix = 999.99m, Stock = 5 },
            new Produit { Nom = "Smartphone", Prix = 699.99m, Stock = 0 },
            new Produit { Nom = "Écouteurs sans fil", Prix = 159.99m, Stock = 12 },
            new Produit { Nom = "Tablette", Prix = 449.99m, Stock = 0 },
            new Produit { Nom = "Clavier gaming", Prix = 89.99m, Stock = 8 },
            new Produit { Nom = "Souris", Prix = 49.99m, Stock = 0 },
            new Produit { Nom = "Moniteur 4K", Prix = 399.99m, Stock = 3 }
        };

        var produitsTri = produits.Where(produit => produit.Stock == 0).OrderByDescending(produit => produit.Prix).Select(produit => produit.Nom);
        foreach (string produit in produitsTri)
        {
            Console.WriteLine(produit);
        }
    }
}
/*
Filtrer et trier des éléments
class Produit
{
    public string Nom { get; set; }
    public decimal Prix { get; set; }
    public int Stock { get; set; }
}
Afficher la liste des noms des produits dont Stock == 0 , triés du plus cher
au moins cher.
*/