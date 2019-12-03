using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_design_pattern
{
    //'ConcreteElement' class of the visitor design pattern
    class CaseAchat : Case
    {
        private bool statut; // true si acheté , false sinon
        private int prix; // le prix de la case
        private Joueur owner; // celui a qui appartient la case

        public bool Statut
        {
            get { return statut; }
            set { statut = value; }
        }
        public int Prix
        {
            get { return prix; }
            set { prix = value; }
        }
        public Joueur Owner
        {
            get { return owner; }
            set { owner = value; }
        }
       

        public CaseAchat(int num, string col, int p,bool stat,Joueur j) : base(num, col)
        {
            prix =  p;
            statut = stat;
            owner = j;
           
        }

        public double calculTaxe()// montant de la taxe de la case si un autre joueur autre que le owner tombe dessus
        {
            double taxe = prix * 0.3;

            return taxe;
        }

        public override void Accept(IvisitorCase visitor)
        {
            visitor.Visit(this);
        }



    }
}

