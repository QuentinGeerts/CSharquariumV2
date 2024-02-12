using Csharquarium.Enums;
using Csharquarium.Interfaces;

namespace Csharquarium.Models;

public class Aquarium
{
    private readonly List<IEntite> _habitants = new(); // Type Inference 
    private int _nbTours = 0;

    public int AlguesCount => _habitants.Count(entite => entite is Algue);
    public int PoissonsCount => _habitants.Count(entite => entite is Poisson);

    public void AjouterPoisson(IPoisson poisson)
    {
        if (_habitants.Contains(poisson)) return;
        _habitants.Add(poisson);
    }

    public void AjouterAlgue(IAlgue algue)
    {
        if (_habitants.Contains(algue)) return;
        _habitants.Add(algue);
    }

    public void PasserTemps()
    {
        var rnd = new Random();

        Console.WriteLine();
        Console.WriteLine($"--------------------------------\n" +
                          $"| Nombre de tours : {(++_nbTours).ToString(),10} |\n" +
                          $"--------------------------------\n");
        // Vérifier s'il reste des habitants
        // if (_habitants.Count == 0) return;


        Renseigner();

        // Console.ReadLine();

        // Début de tour
        foreach (var entite in _habitants)
        {
            entite.Age++;
            
            switch (entite)
            {
                case IPoisson p:
                    p.PointVie--;
                    break;

                case IAlgue a:
                    a.PointVie++;
                    break;
            }
        }

        // Pour effacer éventuellement les morts
        Nettoyer();

        // Nourriture
        foreach (var poisson in _habitants.OfType<Poisson>().ToList())
        {
            if (poisson.PointVie > 5) continue;
            
            switch (poisson)
            {
                case ICarnivore carnivore:
                {
                    var poissonsAJour = _habitants.OfType<Poisson>().ToList();

                    if (poissonsAJour.Count == 0) continue;

                    var cible = poissonsAJour[rnd.Next(poissonsAJour.Count)];
                    carnivore.Manger(cible);
                    break;
                }
                case IHerbivore herbivore:
                {
                    var alguesAJour = _habitants.OfType<Algue>().ToList();

                    if (alguesAJour.Count == 0) continue;

                    var cible = alguesAJour[rnd.Next(alguesAJour.Count)];
                    herbivore.Manger(cible);
                    break;
                }
            }
        }

        // Pour effacer éventuellement les morts
        Nettoyer();

        
        // Reproduction
        List<IAlgue> bebeAlgues = new();
        List<IPoisson> bebePoissons = new();
        
        foreach (var entite in _habitants)
        {
            if (entite is IPoisson { PointVie: > 5 } p)
            {
                var poissonsAJour = _habitants.OfType<Poisson>().ToList();
                var cible = poissonsAJour[rnd.Next(poissonsAJour.Count)];
                var bebe = p.SeReproduire(cible);
                
                if (bebe != null)
                {
                    bebePoissons.Add(bebe);
                    Console.WriteLine($" 🐠 Un bébé {bebe.GetType().Name} est né.");
                }
            }
            
            if (entite is IAlgue { PointVie: >= 10 } a)
            {
                var bebe = a.SeMultiplier();
                if (bebe != null)
                {
                    bebeAlgues.Add(bebe);
                    Console.WriteLine($" 🍃 Une petite algue {bebe.GetType().Name} est né.");
                }
            }
        }
        
        // Ajouter les nouveaux nés dans la liste des habitants
        foreach (var algue in bebeAlgues)
        {
            AjouterAlgue(algue);
        }

        foreach (var poisson in bebePoissons)
        {
            AjouterPoisson(poisson);
        }

        // Console.ReadLine();
    }

    private void Renseigner()
    {
        // Le nombre d'algue
        var algues = _habitants.OfType<Algue>().ToList();
        Console.WriteLine($"Nombre d'algues dans l'aquarium : {algues.Count}");
        foreach (var algue in algues)
        {
            Console.WriteLine(algue);
        }

        Console.WriteLine();

        // La liste des poissons avec caractéristiques
        var poissons = _habitants.OfType<Poisson>().ToList();
        Console.WriteLine($"Caractéristiques de {poissons.Count} poissons :");
        Console.WriteLine($" - 🥗 Herbivores : {poissons.Count(poisson => poisson is IHerbivore)}");
        Console.WriteLine($" - 🍖 Carnivores : {poissons.Count(poisson => poisson is ICarnivore)}");

        Console.WriteLine();

        foreach (var poisson in poissons)
        {
            Console.WriteLine(poisson);
        }

        Console.WriteLine();
    }

    private void Nettoyer()
    {
        // Nettoyage de l'aquarium
        for (int i = _habitants.Count - 1; i >= 0; i--)
        {
            if (_habitants[i].Age >= 20)
            {
                Console.WriteLine(
                    $"{(_habitants[i] is Poisson ? ((Poisson)_habitants[i]).Nom + " est mort" : _habitants[i].GetType().Name + " est morte")}.");
            }

            if (_habitants[i].EstMort || _habitants[i].Age >= 20)
            {
                _habitants.RemoveAt(i);
            }
        }
    }
}