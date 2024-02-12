using Csharquarium.Enums;
using Csharquarium.Interfaces;

namespace Csharquarium.Models;

public abstract class Poisson : Entite, IPoisson
{
    public Poisson(string nom, Sexe sexe)
    {
        Nom = nom;
        Sexe = sexe;
    }

    public string Nom { get; set; }
    public Sexe Sexe { get; set; }

    public override string ToString()
    {
        return $" 🐟 Poisson {(this is ICarnivore ? "Carnivore" : "Herbivore")} ".PadRight(25) +
               $"Race: {GetType().Name} {Sexe} ".PadRight(25) +
               $"Nom: {Nom}";
    }
}