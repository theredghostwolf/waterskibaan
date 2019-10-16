using System;
using System.Collections.Generic;
using System.Threading;
using System.Timers;
using WaterskiBaan.moves;

namespace WaterskiBaan
{
    public class Game
    {
        private InstructieGroep instructieGroep;

        private WachtrijStarten wachtrijStarten;

        private WachtrijInstructie wachtrijInstructie;

        private WaterskiBaan waterskiBaan;

        public delegate void NieuweBezoekerHandler (NieuweBezoekerArgs args);

        public event NieuweBezoekerHandler NieuweBezoeker;

        public delegate void InstructieAfgelopenHandler(InstructieAfgelopenArgs args);

        public event InstructieAfgelopenHandler instructieAfgelopen;

        private Random random;

        private int ID;

        private int kabelCounter;
        public static int kabelSpeed = 3;

        public Logger logger;

        public Game()
        {

        }

        public void Initialize ()
        {
            //initialize our similation
            instructieGroep = new InstructieGroep();
            wachtrijStarten = new WachtrijStarten();
            wachtrijInstructie = new WachtrijInstructie();
            waterskiBaan = new WaterskiBaan();

            ID = 0;
            kabelCounter = 0;
            Logger.rondes = 0;

            random = new Random();

            logger = new Logger(waterskiBaan.getKabel());

            //events
            NieuweBezoeker += wachtrijInstructie.Bezoeker;
            instructieAfgelopen += instructieGroep.Afgelopen;
            NieuweBezoeker += logger.nieuw;
            waterskiBaan.timer.Elapsed += tick;
            waterskiBaan.EventVerschuifLijnen += lijnenVerschoven;

            //start simulation
            //waterskiBaan.start();

        }

        public void tick (Object source, ElapsedEventArgs e)
        {
            t();
        }

        public static void TestOpdracht11 ()
        {
            Game g = new Game();
            g.Initialize();
        }

        public static void TestOpdracht12 ()
        {
            Game g = new Game();
            g.Initialize();
            Thread.Sleep(50000);
            g.waterskiBaan.stop();
            g.logger.data();
        }

        //actual tick implementation
        public void t ()
        {
            //wachtrij timer
            if (wachtrijInstructie.counter > WachtrijInstructie.speed)
            {
                NieuweBezoeker(new NieuweBezoekerArgs(new Sporter(MoveCollection.GetRandomMoves(), ID++)));
                wachtrijInstructie.counter = 0;
            }
            else
            {
                wachtrijInstructie.counter++;
            }
            //instructie groep timer
            if (instructieGroep.counter > InstructieGroep.speed)
            {
                List<Sporter> s = wachtrijInstructie.SportersVerlatenRij(5);
                instructieAfgelopen(new InstructieAfgelopenArgs(s, wachtrijStarten));
                instructieGroep.counter = 0;
            }
            else
            {
                instructieGroep.counter++;
            }

            if (kabelCounter > kabelSpeed)
            {
                waterskiBaan.VerplaatsKabel();
                kabelCounter = 0;
            }
            else
            {
                kabelCounter++;
            }

            Console.Clear();
            Console.WriteLine("-----------------------------");
            Console.WriteLine(wachtrijInstructie);
            Console.WriteLine(instructieGroep);
            Console.WriteLine(wachtrijStarten);
            Console.WriteLine(waterskiBaan);
            Console.WriteLine("-----------------------------");

        }

        public void lijnenVerschoven (VerschuifLijnenArgs args)
        {
            //check if position is available
            if (args.kabel.IsStartPositieLeeg())
            {
                Sporter s = wachtrijStarten.sporterVerlaatRij();
                if (s != null)
                {
                     s.zwemvest = new Zwemvest();
                     s.skies = new Skies();
                     waterskiBaan.SporterStart(s);

                }

            }
        }


    }
}
