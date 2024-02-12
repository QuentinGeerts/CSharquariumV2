using Csharquarium.Enums;
using Csharquarium.Interfaces;

namespace Csharquarium.Models.Carnivores;

public abstract class PoissonCarnivore : Poisson, ICarnivore
{
    public PoissonCarnivore(string nom, Sexe sexe) : base(nom, sexe)
    {
    }

    public void Manger(IPoisson poisson)
    {
    }
}