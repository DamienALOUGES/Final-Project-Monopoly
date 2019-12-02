using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_design_pattern

{
    // The 'Element' interface of the visitor design pattern
    //This is an interface that specifies the Accept operation.

    interface Icase
    {
         void Accept(IvisitorCase visitorCase);

    }
}
