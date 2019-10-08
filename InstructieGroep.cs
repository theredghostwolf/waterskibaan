using System;
using System.Collections.Generic;
using System.Linq;

namespace WaterskiBaan
{
    public class InstructieGroep : Wachtrij
    {

        public static int MAX_LENGTE_RIJ = 5;

        public InstructieGroep() : base(MAX_LENGTE_RIJ)
        {
          
        }


    }
}
