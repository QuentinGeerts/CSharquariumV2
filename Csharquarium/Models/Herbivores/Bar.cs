using Csharquarium.Enums;
using Csharquarium.Interfaces;

namespace Csharquarium.Models.Herbivores;

public class Bar : PoissonHerbivore
{
    public Bar(string nom, Sexe sexe, int age = 0) : base(nom, sexe, age)
    {
    }

    protected override IPoisson? GenererBebe(Sexe sexe)
    {
        return new Bar($"Bébé {GetType().Name}", sexe);
    }
}