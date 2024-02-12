using Csharquarium.Enums;
using Csharquarium.Interfaces;

namespace Csharquarium.Models.Herbivores;

public class Carpe : PoissonHerbivore
{
    public Carpe(string nom, Sexe sexe) : base(nom, sexe)
    {
    }
}