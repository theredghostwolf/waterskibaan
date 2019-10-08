using System;
using System.Collections.Generic;

namespace WaterskiBaan.moves
{
    public static class MoveCollection
    {
       

        public static bool rng (int chance)
        {
            Random r = new Random();
            if (r.Next(10) > chance)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static List<IMove> GetRandomMoves ()
        {
            List<IMove> moves = new List<IMove>();

            moves.Add(new EenBeen());
            moves.Add(new EenHand());
            moves.Add(new RondjeDraaien());
            moves.Add(new Salto());

            List<IMove> res = new List<IMove>();

            foreach(IMove m in moves)
            {
                if (rng(5))
                {
                    res.Add(m);
                }
            }
            if (res.Count == 0)
            {
                res.Add(new EenBeen());
            }
            return res;
        }
    }
}
