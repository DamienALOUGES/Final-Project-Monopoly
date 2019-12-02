using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_design_pattern
{
    //'ConcreteElement' class of the visitor design pattern
    class CaseChance : Case , Icase
    {
        private int montant; //la case chance permet de gagner ou perdre de l'argent d'un certaint montant
        private bool malusBonus; // bonus = true ; malus=false


        public int Montant
        {
            get { return montant; }
            set { montant = value; }
        }

        public bool MalusBonus
        {
            get { return malusBonus; }
            set { malusBonus = value; }
        }


        public CaseChance(int num, string col, int mont, bool moub) : base(num, col)
        {
            montant = mont;
            malusBonus = moub;

        }

       
    }
}

