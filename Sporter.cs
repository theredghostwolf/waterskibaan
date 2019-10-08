using System;
using System.Collections.Generic;

namespace WaterskiBaan
{
    public class Sporter
    {

        public int BehaaldePunten { get; set; }

        public int AantalRondenNogTeGaan { get; set; }

        public Zwemvest zwemvest { get; set; }

        public Skies skies { get; set; }

        //public Color KledingKleur { get; set; }

        public List<IMove> moves { get; set; }

        public Sporter(List<IMove> moves)
        {
            this.moves = moves;

            Random r = new Random();

            //kledingKleur = new Color (r.next(255), r.next(255), r.next(255));
        }
    }
}
