using Csharquarium.Enums;
using Csharquarium.Interfaces;

namespace Csharquarium.Models.Carnivores;

public class Thon : PoissonCarnivore
{
    public Thon(string nom, Sexe sexe, int age = 0) : base(nom, sexe, age)
    {
    }

    protected override IPoisson? GenererBebe(Sexe sexe)
    {
        return new Thon($"Bébé {GetType().Name}", sexe);
    }
}