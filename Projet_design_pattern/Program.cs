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
           
            List<Card> cardsStack = Cardstack.Instance.returnStackCard(); //singleton plateau created

            Dice D1 = new Dice(1);
            Dice D2 = new Dice(2);

            List<Player> listPlayers = new List<Player>();
            Console.WriteLine("\nHow many players ? ");
            int numberPlayers=int.Parse( Console.ReadLine());
            

            for (int i = 0; i < numberPlayers; i++)
            {
                
                Console.WriteLine("\nName of the player number " + i + " :  ");
                string Name = Console.ReadLine();
                Player player = new Player(Name, 400.0, true, 0 ,i);
                listPlayers.Add(player);

            }

            while (turn<10)
            {
                TourDeJeu tour = new TourDeJeu(turn);
                Plateau.Instance.ShowPlateau();
                Console.WriteLine("\n\nTURN n°" + turn);
                tour.ATurn(monopBoard, cardsStack, listPlayers, D1, D2, tour.Tour);
                turn++;

            }

            double WinnerMoney=-1000;
            Player win=null;

            for (int i = 0; i < listPlayers.Count; i++)
            {

                Console.WriteLine("\nPlayer " + listPlayers[i].Name+ " has " +listPlayers[i].Money);
                if (listPlayers[i].Money > WinnerMoney)
                {
                    WinnerMoney = listPlayers[i].Money;
                    win = listPlayers[i];
                }
               
               
                Console.WriteLine();

            }Console.WriteLine();


            Console.WriteLine("The winner is " + win.Name);




            Console.ReadKey();
        }

       
    }
}
