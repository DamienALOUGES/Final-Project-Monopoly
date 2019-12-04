using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_design_pattern
{
    class Dice
    {
        private int id; //1 or 2 because there are 2 dice

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public Dice(int id)
        {
            this.id = id;
        }

        public int ValeurDés()
        {
            Random aleatoire = new Random();
            int value = aleatoire.Next(1, 7);  //random int value between 1 and 6

            return value;
        }

    }
}
