using System;
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

        public void VerplaatsKabel ()
        {
            kabel.VerschuifLijnen();
            voorraad.LijnToevoegenAanRij(kabel.verwijderLijnVanKabel());
        }

        public override string ToString()
        {
            return voorraad.ToString() + " \n " + kabel.ToString();
        }
    }
}
