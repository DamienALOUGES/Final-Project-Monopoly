using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_design_pattern
{
    //'ConcreteVisitor' class of the visitor dp
    class Joueur : IvisitorCase
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


        public Joueur(string prenom,double argent,bool statut,int position,int id)
        {
            this.prenom = prenom;
            this.argent = argent;
            this.statut = statut;
            this.position = position;
            this.id = id;
        }

       
        //pattern visitor
        public void Visit(CaseAchat achat)
        {
            Console.WriteLine("Box {0} visited by player {1}",
            achat.Numero, this.Prenom);

            if (achat.Statut==true)
            {
                this.argent = argent - achat.calculTaxe();
            }
            if  (achat.Statut == false) // free case
            {
                Console.WriteLine("Voulez-vous acheter cette case? 0 si oui - 1 si non");
                int reponse =int.Parse( Console.ReadLine());

                if (reponse ==0)
                {
                   
                    achat.Owner = this ;
                    achat.Statut= true;                   
                }
            }

            if (achat.Statut == true) //case already bought
            {
                this.argent =- achat.calculTaxe();
                achat.Owner.Argent = +achat.calculTaxe();

            }


             }
             public void Visit(CaseAutre autre)
             {
                Console.WriteLine("Box {0} visited by player {1}",
                 autre.Numero, this.Prenom);

             if (autre.Numero == 10)
                 {
                     this.statut = false;
                                                                   
                 }else if (autre.Numero == 30)
                 {
                     this.position = 10; // go to visit jail
                 }

             }
             public void Visit(CaseChance chance)
             {

                 Console.WriteLine("Box {0} visited by player {1}",
                 chance.Numero, this.Prenom);

                    if (chance.MalusBonus == true)
                    {
                         this.argent = argent + chance.Montant; // money bonus 
                    }
                    else
                    {
                         this.argent = argent - chance.Montant; //money malus 
                    }
             }

    }
}
