using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_design_pattern
{
    //This is classe which implement the Element interface ('IElement') and holds the real information.
    //'ConcreteElement1' class of the visitor design pattern

    class Box : IElement
    {
       private int number;
       private string color;
       private int price;
       bool pickAcard; // true=pick a chance card ; false = don't pick
       private Player owner; // celui a qui appartient la case
       private bool statut; // true si acheté , false sinon

        public bool Statut
        {
            get { return statut; }
            set { statut = value; }
        }

        public int Number
        {
            get { return number; }
            set { number = value; }
        }

        public Player Owner
        {
            get { return owner; }
            set { owner = value; }
        }

        public int Price
        {
            get { return price; }
            set { price = value; }
        }

        public bool PickAcard
        {
            get { return pickAcard; }
            set { pickAcard = value; }
        }

        public string Color
        {
            get { return color; }
            set { color = value; }
        }

        public Box(int num, string col, int p, bool pick, Player own,bool sta) //for street boxes
        {
            number = num;
            color = col;
            price = p;
            pickAcard = pick;
            owner = own;
            statut = sta;

        }

        public Box(int num, string col) //for jail /visit jail boxes
        {
            number = num;
            color = col;  

        }

        public double calculTaxe()// montant de la taxe de la case si un autre joueur autre que le owner tombe dessus
        {
            double taxe = price * 0.3;

            return taxe;
        }

   

        public void BeginBox(Player player) //if a player is on the Begin box (0) then he earn 200 eu
        {
            if (this.number == 0)
            {
                player.Money = +400;
            }
        }
        //pattern visitor

        public void Accept(IvisitorElement visitorElement)
        {
            visitorElement.Visit(this);
        }
    }
}
