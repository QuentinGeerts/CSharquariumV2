using System.Text;
using Csharquarium.Enums;
using Csharquarium.Models;
using Csharquarium.Models.Carnivores;
using Csharquarium.Models.Herbivores;
using Csharquarium.Tools;

// Permet d'afficher les emojis correctement en console.
Console.OutputEncoding = Encoding.UTF8;

Tool.DisplayTitle("CSharquarium");

Tool.DisplayTitle("Création de l'aquarium");
var aquarium = new Aquarium();

Tool.DisplayTitle("Création des entités");
Console.WriteLine(" 🚧 Création des algues...");
// Création des algues
for (var i = 0; i < 5; i++) aquarium.AjouterAlgue(new Algue());

// Création des poissons
Console.WriteLine(" 🚧 Création des poissons...");
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
aquarium.AjouterPoisson(new Merou("Aqua", Sexe.Femelle));
aquarium.AjouterPoisson(new Merou("Oceane", Sexe.Femelle));
aquarium.AjouterPoisson(new Thon("Typhoon", Sexe.Male));
aquarium.AjouterPoisson(new Thon("Vortex", Sexe.Male));
aquarium.AjouterPoisson(new Carpe("Caspian", Sexe.Male));
aquarium.AjouterPoisson(new PoissonClown("Bubble", Sexe.Male));
aquarium.AjouterPoisson(new Carpe("Splash", Sexe.Femelle));
aquarium.AjouterPoisson(new Merou("Ariel", Sexe.Femelle));
aquarium.AjouterPoisson(new Merou("Neptune", Sexe.Male));
aquarium.AjouterPoisson(new PoissonClown("Finny", Sexe.Male));
aquarium.AjouterPoisson(new PoissonClown("Bubbles", Sexe.Femelle));
aquarium.AjouterPoisson(new Thon("Splashy", Sexe.Male));
aquarium.AjouterPoisson(new Thon("Wave", Sexe.Femelle));
aquarium.AjouterPoisson(new Bar("Barry", Sexe.Male));
aquarium.AjouterPoisson(new Bar("Sandy", Sexe.Femelle));
aquarium.AjouterPoisson(new Carpe("Ripple", Sexe.Male));
aquarium.AjouterPoisson(new Carpe("Wavy", Sexe.Femelle));


Tool.DisplayTitle("Passer le temps");
// for (int i = 0; i < 100; i++)
// {    
//     aquarium.PasserTemps();
// }

while (aquarium.AlguesCount != 0 || aquarium.PoissonsCount != 0) aquarium.PasserTemps();