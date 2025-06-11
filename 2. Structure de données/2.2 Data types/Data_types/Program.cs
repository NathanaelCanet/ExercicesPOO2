namespace Data_types;

class Program
{
    static void Main(string[] args)
    {
        //1
        int[] tab = { 4, 2, 7, 4, 8, 2, 9 };
        HashSet<int> set = new HashSet<int>();
        HashSet<int> doublons = new HashSet<int>();
        for (int i = 0; i < tab.Length; i++)
        {
            if (!set.Add(tab[i]))
            {
                doublons.Add(tab[i]);
            }
        }

        //2
        string expression = "((1+2)*(3/4))";
        bool var_ = Parenthese(expression);

        //3
        int[] nombres = { 1, 2, 3, 1, 1, 2, 1 };
        int max = PlusGrandeOccurence(nombres);

    }

    public static bool Parenthese(string expression)
    {
        Stack<char> stack = new Stack<char>();
        foreach (char c in expression)
        {
            if (c == '(')
            {
                stack.Push(c);
            }
            else if (c == ')')
            {
                if (stack.Count == 0)
                {
                    return false;
                }
                stack.Pop();
            }
        }
        if (stack.Count == 0)
        {
            return true;
        }
        return false;
    }

    public static int PlusGrandeOccurence(int[] nombres)
    {
        Dictionary<int, int> keyValuePairs = new Dictionary<int, int>();
        for (int i = 0; i < nombres.Length; i++)
        {
            if (keyValuePairs.ContainsKey(nombres[i]))
            {
                keyValuePairs[nombres[i]]++;
            }
            else
            {
                keyValuePairs[nombres[i]] = 1;
            }
        }
        int maxElement = keyValuePairs.Aggregate((x, y) => x.Value > y.Value ? x : y).Key; // mais wtf
        return maxElement;
    }
}
/*
1. Trouver les doublons de :
int[] tab = {4,2,7,4,8,2,9};

2. Vérifier si une expression contient des parenthèses bien équilibrées
string expression = "((1+2)*(3/4))";

3. Trouver l'élément majoritaire
int[] nombres = {1,2,3,1,1,2,1};
 */