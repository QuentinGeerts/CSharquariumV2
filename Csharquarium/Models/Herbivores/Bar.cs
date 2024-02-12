using Csharquarium.Enums;
using Csharquarium.Interfaces;

namespace Csharquarium.Models.Herbivores;

public class Bar : PoissonHerbivore
{
    public Bar(string nom, Sexe sexe) : base(nom, sexe)
    {
    }
}