using Csharquarium.Enums;
using Csharquarium.Interfaces;

namespace Csharquarium.Models.Herbivores;

public abstract class PoissonHerbivore : Poisson, IHerbivore
{
    public PoissonHerbivore(string nom, Sexe sexe) : base(nom, sexe)
    {
    }

    public void Manger(IAlgue algue)
    {
    }
}