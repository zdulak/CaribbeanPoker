using System;
using System.Collections.Generic;
using System.Text;

namespace CaribbeanPokerMain
{
    class Dealer : Hand
    {
        public bool IsQualify()
        {
            if (GetHandCombination() > HandCombination.nothing || (SortedCards[0].Rank == Rank.Ace 
                && SortedCards[1].Rank == Rank.King))
            {
                return true;
            }
            return false;
        } 
    }
}