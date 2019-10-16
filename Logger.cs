using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace WaterskiBaan
{
    public class Logger
    {
        public static int rondes =0;
        public List<Sporter> bezoekers { get; set; }
        public Kabel kabel { get; set; }

        public Logger(Kabel kabel)
        {
            bezoekers = new List<Sporter>();
            this.kabel = kabel;
        }

        public void nieuw (NieuweBezoekerArgs args)
        {
            this.bezoekers.Add(args.sporter);
        }

        private bool colorsAreClose (Color c1, Color c2, int threshold)
        {
            int r = c1.R - c2.R,
                g = c1.G - c2.G,
                b = c1.B - c2.B;
            return (r * r + g * g + b * b) < threshold * threshold;
        }

           
        //private Func<Sporter, Sporter, int> sortKleding = (x,y)  => ((x.KledingKleur.G * x.KledingKleur.G) + (x.KledingKleur.B * x.KledingKleur.B) + (x.KledingKleur.R * x.KledingKleur.R) == (y.KledingKleur.G * y.KledingKleur.G) + (y.KledingKleur.B * y.KledingKleur.B) + (y.KledingKleur.R * y.KledingKleur.R)) ? 0 : ((x.KledingKleur.G* x.KledingKleur.G) + (x.KledingKleur.B* x.KledingKleur.B) + (x.KledingKleur.R* x.KledingKleur.R) > (y.KledingKleur.G* y.KledingKleur.G) + (y.KledingKleur.B* y.KledingKleur.B) + (y.KledingKleur.R* y.KledingKleur.R)) ? 1 : -1;

        public void data ()
        {
            Console.WriteLine($"Aantal bezoekers: { bezoekers.Count }");
            Console.WriteLine($"Aantal rondes gemaakt door bezoekers: {rondes}");
            Console.WriteLine($"Top score: {bezoekers.Max(x => x.BehaaldePunten)}");
            Console.WriteLine($"Aantal bezoekers in rode kleding: {bezoekers.Count(x => colorsAreClose(x.KledingKleur, Color.FromName("red"), 100))} ");
            List<Sporter> kl = bezoekers.OrderByDescending(x => (Math.Pow(x.KledingKleur.R, 2) + Math.Pow(x.KledingKleur.G, 2) + Math.Pow(x.KledingKleur.B, 2))).ToList().GetRange(0, 10);

            foreach( Sporter s in kl)
            {
                Console.WriteLine($"Sporter: {s.ID} met kleur [{s.KledingKleur.R}, {s.KledingKleur.G}, {s.KledingKleur.B}]");
            }

            Console.Write("Unieke moves aan kabel: {");
            foreach (IMove m in kabel.getUniekeMoves().Distinct())
            {
                Console.Write($"{m}, ");
            }
            Console.WriteLine("}");
            Console.WriteLine("-----------------------");

        }
    } 
}
