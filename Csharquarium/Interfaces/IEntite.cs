namespace Csharquarium.Interfaces;

public interface IEntite
{
    int PointVie { get; set; }
    bool EstMort => PointVie <= 0;
    int Age { get; set; }
}