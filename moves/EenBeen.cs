using System;
namespace WaterskiBaan.moves
{
    public class EenBeen : IMove
    {
        public EenBeen()
        {
        }

        public int Move()
        {
            if (MoveCollection.rng(5))
            {
                return 7;
            }
            else
            {
                return 0;
            }
        }
    }
}
