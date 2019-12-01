using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_design_pattern
{
    class Joueur
    {
        string prenom;
        double argent;

        public string Prenom
        {
            get { return prenom; }
            set { prenom = value; }
        }

        public double Argent
        {
            get { return argent; }
            set { argent = value; }
        }

        public Joueur(string prenom,double argent)
        {
            this.prenom = prenom;
            this.argent = argent; 
        }

    }
}
