using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_design_pattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(" -----------------------------------------\n");
            Console.WriteLine("|                                         |\n");
            Console.WriteLine("|                                         |\n");
            Console.WriteLine("|               MONOPOLY                  |\n");
            Console.WriteLine("|                                         |\n");
            Console.WriteLine("|                                         |\n");
            Console.WriteLine(" -----------------------------------------\n\n");

          List<Case> plat = Plateau.Instance.ShowPlateau(); //singleton plateau created
            Dés D1 = new Dés(1);
            Dés D2 = new Dés(2);

            Console.WriteLine("How many players? ");
            int numberPlayers=int.Parse( Console.ReadLine());

            for (int i = 0; i < numberPlayers; i++)
            {
                List<Joueur> listJoueurs = new List<Joueur>();
                Console.WriteLine("Name of the player number " + i + " :  ");
                string Name = Console.ReadLine();
                Joueur player = new Joueur(Name, 400.0, true, 0 ,i);
                listJoueurs.Add(player);

                Case col= Plateau.Instance.Board[listJoueurs[i].Position];
                
                listJoueurs[i].Visit(plat[i]);


            }


            Console.ReadKey();
        }

       
    }
}
