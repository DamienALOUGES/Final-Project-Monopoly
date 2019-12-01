using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_design_pattern
{
    abstract class Case
    {
       protected int numero;
       protected string couleur;

        public int Numero
        {
            get { return numero; }
            set { numero = value; }
        }

        public string Couleur
        {
            get { return couleur; }
            set { couleur = value; }
        }

        public Case(int num, string col)
        {

            numero = num;
            couleur = col;

        }

        public override string ToString()
        {
            return "\n La case n°" + numero + " est de couleur  " +
            couleur + "\n";
        }



    }
}
