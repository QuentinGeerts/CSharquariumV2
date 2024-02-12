using Csharquarium.Enums;

namespace Csharquarium.Interfaces;

public interface IPoisson : IEntite
{
    string Nom { get; set; }
    Sexe Sexe { get; set; }

    IPoisson? SeReproduire(IPoisson partenaire);
}