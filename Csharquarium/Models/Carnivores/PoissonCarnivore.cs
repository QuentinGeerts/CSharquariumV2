using Csharquarium.Enums;
using Csharquarium.Interfaces;

namespace Csharquarium.Models.Carnivores;

public abstract class PoissonCarnivore : Poisson, ICarnivore
{
    protected PoissonCarnivore(string nom, Sexe sexe, int age) : base(nom, sexe, age)
    {
    }

    public void Manger(IPoisson poisson)
    {
        if (poisson is Poisson p && p != this && p.GetType() != GetType() && !p.EstMort)
        {
            p.PointVie -= 4;
            PointVie += 5;
        }
    }
}