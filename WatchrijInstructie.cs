using System;
using System.Collections.Generic;

namespace WaterskiBaan
{
    public class WatchrijInstructie : IWachtrij
    {
        public static int MAX_LENGTE_RIJ = 100;
        public Queue<Sporter> sporters;

        public WatchrijInstructie()
        {
            sporters = new Queue<Sporter>(MAX_LENGTE_RIJ);

        }

        public List<Sporter> GetAlleSporters()
        {
            throw new NotImplementedException();
        }

        public void SporterNeemtPlaatsInRij(Sporter sporter)
        {
            throw new NotImplementedException();
        }

        public List<Sporter> SportersVerlatenRij(int aantal)
        {
            throw new NotImplementedException();
        }
    }
}
