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

        public int Tour
        {
            get { return tour; }
            set { tour = value; }
        }

        public TourDeJeu(int tour)
        {
            this.tour = tour;
        }

        public void ATurn(List<Box> monopBoard, List<Card> stack,List<Player> Players,Dice D1,Dice D2,int tour)
        {
            ObjetStructure o = new ObjetStructure();
            for (int i = 0; i < Players.Count; i++)
            {
                Console.Write("Your turn to play " +Players[i].Prenom+ ", roll the dice\n");
                Console.Write("Dice are rolled : \n");
                Console.Write("Dice "+D1.Id+ " = " +D1.ValeurDés()+"\n");
                Console.Write("Dice " + D2.Id + " = " + D2.ValeurDés() + "\n");
                int ValDice = D1.ValeurDés() + D2.ValeurDés();
                Console.WriteLine(" " + ValDice + "\n");

                Console.WriteLine("Go to box number " + (Players[i].Position + ValDice) % 39);
                Players[i].Position = (Players[i].Position + ValDice) % 39;
                Box courantBox = monopBoard[Players[i].Position];

                o.Attach(courantBox);
                //Players[i].Visit(courantBox);

                if (courantBox.PickAcard == true)
                {
                    Random aleatoire = new Random();
                   
                    int CardPicked = aleatoire.Next(30); //Génère un entier compris entre 0 et 9
                   // Players[i].Visit((stack[CardPicked]));
                    o.Attach(stack[CardPicked]);
                }

                o.Accept(Players[i]);

            }
          
            
        }


    }
}
