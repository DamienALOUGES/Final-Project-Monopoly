using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_design_pattern
{
    class Cardstack // Singleton  

    {
        private static Cardstack instance = null;
        private List<Card> cards; //board = list of boxes/cases

        public List<Card> Cards
        {
            get { return cards; }
            set { cards = value; }
        } //getter setter

        private Cardstack()

        {
            Console.WriteLine("\nThe satck of Cards is instancied \n");
           

            this.cards = new List<Card>();
            for (int i = 0; i < 30; i++)

            {
                if (i == 0 || i== 4 || i==7 || i== 20 || i == 21 || i == 22 || i == 25 || i == 29)//50 bonus cards 

                {
                    Card kplus = new Card(100, true);
                    cards.Add(kplus);

                }

                if( i==2 || i == 3 || i == 11 || i == 12 || i == 14 || i == 16 || i == 23 || i == 27) //50 malus card
                {
                    Card kless = new Card(100, false);
                    cards.Add(kless);
                }
                else
                {
                    Card kplus = new Card(200, true);
                    cards.Add(kplus);

                }

                
            }

        }

        // Lock synchronization object
        private static object syncLock = new object();

        public static Cardstack Instance

        {
            get

            {     // Support multithreaded applications through
                  // 'Double checked locking' pattern which (once
                  // the instance exists) avoids locking each
                  // time the method is invoked
                lock (syncLock)
                {

                    if (Cardstack.instance == null)

                    {

                        Cardstack.instance = new Cardstack();


                    }

                    return Cardstack.instance;
                }
                

            }

        }

        public List<Card> returnStackCard()
        {
            return this.cards;
        }


    }



}


