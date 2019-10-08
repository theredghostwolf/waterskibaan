using System;
using System.Collections.Generic;

namespace WaterskiBaan
{
    public interface IWachtrij
    {
        void SporterNeemtPlaatsInRij(Sporter sporter);

        List<Sporter> GetAlleSporters();

        List<Sporter> SportersVerlatenRij(int aantal);
    }
}
