using System;
using System.Collections.Generic;

namespace WaterskiBaan
{
    public class InstructieGroep : IWachtrij
    {
        public static int MAX_LENGTE_RIJ = 5;

        public InstructieGroep()
        {
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
