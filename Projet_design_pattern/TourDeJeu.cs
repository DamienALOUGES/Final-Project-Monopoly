using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_design_pattern
{
    class TourDeJeu
    {
       private int tour;

        public int Numero
        {
            get { return tour; }
            set { tour = value; }
        }

        public TourDeJeu(int tour)
        {
            this.tour = tour;
        }

        public void unTour(Plateau gameBoard,List<Joueur> Players,Dés D1,Dés D2)
        {
            for(int i = 0; i < Players.Count; i++)
            {
                Console.Write("Your turn to play " +Players[i].Prenom+ ", roll the dice\n");
                Console.Write("Dice are rolled : \n");
                Console.Write("Dice "+D1.Id+ " = " +D1.ValeurDés()+"\n");
                Console.Write("Dice " + D2.Id + " = " + D2.ValeurDés() + "\n");
                int ValDice = D1.ValeurDés() + D2.ValeurDés();
                Console.WriteLine("Go to box number " + (Players[i].Position + ValDice) % 39);
                Players[i].Position = (Players[i].Position + ValDice) % 39;
                





            }
        }


    }
}
