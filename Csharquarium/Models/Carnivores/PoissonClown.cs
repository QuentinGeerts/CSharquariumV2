using Csharquarium.Enums;
using Csharquarium.Interfaces;

namespace Csharquarium.Models.Carnivores;

public class PoissonClown : PoissonCarnivore
{
    public PoissonClown(string nom, Sexe sexe, int age = 0) : base(nom, sexe, age)
    {
    }

    protected override IPoisson? GenererBebe(Sexe sexe)
    {
        return new PoissonClown($"Bébé {GetType().Name}", sexe);
    }
}