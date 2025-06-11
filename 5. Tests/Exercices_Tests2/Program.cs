namespace Exercices_Tests2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }

    public class QuantiteTropEleveeException : Exception
    {
        public QuantiteTropEleveeException(string message) : base(message) { }
    }

    public class ProduitNonTrouveException : Exception
    {
        public ProduitNonTrouveException(string message) : base(message) { }
    }

    public class QuantiteInsuffisanteException : Exception
    {
        public QuantiteInsuffisanteException(string message) : base(message) { }
    }
    // PAS DE GESTION DE QUANTITE < 0, PRISE EN COMPTE DANS LES TESTS
    public class GestionStock
    {
        private int __quantiteMax = 100;
        private Dictionary<string, int> produits = new Dictionary<string, int>();

        public void AjouterProduit(string nom, int quantite)
        {
            if (!produits.ContainsKey(nom))
            {
                if (quantite <= __quantiteMax) {
                    produits.Add(nom, quantite);
                }
                else
                {
                    throw new QuantiteTropEleveeException($"Quantitée au dessus de la limite : {__quantiteMax}");
                }
            }
            else if (produits[nom] >= __quantiteMax || (produits[nom] + quantite) > __quantiteMax)
            {
                throw new QuantiteTropEleveeException($"Quantitée au dessus de la limite : {__quantiteMax}");
            }
            else
            {
                produits[nom] += quantite;
            }
        }

        public void RetirerProduit(string nom, int quantite)
        {
            if (!produits.ContainsKey(nom))
            {
                throw new ProduitNonTrouveException("Produit pas trouvé");
            }
            else if (produits[nom] < quantite)
            {
                throw new QuantiteInsuffisanteException("Quantité à retirer trop élevée");
            }
            else
            {
                produits[nom] -= quantite;
            }
        }

        public int GetQuantite(string nom)
        {
            if (produits.ContainsKey(nom))
            {
                return produits[nom];
            }
            return 0;
        }
    }

}
