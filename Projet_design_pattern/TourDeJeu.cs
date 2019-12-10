using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

        //manage a turn
        public List<Player> ATurn(List<Box> monopBoard, List<Card> stack, List<Player> Players, Dice D1, Dice D2, int tour)

        {
            List<int> PlayersEliminated = new List<int>();

            for (int i = 0; i < Players.Count; i++)

            {
     
                PLayerTurn(monopBoard, stack, Players[i], D1, D2, tour);
                if (Players[i].Money <= 0)

                {
                    Console.WriteLine("You don'have any money yet, GAME OVER , you're eliminated !\n");
                    PlayersEliminated.Add(i);
                    // the player is out of the game he is added to the list of the pleyers who are eliminated
                }

            }

            for (int i = 0; i < PlayersEliminated.Count; i++)

            {
                Players.RemoveAt(PlayersEliminated[i]);  //remove all the players who have been eliminated at this Turn 

            }

            return Players;  //return the list of the players remained

        }

        //manage how to get free of jail
        public void GetFree(List<Box> monopBoard, List<Card> stack, Player player, Dice D1, Dice D2, int tour, ObjetStructure o)

        {

            int valD1 = D1.Val(); //dices instantiation
            Thread.Sleep(2520);
            int valD2 = D2.Val();


            Console.Write("Dice 1 = " + valD1 + "\n");

            Console.Write("Dice 2 = " + valD2 + "\n");

            int ValDice = valD1 + valD2;

            Console.WriteLine("total = " + ValDice + "\n");



            if (valD1 == valD2)

            {

                Console.WriteLine("You are now free to go");

                player.Status = true;



                Console.WriteLine("Go to box number " + (player.Position + ValDice) % 39);

                player.Position = (player.Position + ValDice) % 39;

                Box courantBox = monopBoard[player.Position];


                o.Attach(courantBox);

                //Players[i].Visit(courantBox);



                if (courantBox.PickAcard == true)

                {

                    Random aleatoire = new Random();

                    int CardPicked = aleatoire.Next(30); //Génère un entier compris entre 0 et 9

                    // Players[i].Visit((stack[CardPicked]));

                    o.Attach(stack[CardPicked]);

                }

                o.Accept(player);

            }

            else

            {
                player.TurnInJail++;

                if (player.TurnInJail == 3)
                {
                    Console.WriteLine("You've done your time in Jail you're now free to go.\n");
                    player.Status = true;
                    player.TurnInJail = 0;
                    Console.WriteLine("Go to box number " + (player.Position + ValDice) % 39);

                    player.Position = (player.Position + ValDice) % 39;

                    Box courantBox = monopBoard[player.Position];


                    o.Attach(courantBox);

                    //Players[i].Visit(courantBox);

                    if (courantBox.PickAcard == true)

                    {

                        Random aleatoire = new Random();

                        int CardPicked = aleatoire.Next(30); //Génère un entier compris entre 0 et 29

                        // Players[i].Visit((stack[CardPicked]));

                        o.Attach(stack[CardPicked]);

                    }

                    o.Accept(player);
                }
                else
                {
                    Console.WriteLine("You've been " + player.TurnInJail + " turn in jail, it is not enough ");
                    Console.WriteLine("You stay in jail");
                }
               


            }
            

        }

        //the logic of a turn
        public void PLayerTurn( List<Box> monopBoard, List<Card> stack, Player player, Dice D1, Dice D2, int tour)

        {
            ObjetStructure o = new ObjetStructure();

            Console.Write("Your turn to play " + player.Name + " you have "+player.Money+", roll the dice\n");

            Console.Write("Dice are rolled : \n");


            if (player.Status == false)
            {

               GetFree(monopBoard, stack, player, D1, D2, tour, o);

            }


            else
            {

                int valD1 = D1.Val(); //dices instantiation
                Thread.Sleep(236);
                int valD2 = D2.Val();

                Console.Write("Dice 1 = " + valD1 + "\n");

                Console.Write("Dice 2 = " + valD2 + "\n");
               // int ValDice = 30;  // test jail
                int ValDice = valD2 + valD1;

                Console.WriteLine("total = " + ValDice + "\n");



                Console.WriteLine("Go to box number " + (player.Position + ValDice) % 39);

                player.Position = (player.Position + ValDice) % 39;

                Box courantBox = monopBoard[player.Position];

                o.Attach(courantBox);

                //Players[i].Visit(courantBox);



                if (courantBox.PickAcard == true)

                {

                    Random aleatoire = new Random();



                    int CardPicked = aleatoire.Next(30); //Génère un entier compris entre 0 et 29 car 30 cartes

                    // Players[i].Visit((stack[CardPicked]));

                    o.Attach(stack[CardPicked]); //card visited by palyer

                }

                o.Accept(player);

                if (valD2 == valD1 && player.Status == true)

                {
                    Console.WriteLine("\nYou can play again! ");
                    PLayerTurn(monopBoard, stack, player, D1, D2, tour);

                }

            }

           

        }





    }

}
