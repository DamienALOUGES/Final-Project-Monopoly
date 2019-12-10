using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_design_pattern
{
    //'ConcreteVisitor' class of the visitor dp
    class Player : IvisitorElement
    {
        private string name;
        private double money;
        private bool status; // true= free, false= in jail
        private int position; //position of the player on the game board
        private int id;
        private int turnInJail;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Position
        {
            get { return position; }
            set { position = value; }
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public double Money
        {
            get { return money; }
            set { money = value; }
        }

        public bool Status
        {
            get { return status; }
            set { status = value; }
        }

        public int TurnInJail
        {
            get { return turnInJail; }
            set { turnInJail = value; }
        }


        public Player(string prenom,double argent,bool statut,int position,int id,int turnInJail)
        {
            this.name = prenom;
            this.money = argent;
            this.status = statut;
            this.position = position;
            this.id = id;
            this.turnInJail = turnInJail;

        }

       
        //pattern visitor
        public void Visit(Box courantBox)
        {
            Console.WriteLine("Box {0} visited by player {1}",
            courantBox.Number, this.Name);

            //street boxes
            //jail Boxe
            if (courantBox.Number == 0)
            {
                Console.WriteLine("You earn 400 Eur, you are on the Begin Box !");
                this.Money = +400;
            }

            if (courantBox.Number == 10) { Console.WriteLine("You are visiting jail"); }

            if (courantBox.Number == 30)
            {
                Console.WriteLine("You are in jail\n ");
                this.status = false; //go to jail
                this.position = 10; //in jail
            }

            if (courantBox.Statut == true && courantBox.Number != 10 && courantBox.Number != 30) // box already bought by another player
            {
                this.money = this.Money-courantBox.calculTaxe();
                
                courantBox.Owner.Money = courantBox.Owner.Money+courantBox.calculTaxe();

                Console.WriteLine("The owner of this street  is " + courantBox.Owner.Name +
                    "You have to pay taxes (" + courantBox.calculTaxe() + " Eur). Now you have " + this.money + " Eur\n." +
                    courantBox.Owner.Name + " has now " + courantBox.Owner.Money + " Eurn  \n");
                if (this.money < 0)
                {
                    Console.WriteLine("You have a negativ bank balance be careful you cannot buy anything! ");
                }

            }

            if (courantBox.Statut == false && courantBox.Number != 10 && courantBox.Number != 30 && courantBox.Number != 0) // free box
            {
                Console.WriteLine("Do you want to buy this street ? - 0 if YES // 1 if NO\n");
                int reponse =int.Parse( Console.ReadLine());

                if (reponse == 0)
                {
                    if (this.Money >= courantBox.Price )
                    {
                        courantBox.Owner = this;
                        courantBox.Statut = true;
                        this.Money = this.Money - courantBox.Price;
                        Console.WriteLine("You are the new owner of this street " + courantBox.Owner.Name + " with " + courantBox.Owner.Money + " Eur.\n");
                    }
                    else { Console.WriteLine("You don't have enough money to buy this street."); }
                }
            }


           
        }

        //visitor dp 
        public void Visit(Card chance)
        {

                Console.WriteLine("Chance card of the amout of {0} Eur is picked by player {1}",
                chance.Amount, this.Name);

                if (chance.MalusBonus == true)
                {
                     Console.WriteLine("This is a bonus card ! :) \n");
                     this.money = money + chance.Amount; // money bonus 
                     Console.WriteLine("You now have "+this.money+" Eur left");
                }
                else
                {
                     Console.WriteLine("This is a malus card ! :( \n");
                     this.money = money - chance.Amount; //money malus 
                     Console.WriteLine("You now have " + this.money + " Eur left");
                }
        }

    }
}
