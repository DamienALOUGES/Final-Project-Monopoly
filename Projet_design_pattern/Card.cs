using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_design_pattern
{
    //This is classe which implement the Element interface ('IElement') and holds the real information.
    //'ConcreteElement2' class of the visitor design pattern
    class Card : IElement
    {
        private int amount; // the amout of the chance card (bonus or malus)
        private bool malusBonus; // bonus = true ; malus=false


        public int Amount
        {
            get { return amount; }
            set { amount = value; }
        }

        public bool MalusBonus
        {
            get { return malusBonus; }
            set { malusBonus = value; }
        }

        public Card( int mont, bool moub) 
        {
            amount = mont;
            malusBonus = moub;

        }

        //pattern visitor
        public void Accept(IvisitorElement visitorElement)
        {
            visitorElement.Visit(this);
        }
    }
}

