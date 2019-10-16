using System;
using System.Collections.Generic;
using System.Drawing;

namespace WaterskiBaan
{
    public class Sporter
    {

        public int BehaaldePunten { get; set; }

        public int rondesGemaakt { get; set; }

        public int AantalRondenNogTeGaan { get; set; }

        public Zwemvest zwemvest { get; set; }

        public Skies skies { get; set; }

        public Color KledingKleur { get; set; }

        public IMove HuidigeMove;

        public int ID;

        public List<IMove> moves { get; set; }

        public Sporter(List<IMove> moves, int ID)
        {
            this.ID = ID;
            this.moves = moves;

            Random r = new Random();
            KledingKleur = Color.FromArgb(r.Next(255),r.Next(255),r.Next(255));
        
        }
    }
}
