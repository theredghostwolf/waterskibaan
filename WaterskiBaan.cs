using System;
using System.Collections.Generic;
using WaterskiBaan.moves;

namespace WaterskiBaan
{
    public class WaterskiBaan
    {
        private LijnenVoorraad voorraad;
        private Kabel kabel;

        public System.Timers.Timer timer { get; set; }

        public delegate void VerschuifLijnenHandler(VerschuifLijnenArgs args);

        public event VerschuifLijnenHandler EventVerschuifLijnen;

        public Kabel getKabel  ()
        {
            return kabel;
        }

        private static int startSupply = 15;

        public WaterskiBaan()
        {
            voorraad = new LijnenVoorraad();
            kabel = new Kabel();

            for (int i = 0; i < startSupply; i++)
            {
                voorraad.LijnToevoegenAanRij(new Lijn());
            }

            //setup a timer on a 1 second delay
            timer = new System.Timers.Timer(1000 / 5);

            //add stuff to the timer
            timer.AutoReset = true;
        }

        public void VerplaatsKabel()
        {
            EventVerschuifLijnen(new VerschuifLijnenArgs(this, kabel));

            Lijn l = kabel.verwijderLijnVanKabel();
            kabel.VerschuifLijnen();

            if (l != null)
            {
                l.sporter = null;
                voorraad.LijnToevoegenAanRij(l);
            }
        }

        public override string ToString()
        {
            return voorraad.ToString() + " \n " + kabel.ToString();
        }

        public void SporterStart(Sporter sporter)
        {
            if (kabel.IsStartPositieLeeg() && voorraad.GetAantalLijnen() > 0)
            {
                //gear check
                if (sporter.skies == null || sporter.zwemvest == null)
                { 
                    throw new Exception("Ski spullen niet in orde!");
                }
                else
                {
                    //aantal rondes 1-2
                    Random r = new Random();
                    sporter.AantalRondenNogTeGaan = r.Next(1,3);
                    //lijn op halen
                    Lijn lijn = voorraad.VerwijderEersteLijn();
                    lijn.sporter = sporter;
                    //lijn aan kabel hangen
                    kabel.NeemLijnInGebruik(lijn);
                }
            }
        }

        public void start ()
        {
            timer.Start();

        }

        public void stop ()
        {
            timer.Stop();
        }



        public static void TestOpdracht8 ()
        {
            WaterskiBaan wb = new WaterskiBaan();
           
            Sporter s = new Sporter(MoveCollection.GetRandomMoves(), 0);

            wb.SporterStart(s); //exception

            s.zwemvest = new Zwemvest();

            wb.SporterStart(s); //exception

            s.skies = new Skies();

            wb.SporterStart(s); //success
        }
    }
}
