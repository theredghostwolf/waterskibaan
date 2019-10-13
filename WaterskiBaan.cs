using System;
using System.Collections.Generic;
using WaterskiBaan.moves;

namespace WaterskiBaan
{
    public class WaterskiBaan
    {
        private LijnenVoorraad voorraad;
        private Kabel kabel;

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
        }

        public void VerplaatsKabel()
        {
            //EventVerschuifLijnen(new VerschuifLijnenArgs());

            Lijn l = kabel.verwijderLijnVanKabel();
            kabel.VerschuifLijnen();
            if (l != null)
            {
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
                    sporter.AantalRondenNogTeGaan = r.Next(2);
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

        }

        public void stop ()
        {

        }

        public static void TestOpdracht8 ()
        {
            WaterskiBaan wb = new WaterskiBaan();
           
            Sporter s = new Sporter(MoveCollection.GetRandomMoves());

            wb.SporterStart(s); //exception

            s.zwemvest = new Zwemvest();

            wb.SporterStart(s); //exception

            s.skies = new Skies();

            wb.SporterStart(s); //success
        }
    }
}
