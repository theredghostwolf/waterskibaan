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
            while (node != null)
            {
                node.Value.PositieOpKabel++;
                if (node.Value.PositieOpKabel > 9)
                {
                    node.Value.PositieOpKabel = 0;
                }
                node = node.Next;
            }

        }

        public Lijn verwijderLijnVanKabel()
        {
            LinkedListNode<Lijn> node = lijnen.First;
            while (node != null)
            {
                if (node.Value.PositieOpKabel == 9)
                {
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
    }
}

