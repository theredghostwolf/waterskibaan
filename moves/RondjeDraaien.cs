using System;
namespace WaterskiBaan.moves
{
    public class RondjeDraaien : IMove
    {
        public RondjeDraaien()
        {
        }

        public int Move()
        {
            if (MoveCollection.rng(5))
            {
                return 12;
            }
            else
            {
                return 0;
            }
        }
    }
}
