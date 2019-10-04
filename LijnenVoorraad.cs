using System;
using System.Collections.Generic;

namespace WaterskiBaan
{
    public class LijnenVoorraad
    {
        private Queue<Lijn> _lijnen;

        Queue<Lijn> lijnen { get => _lijnen; set => _lijnen = value; }

        public LijnenVoorraad()
        {
            lijnen = new Queue<Lijn>();
        }

        public void LijnToevoegenAanRij (Lijn lijn)
        {
            lijnen.Enqueue(lijn);
        }

        public Lijn VerwijderEersteLijn ()
        {
            return lijnen.Dequeue();
        }

        public int GetAantalLijnen ()
        {
            return lijnen.Count;
        }

        public override string ToString()
        {
            if (lijnen.Count == 0)
            {
                return "Geen lijnen meer beschikbaar";
            }
            return lijnen.Count + " Lijnen beschikbaar";
        }

        public static void testOpdracht3 ()
        {
            LijnenVoorraad v = new LijnenVoorraad();

            Console.WriteLine(v);

            v.LijnToevoegenAanRij(new Lijn());
            v.LijnToevoegenAanRij(new Lijn());
            v.LijnToevoegenAanRij(new Lijn());
            v.LijnToevoegenAanRij(new Lijn());
            v.LijnToevoegenAanRij(new Lijn());

            Console.WriteLine(v);

            v.VerwijderEersteLijn();

            Console.WriteLine(v);
        }
    }
}
