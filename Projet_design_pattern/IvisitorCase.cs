using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_design_pattern
{
    // The 'Visitor' interface of the visitor design pattern
    //This is an interface that specifies the Visit operations for concrete visitors (joueurs).

    interface IvisitorCase //visitor=joueur
    {
        void Visit(CaseChance chance);
        void Visit(CaseAutre autre);
        void Visit(CaseAchat achat);
        
    }
}
