using Csharquarium.Interfaces;

namespace Csharquarium.Models;

public abstract class Entite : IEntite
{
    protected Entite(int age)
    {
        Age = age;
    }

    public int PointVie { get; set; } = 10;
    public bool EstMort => PointVie <= 0;
    public int Age { get; set; }
}