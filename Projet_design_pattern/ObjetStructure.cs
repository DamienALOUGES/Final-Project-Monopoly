using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_design_pattern
{
    // 'ObjectStructure' class of the visitor design pattern
    //This is a class that holds all the elements which can be used by visitors ("Player" class).

    class ObjetStructure
    {
        private List<IElement> _elements = new List<IElement>();

        public void Attach(IElement  element)
        {
            _elements.Add(element);
        }

        public void Detach(IElement element)
        {
            _elements.Remove(element);
        }

        public void Accept(IvisitorElement visitor)
        {
            foreach (IElement e in _elements)
            {
                e.Accept(visitor);
            }
            Console.WriteLine();
        }
    }
}
