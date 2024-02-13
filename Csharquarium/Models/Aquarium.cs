using Csharquarium.Interfaces;
using Csharquarium.Models.Carnivores;
using Csharquarium.Models.Herbivores;
using Csharquarium.Tools;

namespace Csharquarium.Models;

public class Aquarium
{
    private readonly List<IEntite> _habitants = new(); // Type Inference 
    private int _nbTours;

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
        Tool.DisplayTitle($"Nombre de tours : {(++_nbTours).ToString(),5} ");
        
        Renseigner();

        Console.ReadLine();

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

                    var cible = poissonsAJour[Tool.Rnd.Next(poissonsAJour.Count)];
                    carnivore.Manger(cible);
                    break;
                }
                case IHerbivore herbivore:
                {
                    var alguesAJour = _habitants.OfType<Algue>().ToList();

                    if (alguesAJour.Count == 0) continue;

                    var cible = alguesAJour[Tool.Rnd.Next(alguesAJour.Count)];
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
            switch (entite)
            {
                case IPoisson { PointVie: > 5 } p:
                {
                    var poissonsAJour = _habitants.OfType<Poisson>().ToList();
                    var cible = poissonsAJour[Tool.Rnd.Next(poissonsAJour.Count)];
                    var bebe = p.SeReproduire(cible);

                    if (bebe != null)
                    {
                        bebePoissons.Add(bebe);
                    }

                    break;
                }
                case IAlgue { PointVie: >= 10 } a:
                {
                    var bebe = a.SeMultiplier();
                    if (bebe != null)
                    {
                        bebeAlgues.Add(bebe);
                    }

                    break;
                }
            }
        }

        // Ajouter les nouveaux nés dans la liste des habitants

        if (bebeAlgues.Count + bebePoissons.Count > 0) Console.WriteLine("\nNaissances:");

        foreach (var algue in bebeAlgues)
        {
            AjouterAlgue(algue);
            Console.WriteLine($" 🍃 Une petite algue {algue.GetType().Name} est né.");
        }

        foreach (var poisson in bebePoissons)
        {
            Console.WriteLine($" 🐠 Un bébé {poisson.GetType().Name} est né.");
            AjouterPoisson(poisson);
        }

        // Console.ReadLine();
        Console.WriteLine();
    }

    private void Renseigner()
    {
        // Le nombre d'algue
        var algues = _habitants.OfType<Algue>().ToList();
        Console.WriteLine($"Nombre d'algues dans l'aquarium : {algues.Count}");
        foreach (var algue in algues) Console.WriteLine(algue);

        Console.WriteLine();

        // La liste des poissons avec caractéristiques
        var poissons = _habitants.OfType<Poisson>().ToList();

        var nbBar = poissons.Count(poisson => poisson is Bar);
        var nbCarpe = poissons.Count(poisson => poisson is Carpe);
        var nbSole = poissons.Count(poisson => poisson is Sole);
        var nbMerou = poissons.Count(poisson => poisson is Merou);
        var nbPoissonClown = poissons.Count(poisson => poisson is PoissonClown);
        var nbThon = poissons.Count(poisson => poisson is Thon);
        
        Console.WriteLine($"Caractéristiques de {poissons.Count} poissons :");
        Console.WriteLine($" - 🥗 Herbivores : {poissons.Count(poisson => poisson is IHerbivore)}" +
                          $" ( Bar: {nbBar}  |  Carpe: {nbCarpe}  |  Sole: {nbSole} )");
        Console.WriteLine($" - 🍖 Carnivores : {poissons.Count(poisson => poisson is ICarnivore)}" +
                          $" ( Merou: {nbMerou}  |  PoissonClown: {nbPoissonClown}  |  Thon: {nbThon} )");

        Console.WriteLine();

        foreach (var poisson in poissons) Console.WriteLine(poisson);

        Console.WriteLine();
    }

    private void Nettoyer()
    {
        // Nettoyage de l'aquarium
        for (var i = _habitants.Count - 1; i >= 0; i--)
        {
            if (_habitants[i].Age >= 20)
                Console.WriteLine(
                    $"{(_habitants[i] is Poisson ? ((Poisson)_habitants[i]).Nom + " est mort" : _habitants[i].GetType().Name + " est morte")}.");

            if (_habitants[i].EstMort || _habitants[i].Age >= 20) _habitants.RemoveAt(i);
        }
    }
}