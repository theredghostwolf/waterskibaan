using System;
using System.Collections.Generic;
using System.Linq;

namespace WaterskiBaan
{
    public class Kabel
    {



        private LinkedList<Lijn> lijnen;

        public Kabel()
        {
            lijnen = new LinkedList<Lijn>();
            
        }

        public bool IsStartPositieLeeg()
        {
            if (lijnen.Count == 0)
            {
                return true;
            }
            LinkedListNode<Lijn> node = lijnen.First;
            while (node != null)
            {
                if (node.Value.PositieOpKabel == 0)
                {
                    return false;
                }
                node = node.Next;
            }
            return true;
        }

        public void VerschuifLijnen()
        {
            LinkedListNode<Lijn> node = lijnen.First;
            //test
            while (node != null)
            {
                //handle moves
                Random r = new Random();
                Sporter s = node.Value.sporter;


                if (r.Next(10000) > 7500) // +- 25% chance
                {
                    s.HuidigeMove = s.moves[r.Next(s.moves.Count)];
                    s.BehaaldePunten += s.HuidigeMove.Move();
                }


                node.Value.PositieOpKabel++;

                if (node.Value.PositieOpKabel > 9)
                {
                    node.Value.sporter.AantalRondenNogTeGaan--;
                    node.Value.PositieOpKabel = 0;
                    Logger.rondes++;
                }
                node = node.Next;
            }

        }

        public Lijn verwijderLijnVanKabel()
        {
            LinkedListNode<Lijn> node = lijnen.First;
            while (node != null)
            {
                if (node.Value.PositieOpKabel >= 9 && node.Value.sporter.AantalRondenNogTeGaan <= 1)
                {
                    Logger.rondes++;
                    lijnen.Remove(node);
                    return node.Value;
                    
                }
                node = node.Next;
            }
            return null;

        }

        public void NeemLijnInGebruik(Lijn lijn)
        {
            if (lijnen.Count <= 10 && IsStartPositieLeeg())
            {
                lijn.PositieOpKabel = 0;
                lijnen.AddFirst(lijn);
            }
        }

        public override string ToString()
        {
            string res = "";
            LinkedListNode<Lijn> node = lijnen.First;
            while (node != null)
            {
                res += node.Value.PositieOpKabel.ToString() + " | ";
                node = node.Next;
            }


            return res;

        }

        public List<IMove> getUniekeMoves ()
        {
            //return lijnen.Select(l => l.sporter.moves).Distinct().ToList();
            //return lijnen.SelectMany(l => l.sporter.moves).Distinct().ToList();

            List<IMove> moves = new List<IMove>();

            LinkedListNode<Lijn> node = lijnen.First;
            while (node != null)
            {

                List<IMove> sMoves = node.Value.sporter.moves;
                foreach (IMove sm in sMoves)
                {
                    bool exists = false;
                    foreach (IMove m in moves)
                    {
                        if (sm.GetType() == m.GetType())
                        {
                            exists = true;
                            break;
                        }
                    }
                    if (!exists)
                    {
                        moves.Add(sm);
                    }
                }

                node = node.Next;
            }

            return moves;
        }
    }
}

