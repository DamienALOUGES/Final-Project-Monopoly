using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_design_pattern
{
    class CaseAchat : Case
    {

        private int prix; // le prix de la case

        public int Prix
        {
            get { return prix; }
            set { prix = value; }
        }

   
        public CaseAchat(int num, string col, int p) : base(num, col)
        {
            prix =  p;
           
        }

        public double calculTaxe()// montant de la taxe de la case si un autre joueur autre que le owner tombe dessus
        {
            double taxe = prix * 0.3;

            return taxe;
        }

        public Joueur owner(Joueur owner) // le joueur a qui a acheté la case
        {
            return owner;
        }




    }
}

