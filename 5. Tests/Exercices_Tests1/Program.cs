namespace Exercices_Tests1
{

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

            if (b == 0)
            {
                int result = 42;
                ValidValues(a, b, result);
                return result;
            }
            if (a % b != 0)
            {
                throw new NotIntegerException("Divison non entière");
            }

            int divisionResult = a / b;
            ValidValues(a, b, divisionResult);
            return divisionResult;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
}
