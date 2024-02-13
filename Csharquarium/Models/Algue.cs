using Csharquarium.Interfaces;

namespace Csharquarium.Models;

public class Algue : Entite, IAlgue
{
    public Algue(int age = 0) : base(age)
    {
    }

    public IAlgue? SeMultiplier()
    {
        if (Age < 10) return null;

        var bebePv = PointVie / 2;
        PointVie -= bebePv;
        return new Algue { PointVie = bebePv / 2 };
    }

    public override string ToString()
    {
        return " \ud83c\udf3f Algue ".PadRight(30) +
               $"Points de vie: {PointVie} ".PadRight(25) +
               $"Age: {Age} ".PadRight(25);
    }
}