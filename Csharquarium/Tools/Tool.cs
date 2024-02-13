namespace Csharquarium.Tools;

public static class Tool
{
    private static Random _rnd = new Random();

    public static Random Rnd
    {
        get
        {
            return _rnd;
        }
    }
    
    public static void DisplayTitle(string message)
    {
        Console.WriteLine($"┌──────────────── ⋆⋅☆⋅⋆ ────────────────┐");
        Console.WriteLine($"{CenterText(message, 41)}");
        Console.WriteLine($"└──────────────── ⋆⋅☆⋅⋆ ────────────────┘");
    }

    public static string CenterText(string text, int fullSize)
    {
        int espacesDeChaqueCote = (fullSize - text.Length) / 2;
        return text.PadLeft(text.Length + espacesDeChaqueCote).PadRight(fullSize);
    }
}