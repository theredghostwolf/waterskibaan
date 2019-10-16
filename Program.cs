using System;
using System.Threading;
using WaterskiBaan.moves;

namespace WaterskiBaan
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            /*
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

            WaterskiBaan.TestOpdracht8();
            */
            //Game.TestOpdracht11();


            Game g = new Game();
            g.Initialize();

            for(int i = 0; i < 300; i++)
            {
                g.t();
                Thread.Sleep(1000 / 10);
            }
            g.logger.data();



            // Game.TestOpdracht12();
            /*
            Game g = new Game();
            g.Initialize();
            Console.ReadLine();
            g.logger.data();
            */           

        }
    }
}
