using Csharquarium.Enums;
using Csharquarium.Models;
using Csharquarium.Models.Carnivores;
using Csharquarium.Models.Herbivores;

Console.WriteLine("CSharquarium");

Console.WriteLine("\n ➤ Création de l'aquarium");
Aquarium aquarium = new Aquarium();

Console.WriteLine("\n ➤ Création des entités");
Console.WriteLine("Création des algues...");
// Création des algues
for (int i = 0; i < 10; i++)
{
    aquarium.AjouterAlgue(new Algue());
}

// Création des poissons
Console.WriteLine("Création des poissons...");
aquarium.AjouterPoisson(new PoissonClown("Nemo", Sexe.Male));
aquarium.AjouterPoisson(new Sole("Dory", Sexe.Femelle));
aquarium.AjouterPoisson(new PoissonClown("Marin", Sexe.Male));
aquarium.AjouterPoisson(new Merou("Ponyo", Sexe.Femelle));
aquarium.AjouterPoisson(new Thon("Gill", Sexe.Male));
aquarium.AjouterPoisson(new Carpe("Crush", Sexe.Male));
aquarium.AjouterPoisson(new Carpe("Bruce", Sexe.Male));
aquarium.AjouterPoisson(new Bar("Cleo", Sexe.Femelle));
aquarium.AjouterPoisson(new Thon("Peach", Sexe.Femelle));
aquarium.AjouterPoisson(new Sole("Bubbles", Sexe.Male));

Console.WriteLine("\n ➤ Passer le temps");
aquarium.PasserTemps();