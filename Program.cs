using System;

namespace WaterskiBaan
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Kabel k = new Kabel();

            k.NeemLijnInGebruik(new Lijn());
            k.VerschuifLijnen();
            k.NeemLijnInGebruik(new Lijn());
            k.VerschuifLijnen();
            k.NeemLijnInGebruik(new Lijn());
            k.VerschuifLijnen();
            k.NeemLijnInGebruik(new Lijn());
            k.VerschuifLijnen();
            k.VerschuifLijnen();
            k.NeemLijnInGebruik(new Lijn());
            k.VerschuifLijnen();

            Console.WriteLine(k.ToString());

            LijnenVoorraad.testOpdracht3();

        }
    }
}
