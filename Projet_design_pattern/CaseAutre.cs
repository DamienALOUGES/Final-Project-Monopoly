using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_design_pattern
{

    //'ConcreteElement' class of the visitor design pattern
    class CaseAutre : Case, Icase // case 10 ou 30 : jail /visit jail
    {

        public CaseAutre(int num, string col) : base(num, col) {}

        public bool estJail(int numeroCase)
        {
            if( numeroCase == 10)
            {
                return true; // in jail
            }
            else //==30
            {
                return false;  // vistit jail

            }
       
        }

    }
}
