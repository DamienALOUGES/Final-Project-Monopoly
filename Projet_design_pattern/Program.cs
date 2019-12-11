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
            
            int turn = 0;
           
            Console.WriteLine("                                     MONOPOLY                  \n");
            List<Box> monopBoard = Plateau.Instance.ShowPlateau(); //singleton plateau created
            List<Card> cardsStack = Cardstack.Instance.showStackCard(); //singleton plateau created

            Dice D1 = new Dice(1);
            Dice D2 = new Dice(2);

            List<Player> listPlayers = new List<Player>();
            Console.WriteLine("\n.......................................................................................................");
            Console.WriteLine("\nHow many players ? ");
            int numberPlayers=int.Parse( Console.ReadLine());
            

            for (int i = 0; i < numberPlayers; i++)
            {
                
                Console.WriteLine("\nName of the player number " + i + " :  ");
                string Name = Console.ReadLine();
                Player player = new Player(Name, 400.0, true, 0 ,i,0);
                listPlayers.Add(player);

            }

            while (listPlayers.Count > 1) // id only one player remain the game is over
            {
                TourDeJeu tour = new TourDeJeu(turn);
                Console.WriteLine("\n\nTURN n°" + turn);
                listPlayers = tour.ATurn(monopBoard, cardsStack, listPlayers, D1, D2, tour.Tour);
                turn++;

            }
      
            // the winner is the last one

            for (int i = 0; i < listPlayers.Count; i++)
            {

                Console.WriteLine("...........................................");
                Console.WriteLine(" YOU ARE THE WINNER : " + listPlayers[i].Name + " BRAVO ! ");
                Console.WriteLine("...........................................");

            }
            Console.ReadKey();
        }

       
    }
}
