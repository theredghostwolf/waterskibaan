﻿using System;
using System.Collections.Generic;
using WaterskiBaan.moves;

namespace WaterskiBaan
{
    public class WaterskiBaan
    {
        private LijnenVoorraad voorraad;
        private Kabel kabel;

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
            kabel.VerschuifLijnen();
            voorraad.LijnToevoegenAanRij(kabel.verwijderLijnVanKabel());
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

        public static void TestOpdracht8 ()
        {
            WaterskiBaan wb = new WaterskiBaan();
            List<IMove> m = new List<IMove>();
            m.Add(new EenBeen());
            m.Add(new EenHand());

            Sporter s = new Sporter(m);

            wb.SporterStart(s); //exception

            s.zwemvest = new Zwemvest();

            wb.SporterStart(s); //exception

            s.skies = new Skies();

            wb.SporterStart(s); //success
        }
    }
}
