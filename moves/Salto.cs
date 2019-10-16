using System;
namespace WaterskiBaan.moves
{
    public class Salto : IMove
    {
        public Salto()
        {
        }

        public int Move()
        {
            if (MoveCollection.rng(5))
            {
                return 15;
            }
            else
            {
                return 0;
            }
        }

        public override string ToString()
        {
            return "Salto";
        }
    }
}
