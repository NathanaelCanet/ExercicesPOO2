using Exercices_Tests2;
using System.Security.Cryptography.X509Certificates;
namespace Exercices_Tests2.Tests
{
    public class GestionStockFixture
    {
        public GestionStock? Stock {  get; set; }

        public GestionStockFixture()
        {
            Stock = new GestionStock();
            Stock.AjouterProduit("stylo", 50);
            Stock.AjouterProduit("crayon", 100);
        }
    }
    [TestFixture]
    public class Tests
    {
        private GestionStockFixture _fixture = null!;
        private GestionStock _stock = null!;

        [SetUp]
        public void Setup()
        {
            _fixture = new GestionStockFixture();
            _stock = _fixture.Stock!;
        }

        //Ajout produit
        [Test]
        [TestCase("gomme",1)]
        [TestCase("trousse", 50)]
        [TestCase("cahier", 100)]
        public void AjoutProduit_Valide(string nom, int quantite)
        {
            //Arrange

            //Act
            _stock.AjouterProduit(nom, quantite);
            //Assert
            Assert.That(_stock.GetQuantite(nom), Is.EqualTo(quantite));
        }

        [Test]
        [TestCase("gomme", 101)]
        [TestCase("trousse", 120)]
        [TestCase("cahier", 2000)]
        public void AjoutProduit_NonExistant_NonValide(string nom, int quantite)
        {
            Assert.Throws<QuantiteTropEleveeException>(() => _stock.AjouterProduit(nom, quantite));
        }

        [Test]
        [TestCase("stylo", 50)]
        public void AjoutProduit_ExistantValide(string nom, int quantite)
        {
            //Arrange
            var qte = _stock.GetQuantite(nom);
            //Act
            _stock.AjouterProduit(nom, quantite);
            //Assert
            Assert.That(_stock.GetQuantite(nom), Is.EqualTo(qte+quantite));
        }

        [Test]
        [TestCase("stylo", 51)]
        [TestCase("crayon", 1)]
        public void AjoutProduit_ExistantNonValide(string nom, int quantite)
        {
            //Act & Assert
            Assert.Throws<QuantiteTropEleveeException>(() => _stock.AjouterProduit(nom, quantite));
        }

        //Retirer produit
        [Test]
        [TestCase("stylo",20)]
        public void RetirerProduits_ExistantValide(string nom, int quantite)
        {
            //Arrange
            var qteDeBase = _stock.GetQuantite(nom);
            //Act
            _stock.RetirerProduit(nom, quantite);
            //Assert
            Assert.That(_stock.GetQuantite(nom),Is.EqualTo(qteDeBase - quantite));
        }
        
        [Test]
        [TestCase("stylo", 51)]
        public void RetirerProduits_ExistantNonValide(string nom, int quantite)
        {
            //Act & Assert
            Assert.Throws<QuantiteInsuffisanteException>(() => _stock.RetirerProduit(nom, quantite));
        }

        [Test]
        [TestCase("trousse", 50)]
        public void RetirerProduits_NonExistant(string nom, int quantite)
        {
            Assert.Throws<ProduitNonTrouveException>(() => _stock.RetirerProduit(nom, quantite));
        }

        //GetQuantite
        [Test]
        [TestCase("stylo")]
        public void GetQuantite_Existant(string nom)
        {
            Assert.That(_stock.GetQuantite(nom), Is.EqualTo(50));
        }

        [Test]
        [TestCase("Barbecue")]
        public void GetQuantite_NonExistant(string nom)
        {
            Assert.That(_stock.GetQuantite(nom), Is.EqualTo(0));
        }

    }
}