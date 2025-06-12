using System.Collections.Generic;
namespace Exercices_PrincipesSOLID1;

class Program
{
    //S
    public class RapportDeVente{
        public void calculerTotalVentes(){}
    }
    public class RapportImpression{
        public void imprimerRapport(){}
    }
    //O
    //classe typeClient aussi possible
    
    public class Facture{
        private Dictionary<string, double> typeClient = 
        new Dictionary<string,double>(){
        {"Standard",30},
        {"Premium",50}
            
        };
        public double appliquerReduction(double montant, string typeClientNom){
            //peut se faire avec le nom du client
            return montant * (1-typeClient[typeClientNom]/100);
        }
    }
    //L
    // Pingouin ne sait pas voler => pour ne pas altérer si on stocker Pingouin dans Oiseau
    public class Oiseau{
        public void voler(){
            //opérations etc tout ce que tu veux
            Console.WriteLine("Je peux voler");
        }
    }
    
    public class Pingouin : Oiseau{
        public void voler(){
            Console.WriteLine("Je ne peux pas voler");
        }
    }
    //I
    public interface IImprimeur{
        void Imprimer();
    }
    public interface IScanneur{
        void Scanner();
    }
    public interface IFaxeur{
        void Faxer();
    }
    public class ImprimanteBasique : IImprimeur{
        public void Imprimer(){
            
        }
    }
    //D
    public interface IMoyenDePaiement{
        void paiementMessage();
    }
    
    public class PaiementParCarte{
        public void paiementMessage(){
            Console.WriteLine("Carte");
        }
    }
    
    public class GestionCommande{
        private IMoyenDePaiement moyenDePaiement;
        public GestionCommande(IMoyenDePaiement moyenDePaiement){
            this.moyenDePaiement = moyenDePaiement;
        }
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}
/* 
✅ S — Single Responsibility Principle (SRP)
Exercice :
Crée une classe RapportDeVente qui contient les ventes journalières. Elle a deux méthodes :

calculerTotalVentes()

imprimerRapport()

Tâche :
Identifie et sépare les responsabilités de cette classe.

✅ O — Open/Closed Principle (OCP)
Exercice :
Tu as une classe Facture qui applique une réduction en fonction du type de client (Standard, Premium).

Tâche :
Refactorer la classe pour qu’on puisse ajouter de nouveaux types de clients avec des règles de réduction différentes sans modifier la classe existante.

✅ L — Liskov Substitution Principle (LSP)
Exercice :
Tu as une classe Oiseau avec une méthode voler(). Puis, une sous-classe Pingouin qui hérite de Oiseau.

Tâche :
Explique pourquoi cela viole LSP et propose une solution.

✅ I — Interface Segregation Principle (ISP)
Exercice :
Tu as une interface IMachine avec les méthodes :

imprimer()

scanner()

faxer()

Une classe ImprimanteBasique implémente cette interface mais n’a besoin que de imprimer().

Tâche :
Refactorer l’interface pour respecter ISP.

✅ D — Dependency Inversion Principle (DIP)
Exercice :
Une classe GestionCommande utilise une classe concrète PaiementCarteBleue pour effectuer le paiement.

Tâche :
Refactorer la classe pour qu’elle dépende d’une abstraction (ex : interface MoyenPaiement) plutôt que d’une classe concrète.
*/
