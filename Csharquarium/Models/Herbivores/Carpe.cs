using Csharquarium.Enums;
using Csharquarium.Interfaces;

namespace Csharquarium.Models.Herbivores;

public class Carpe : PoissonHerbivore
{
    public Carpe(string nom, Sexe sexe, int age = 0) : base(nom, sexe, age)
    {
    }

    protected override IPoisson? GenererBebe(Sexe sexe)
    {
        return new Carpe($"Bébé {GetType().Name}", sexe);
    }
}