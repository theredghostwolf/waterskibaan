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
            random = new Random();

            //events
            NieuweBezoeker += wachtrijInstructie.Bezoeker;
            instructieAfgelopen += instructieGroep.Afgelopen;

            //setup a timer on a 1 second delay
            System.Timers.Timer t = new System.Timers.Timer(1000);

            //add stuff to the timer
            t.Elapsed += tick;
            t.AutoReset = true;
            t.Start();   
           
        }

        public void tick (Object source, ElapsedEventArgs e)
        {   
            //wachtrij timer
            if (wachtrijInstructie.counter > WachtrijInstructie.speed)
            {
                NieuweBezoeker(new NieuweBezoekerArgs(new Sporter(MoveCollection.GetRandomMoves())));
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

        

            //check if position is available
            if (waterskiBaan.getKabel().IsStartPositieLeeg())
            {
                List<Sporter> s = wachtrijStarten.SportersVerlatenRij(1);
                if (s.Count > 0)
                {
                    foreach (Sporter sp in s)
                    {

                        sp.zwemvest = new Zwemvest();
                        sp.skies = new Skies();

                        waterskiBaan.SporterStart(sp);
                    }
                }

            }

            //randomly update 
            if (random.Next(1000) > 700)
            {
                waterskiBaan.VerplaatsKabel();
            }

            Console.WriteLine(wachtrijInstructie);
            Console.WriteLine(instructieGroep);
            Console.WriteLine(wachtrijStarten);
            Console.WriteLine(waterskiBaan);
            Console.WriteLine("-----------------------------");


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

        }

        public void t ()
        {
            //wachtrij timer
            if (wachtrijInstructie.counter > WachtrijInstructie.speed)
            {
                NieuweBezoeker(new NieuweBezoekerArgs(new Sporter(MoveCollection.GetRandomMoves())));
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


            //check if position is available
            if (waterskiBaan.getKabel().IsStartPositieLeeg())
            {
                List<Sporter> s = wachtrijStarten.SportersVerlatenRij(1);
                if (s.Count > 0)
                {
                    foreach (Sporter sp in s)
                    {

                        sp.zwemvest = new Zwemvest();
                        sp.skies = new Skies();

                        waterskiBaan.SporterStart(sp);
                    }
                }

            }

            //randomly update 
            if (random.Next(1000) > 700)
            {
                waterskiBaan.VerplaatsKabel();
            }


            Console.WriteLine(wachtrijInstructie);
            Console.WriteLine(instructieGroep);
            Console.WriteLine(wachtrijStarten);
            Console.WriteLine(waterskiBaan);
            Console.WriteLine("-----------------------------");
        }


    }
}
