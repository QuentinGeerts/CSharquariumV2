using Csharquarium.Interfaces;

namespace Csharquarium.Models;

public class Aquarium
{
    private List<Entite> _habitants;

    public Aquarium()
    {
        _habitants = new List<Entite>();
    }

    public void AjouterPoisson(Poisson poisson)
    {
        if (_habitants.Contains(poisson)) return;
        _habitants.Add(poisson);
    }

    public void AjouterAlgue(Algue algue)
    {
        if (_habitants.Contains(algue)) return;
        _habitants.Add(algue);
    }

    public void PasserTemps()
    {
        var algues = _habitants.OfType<Algue>().ToList();
        var poissons = _habitants.OfType<Poisson>().ToList();

        // Le nombre d'algue
        Console.WriteLine($"Nombre d'algues dans l'aquarium : {algues.Count}");

        // La liste des poissons avec caractéristiques
        Console.WriteLine($"Caractéristiques de {poissons.Count} poissons :\n");
        foreach (Poisson poisson in poissons)
        {
            Console.WriteLine(poisson);
        }

        Console.WriteLine("TEST");

        // Cantine
        foreach (Poisson poisson in poissons)
        {
            Random random = new Random();
            int index = random.Next(0, _habitants.Count - 1);

            Console.WriteLine($"Nombre de poissons: {_habitants.Count}");
            Console.WriteLine($"Index généré: {index}");

            IEntite entite = _habitants[index];

            Console.WriteLine($"Cible du poisson : {entite}");

            if (poisson is ICarnivore carnivore && entite is IPoisson p)
            {
                carnivore.Manger(p);
            }

            if (poisson is IHerbivore herbivore && entite is IAlgue a)
            {
                herbivore.Manger(a);
            }
        }
    }
}