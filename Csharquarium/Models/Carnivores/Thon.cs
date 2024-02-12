using Csharquarium.Enums;
using Csharquarium.Interfaces;

namespace Csharquarium.Models.Carnivores;

public class Thon : PoissonCarnivore
{
    public Thon(string nom, Sexe sexe) : base(nom, sexe)
    {
    }
}