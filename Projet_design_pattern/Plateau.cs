using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_design_pattern
{
    class Plateau // Singleton  

    {
            private static Plateau instance = null;
            private List<Box> board; //board = list of boxes/cases
            
            public List<Box> Board
            {
                get { return board; }
                set { board = value; }
            } //getter setter

            private Plateau()

            {
                Console.WriteLine("This is the game board \n");
                Console.WriteLine("WHITE = Begin box  \n");
                 Console.WriteLine("BLUE - ORANGE - GREEN - YELLOW = Street boxes that you can buy  \n");
                Console.WriteLine("BLACK = Boxes related to Jail : Visit Jain / In Jail \n");

                this.board = new List<Box>();
                for (int i = 0; i < 40; i++)

                {
                      if (i == 0)//start case

                      {
                            Box begin = new Box(i, "white" , 0, false,null,false);     
                            board.Add(begin);
                      }

                      if (i > 0 && i < 10) //first row

                      {

                            Box achat = new Box(i, "blue", 400, false, null,false);
                            board.Add(achat);

                      }

                      if (i == 10)//prison case

                      {

                            Box jail = new Box(i, "black");
                           
                            board.Add(jail);


                      }

                      if (i > 10 && i < 20)//second row

                      {

                           Box achat = new Box(i, "green", 600, false, null,false);
                           board.Add(achat);

                      }

                      if (i == 20)  // on this box the player pick a card

                      {

                          Box PickcardBox = new Box(i, "green", 600, true,null,false); // on this box the player pick a card
                          board.Add(PickcardBox);

                      }

                      if (i > 20 && i < 26) //third row

                      {

                          Box achat = new Box(i, "yellow", 750, false, null,false);
                          board.Add(achat);
                      }

                      if (i == 26) // on this box the player pick a card

                      {

                          Box achat = new Box(i, "yellow", 750, true, null, false);
                          board.Add(achat);
                      }

                      if (i > 26 && i < 30) //third row

                      {

                           Box achat = new Box(i, "yellow", 750, false, null, false);
                           board.Add(achat);
                      }

                      if (i == 30)//send to prison case

                      {

                         Box visitJail = new Box(i, "black");
                         
                         board.Add(visitJail);
                      }

                      if (i > 30 && i <= 37)//fourth row

                      {

                         Box achat = new Box(i, "orange", 800, false, null,false);
                         board.Add(achat);

                      }
                      if (i > 37 && i <= 39)//// on these box the player pick a card

                      {

                         Box achat = new Box(i, "orange", 800, true, null, false);
                         board.Add(achat);

                      }
                }

            }

             // Lock synchronization object
             private static object syncLock = new object();

             public static Plateau Instance

            {
                get

                {     // Support multithreaded applications through
                      // 'Double checked locking' pattern which (once
                      // the instance exists) avoids locking each
                      // time the method is invoked
                lock (syncLock)
                {

                    if (Plateau.instance == null)

                    {

                        Plateau.instance = new Plateau();
                       

                    }
                    return Plateau.instance;

                }    

                }

            }

             public List<Box> ShowPlateau()
             {
                  for (int i = 0; i < board.Count; i++)
                  {
                      Console.Write(board[i].Color.ToUpper() + "  "); 
                  }

                   return Board;
             }


    }
        
   

    }


