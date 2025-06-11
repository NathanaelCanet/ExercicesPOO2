namespace Delegates_exercices1;

class Program
{
    class Player
    {
        public int Health { get; private set; }
        public int Score { get; private set; }

        public event Action IsDead;
        public event Action HasWon;
        public Player(int health)
        {
            this.IsDead += () => Console.WriteLine("Player is dead");
            this.HasWon += () => Console.WriteLine("Player has won");
            Health = health;
            Score = 0;
        }

        public void TakeDamage(int damage)
        {
            System.Console.WriteLine($"{damage} damage");
            this.Health -= damage;
            if (this.Health <= 0)
            {
                IsDead?.Invoke();
            }
        }

        public void TakeBonus(int bonus)
        {
            System.Console.WriteLine($"{bonus} bonus");
            this.Score += bonus;
            if (this.Score >= 100)
            {
                HasWon?.Invoke();
            }
        }
    }




    static void Main(string[] args)
    {
        Player player = new Player(100);
        player.TakeBonus(50);
        player.TakeDamage(50);
        player.TakeBonus(50);
        player.TakeDamage(50);
    }
}

/*
1.
Utilisez les événements et les délégués pour permettre à une classe Player
de notifier des changements importants dans son état, tels que la vie
tombant à zéro ou le score dépassant 100 points.
class Player
{
    public int Health { get; private set; }
    public int Score { get; private set; }

    public Player(int health)
    {
        Health = health;
        Score = 0;
    }
}

*/
