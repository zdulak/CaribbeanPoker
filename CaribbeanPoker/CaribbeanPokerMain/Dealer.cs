using System;
using System.Collections.Generic;
using System.Text;

namespace CaribbeanPokerMain
{
    class Dealer
    {
        public Hand Hand { get; }

        public Dealer() => Hand = new Hand();

        public bool IsQualify() => Hand.GetHandCombination() > HandCombination.nothing || (Hand.SortedCards[0].Rank == Rank.Ace 
        && Hand.SortedCards[1].Rank == Rank.King);
    }
}