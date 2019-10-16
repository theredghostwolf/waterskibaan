using System;
using System.Collections.Generic;
using System.Linq;

namespace WaterskiBaan
{
    public abstract class Wachtrij : IWachtrij
    {
        public Queue<Sporter> sporters;
        private int Max;

        public Wachtrij(int max)
        {
            sporters = new Queue<Sporter>();
            Max = max;
        }

        public List<Sporter> GetAlleSporters()
        {
            return sporters.ToList();
        }

        public void SporterNeemtPlaatsInRij(Sporter sporter)
        {
            if (sporters.Count < Max)
            {
                sporters.Enqueue(sporter);
            }
        }

        public List<Sporter> SportersVerlatenRij(int aantal)
        {
            List<Sporter> s = new List<Sporter>();
            for (int i = 0; i < aantal; i++)
            {
                if (sporters.Count > 0)
                {
                    Sporter sp = sporters.Dequeue();
                    if (sp != null)
                    {
                        s.Add(sp);
                    }
                }
            }
            return s;
        }

        public override string ToString()
        {
            return "Aantal in rij: " + sporters.Count;
        }

        public Sporter sporterVerlaatRij()
        {
            if (sporters.Count > 0)
            {
                return sporters.Dequeue();
            }
            else
            {
                return null;
            }
        }
    }
}
