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
        private string prenom;
        private double argent;
        private bool statut; // true= free, false= in jail
        private int position; //position of the player on the game board
        private int id;

        public string Prenom
        {
            get { return prenom; }
            set { prenom = value; }
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

        public double Argent
        {
            get { return argent; }
            set { argent = value; }
        }

        public bool Statut
        {
            get { return statut; }
            set { statut = value; }
        }


        public Player(string prenom,double argent,bool statut,int position,int id)
        {
            this.prenom = prenom;
            this.argent = argent;
            this.statut = statut;
            this.position = position;
            this.id = id;
        }

       
        //pattern visitor
        public void Visit(Box courantBox)
        {
            Console.WriteLine("Box {0} visited by player {1}",
            courantBox.Number, this.Prenom);

            //street boxes
            if  (courantBox.Statut == false && courantBox.Number != 10 && courantBox.Number != 30) // free box
            {
                Console.WriteLine("Do you want to buy this street ? - 0 if YES // 1 if NO\n");
                int reponse =int.Parse( Console.ReadLine());

                if (reponse == 0)
                {
                    courantBox.Owner = this ;
                    courantBox.Statut= true;
                    this.Argent  =-courantBox.Price;
                }
            }

            if (courantBox.Statut == true && courantBox.Number != 10 && courantBox.Number != 30) // box already bought by another player
            {
                this.argent =-courantBox.calculTaxe();
                courantBox.Owner.Argent =+ courantBox.calculTaxe();

            }

            //jail Boxe
   
           
             if (courantBox.Number == 30)
            {
                this.statut = false; //go to jail
                this.position = 10; //in jail
            }

        }

        //visitor dp 
        public void Visit(Card chance)
        {

                Console.WriteLine("Chance card of the amout of {0} Eur is picked by player {1}",
                chance.Amount, this.Prenom);

                if (chance.MalusBonus == true)
                {
                     Console.WriteLine("This is a bonus card ! :) \n");
                     this.argent = argent + chance.Amount; // money bonus 
                     Console.WriteLine("You now have "+this.argent+" Eur left");
                }
                else
                {
                     Console.WriteLine("This is a malus card ! :( \n");
                     this.argent = argent - chance.Amount; //money malus 
                     Console.WriteLine("You now have " + this.argent + " Eur left");
                }
        }

    }
}
