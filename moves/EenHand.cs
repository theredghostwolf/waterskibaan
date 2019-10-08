using System;
namespace WaterskiBaan.moves
{
    public class EenHand : IMove
    {
        public EenHand()
        {
        }

        public int Move()
        {
            if (MoveCollection.rng(5))
            {
                return 5;
            }
            else
            {
                return 0;
            }
        }
    }
}
