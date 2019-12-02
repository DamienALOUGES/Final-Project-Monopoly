using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_design_pattern
{
    //This are classe which implement the Element interface ('Icase') and holds the real information.
    //the 'ConcreTElements' inherit of this classe 

    abstract class Case : Icase
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

        //pattern visitor
        public void Accept(IvisitorCase visitor)
        {
            visitor.Visit(this);
        }


    }
}
