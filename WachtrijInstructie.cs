using System;
using System.Collections.Generic;

namespace WaterskiBaan
{
    public class WachtrijInstructie : Wachtrij
    {
        public static int MAX_LENGTE_RIJ = 100;

        public int counter;
        public static int speed = 4;

        public WachtrijInstructie() : base (MAX_LENGTE_RIJ)
        {
            counter = 0;
        }

        public void Bezoeker (NieuweBezoekerArgs args)
        {
            this.SporterNeemtPlaatsInRij(args.sporter);
        }

    }
}
