using System;
using System.Collections.Generic;
using System.Linq;

namespace WaterskiBaan
{
    public class InstructieGroep : Wachtrij
    {

        public static int MAX_LENGTE_RIJ = 5;

        public int counter;

        public static int speed = 20;

        public InstructieGroep() : base(MAX_LENGTE_RIJ)
        {
          
        }

        public void Afgelopen (InstructieAfgelopenArgs args)
        {
            while (this.sporters.Count > 0)
            {
                args.target.SporterNeemtPlaatsInRij(this.sporters.Dequeue());
            }

            if (args.sporters.Count > 0)
            { 
                foreach (Sporter s in args.sporters)
                {
                    this.SporterNeemtPlaatsInRij(s);
                }
            }
        }


    }
}
