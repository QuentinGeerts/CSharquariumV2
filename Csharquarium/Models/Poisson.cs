using Csharquarium.Enums;
using Csharquarium.Interfaces;

namespace Csharquarium.Models;

public abstract class Poisson : Entite, IPoisson
{
    protected Poisson(string nom, Sexe sexe, int age) : base(age)
    {
        Nom = nom;
        Sexe = sexe;
    }

    public string Nom { get; set; }
    public Sexe Sexe { get; set; }

    public IPoisson? SeReproduire(IPoisson partenaire)
    {
        var compatible = !EstMort && !partenaire.EstMort
                                  && GetType() == partenaire.GetType()
                                  && Sexe != partenaire.Sexe
                                  && Age > 2 && partenaire.Age > 2;

        Random rnd = new();

        var sexe = rnd.Next(1) == 0 ? Sexe.Male : Sexe.Femelle;

        return compatible ? GenererBebe(sexe) : null;
    }

    public override string ToString()
    {
        return $" 🐟 Poisson {(this is ICarnivore ? "Carnivore" : "Herbivore")} ".PadRight(30) +
               $"Race: {GetType().Name} {Sexe} ".PadRight(30) +
               $"Nom: {Nom} ".PadRight(25) +
               $"Points de vie: {PointVie} ".PadRight(25) +
               $"Age: {Age} ".PadRight(25);
    }

    protected abstract IPoisson? GenererBebe(Sexe sexe);
}