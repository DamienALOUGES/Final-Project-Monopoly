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
            private List<Case> board; //board = list of boxes/cases
            
            public List<Case> Board
            {
                get { return board; }
                set { board = value; }
            } //getter settter

            private Plateau()

            {
                Console.WriteLine("This is the game board \n");
                Console.WriteLine("RED = Chance box : Money Malus or Bonus \n");
                Console.WriteLine("BLUE - ORANGE - GREEN - YELLOW = Street box that you can buy  \n");
                Console.WriteLine("BLACK = Boxes related to Jail : Visit Jain / In Jail \n");

                this.board = new List<Case>();
                for (int i = 0; i < 40; i++)

                {
                      if (i == 0)//start case

                      {
                            Case chance = new CaseChance(i, "red", 200, true); //earn  200 if a player is on it
                            board.Add(chance);
                      }

                      if (i > 0 && i < 10) //first row

                      {

                            Case achat = new CaseAchat(i, "blue", 450, false, null);

                            board.Add(achat);

                      }

                      if (i == 10)//prison case

                      {

                            Case jail = new CaseAutre(i, "black");
                            board.Add(jail);


                      }

                      if (i > 10 && i < 20)//second row

                      {

                           Case achat = new CaseAchat(i, "green", 600, false, null);
                           board.Add(achat);

                      }

                      if (i == 20)//chance case malus

                      {

                          CaseChance chance = new CaseChance(i, "red", 150, false); //loose 150  if a playrt is on it
                          board.Add(chance);

                      }

                      if (i > 20 && i < 30)//third row

                      {

                          CaseAchat achat = new CaseAchat(i, "yellow", 750, false, null);
                          board.Add(achat);
                      }

                      if (i == 30)//send to prison case

                      {

                         CaseAutre visitJail = new CaseAutre(i, "black");
                         board.Add(visitJail);
                      }

                      if (i > 30 && i <= 39)//fourth row

                      {

                         CaseAchat achat = new CaseAchat(i, "orange", 750, false, null);
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

             public List<Case> ShowPlateau()
             {
                  for (int i = 0; i < board.Count; i++)
                  {
                      Console.Write(board[i].Couleur.ToUpper() + "  "); 
                  }

                   return Board;
             }


    }
        
   

    }


