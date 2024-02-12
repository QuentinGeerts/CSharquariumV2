using Csharquarium.Enums;
using Csharquarium.Interfaces;

namespace Csharquarium.Models.Herbivores;

public class Sole : PoissonHerbivore
{
    public Sole(string nom, Sexe sexe) : base(nom, sexe)
    {
    }
}