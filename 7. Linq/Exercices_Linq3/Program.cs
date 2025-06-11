namespace Exercices_Linq3;
class Employe
{
    public string Nom { get; set; }
    public string Departement { get; set; }
}
class Program
{

    static void Main(string[] args)
    {
        List<Employe> employes = new List<Employe>
        {
            new Employe { Nom = "Alice Martin", Departement = "RH" },
            new Employe { Nom = "Bob Dupont", Departement = "IT" },
            new Employe { Nom = "Claire Durant", Departement = "RH" },
            new Employe { Nom = "David Bernard", Departement = "Marketing" },
            new Employe { Nom = "Emma Petit", Departement = "IT" },
            new Employe { Nom = "François Leroy", Departement = "Marketing" },
            new Employe { Nom = "Gabrielle Roux", Departement = "IT" }
        };

        var departements = employes.GroupBy(emp => emp.Departement); //de type IEnumerable<IGrouping<TKey,T>>
        foreach (var dep in departements)
        {
            System.Console.WriteLine($"Département : {dep.Key}");
            foreach (var emp in dep)
            {
                System.Console.WriteLine($"Nom : {emp.Nom}");
            }
        }
    }
}
/*
Groupement
class Employe
{
    public string Nom { get; set; }
    public string Departement { get; set; }
}
Afficher, pour chaque département, la liste des noms des employés qui y
travaillent.
*/