using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_design_pattern
{
    // The 'Visitor' interface of the visitor design pattern
    //This is an interface that specifies the Visit operations for concrete visitors (joueurs).

    interface IvisitorElement //visitor=joueur
    {
        void Visit(Box position);
        void Visit(Card chance);
        
    }
}
