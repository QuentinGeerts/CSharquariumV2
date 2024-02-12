using Csharquarium.Enums;
using Csharquarium.Interfaces;

namespace Csharquarium.Models.Herbivores;

public abstract class PoissonHerbivore : Poisson, IHerbivore
{
    protected PoissonHerbivore(string nom, Sexe sexe, int age) : base(nom, sexe, age)
    {
    }

    public void Manger(IAlgue algue)
    {
        if (algue is Algue a && !a.EstMort)
        {
            a.PointVie -= 2;
            PointVie += 3;
        }
    }
}