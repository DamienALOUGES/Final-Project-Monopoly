using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_design_pattern
{
    // 'ObjectStructure' class of the visitor design pattern
    //This is a class that holds all the elements which can be used by visitors ("Joueur" class).

    class Cases
    {
        private List<Case> _cases = new List<Case>();

        public void Attach(Case position)
        {
            _cases.Add(position);
        }

        public void Detach(Case position)
        {
            _cases.Remove(position);
        }

        public void Accept(IvisitorCase visitor)
        {
            foreach (Case e in _cases)
            {
                e.Accept(visitor);
            }
            Console.WriteLine();
        }
    }
}
