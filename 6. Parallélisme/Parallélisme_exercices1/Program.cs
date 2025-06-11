using System.Threading;
using System.Diagnostics;

namespace Parallélisme_exercices1;

class Program
{
    static void Main(string[] args)
    {
        Stopwatch stopwatch = new Stopwatch();

        var threadA = new Thread(() => Action('A'));
        var threadB = new Thread(() => Action('B'));
        var threadC = new Thread(() => Action('C'));

        stopwatch.Start();

        threadA.Start();
        threadB.Start();
        threadC.Start();

        threadA.Join();
        threadB.Join();
        threadC.Join();

        System.Console.WriteLine($"Temps écoulé : {stopwatch.ElapsedMilliseconds} ms");
    }


    static void Action(char character)
    {
        for (int i = 0; i < 9; i++)
        {
            System.Console.WriteLine(character);
        }
        
    }
}
