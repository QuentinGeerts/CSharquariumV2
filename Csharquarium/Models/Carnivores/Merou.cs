using Csharquarium.Enums;
using Csharquarium.Interfaces;

namespace Csharquarium.Models.Carnivores;

public class Merou : PoissonCarnivore
{
    public Merou(string nom, Sexe sexe, int age = 0) : base(nom, sexe, age)
    {
    }

    protected override IPoisson? GenererBebe(Sexe sexe)
    {
        return new Merou($"Bébé {GetType().Name}", sexe);
    }
}