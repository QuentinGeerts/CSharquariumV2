using System.Text;
using Csharquarium.Enums;
using Csharquarium.Models;
using Csharquarium.Models.Carnivores;
using Csharquarium.Models.Herbivores;

Console.OutputEncoding = Encoding.UTF8;

Console.WriteLine("CSharquarium");

Console.WriteLine("\n ➤ Création de l'aquarium");
var aquarium = new Aquarium();

Console.WriteLine("\n ➤ Création des entités");
Console.WriteLine("Création des algues...");
// Création des algues
for (var i = 0; i < 5; i++) aquarium.AjouterAlgue(new Algue());

// Création des poissons
Console.WriteLine("Création des poissons...");
aquarium.AjouterPoisson(new Sole("Nemo", Sexe.Male));
aquarium.AjouterPoisson(new Sole("Dory", Sexe.Femelle));
aquarium.AjouterPoisson(new Merou("Marin", Sexe.Male));
aquarium.AjouterPoisson(new Merou("Marine", Sexe.Femelle));
aquarium.AjouterPoisson(new Merou("Emmy", Sexe.Femelle));
aquarium.AjouterPoisson(new PoissonClown("Ponyo", Sexe.Femelle));
aquarium.AjouterPoisson(new Sole("Gill", Sexe.Femelle));
aquarium.AjouterPoisson(new Sole("Crush", Sexe.Male));
aquarium.AjouterPoisson(new Sole("Bruce", Sexe.Male));
aquarium.AjouterPoisson(new Carpe("Cleo", Sexe.Femelle));
aquarium.AjouterPoisson(new Sole("Peach", Sexe.Femelle));
aquarium.AjouterPoisson(new Sole("Alphinaud", Sexe.Male));

Console.WriteLine("\n ➤ Passer le temps");
// for (int i = 0; i < 100; i++)
// {    
//     aquarium.PasserTemps();
// }

while (aquarium.AlguesCount != 0 || aquarium.PoissonsCount != 0) aquarium.PasserTemps();