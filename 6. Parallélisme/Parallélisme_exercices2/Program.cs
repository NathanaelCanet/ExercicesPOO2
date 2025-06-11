using System.Collections.Generic;
using System.Threading;
namespace Parallélisme_exercices2;

class Program
{
    static object lockObj = new object();
    static bool productionComplete = false;
    static void Main(string[] args)
    {
        Queue<int> queue = new Queue<int>();

        var threadProducteur = new Thread(() => Production(queue));

        threadProducteur.Start();

        var threadConsommateur = new Thread(() => Consommation(queue));

        threadConsommateur.Start();


        threadProducteur.Join();
        threadConsommateur.Join();

        Console.WriteLine("Fin du programme.");
    }

    static void Production(Queue<int> queue)
    {
        Random random = new Random();

        for (int i = 0; i < 100; i++)
        {
            int newRandomValue = random.Next();

            lock (lockObj)
            {
                queue.Enqueue(newRandomValue);
                Monitor.Pulse(lockObj); // Réveille le consommateur
            }

            Thread.Sleep(100);

            lock (lockObj)
            {
                productionComplete = true;
                Monitor.Pulse(lockObj); // Dernière notification
            }
        }
    }

    static void Consommation(Queue<int> queue)
    {
        while (true)
        {
            int value;

            lock (lockObj)
            {
                while (queue.Count == 0 && !productionComplete)
                {
                    Monitor.Wait(lockObj);
                }

                if (queue.Count == 0 && productionComplete)
                {
                    break;
                }

                value = queue.Dequeue();
            }

            Console.WriteLine($"Consommateur lit : {value}");
            Thread.Sleep(150);
        }
    }
}
