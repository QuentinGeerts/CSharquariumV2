using Csharquarium.Enums;
using Csharquarium.Interfaces;

namespace Csharquarium.Models.Carnivores;

public class Merou : PoissonCarnivore
{
    public Merou(string nom, Sexe sexe) : base(nom, sexe)
    {
    }
}