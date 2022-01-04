using System;
using System.Collections.Generic;
using System.Text;

namespace CaribbeanPokerMain
{
    class Dealer : Hand
    {
        public Dealer() {}
        public Dealer(Card[] cards): base(cards) {}
        public bool IsQualify()
        {
            throw new System.NotImplementedException();
        } 
    }
}