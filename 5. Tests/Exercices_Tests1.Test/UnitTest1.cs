using Exercices_Tests1;
namespace Exercices_Tests1.Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {

        }

        //Division
        [Test]
        [TestCase(10, 2, 5)]
        [TestCase(20, 4, 5)]
        [TestCase(100, 10, 10)]
        public void DivisionValide(int a, int b, int expectedResult)
        {
            //Arrange
            var badCalculator = new MauvaiseCalculatrice();

            //Act
            var result = badCalculator.Division(a, b);

            //Assert
            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        [TestCase(5, 2)]
        [TestCase(10, 3)]
        [TestCase(21, 4)]
        public void DivisionNonValide_ExceptionEntier(int a, int b)
        {
            //Arrange
            var badCalculator = new MauvaiseCalculatrice();

            //Act et Assert
            Assert.Throws<NotIntegerException>(() => badCalculator.Division(a, b));

        }

        [Test]
        [TestCase(5, 0, 42)]
        [TestCase(25, 0, 42)]
        [TestCase(80, 0, 42)]
        public void DivisionParZero_42(int a, int b, int expectedResult)
        {
            //Arrange
            var badCalculator = new MauvaiseCalculatrice();

            //Act
            var result = badCalculator.Division(a, b);

            //Assert
            Assert.That(result, Is.EqualTo(expectedResult));
        }

        //ValidValues
        [Test]
        [TestCase(-1,80,90)]
        [TestCase(-1, -80, 90)]
        [TestCase(-1, -80, -90)]
        public void ValidValues_ExceptionMinValue(int a, int b, int c)
        {
            //Arrange
            var badCalculator = new MauvaiseCalculatrice();
           
            //Act & Assert
            Assert.Throws<SubLimitException>(()=>badCalculator.ValidValues(a,b,c));

        }

        [Test]
        [TestCase(10000,1,1)]
        [TestCase(10000,10000,1)]
        [TestCase(10000,10000,10000)]
        public void ValidValues_ExceptionMaxValue(int a, int b, int c)
        {
            //Arrange
            var badCalculator = new MauvaiseCalculatrice();

            //Act & Assert
            Assert.Throws<OverLimitException>(() => badCalculator.ValidValues(a, b, c));

        }

    }
}