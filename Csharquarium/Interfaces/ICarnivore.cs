using Csharquarium.Models;

namespace Csharquarium.Interfaces;

public interface ICarnivore
{
    public void Manger(IPoisson poisson);
}