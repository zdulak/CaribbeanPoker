using System;
using System.Collections.Generic;

namespace battle_of_cards_grupauderzeniowa
{
    public class CardComparer_Value : IComparer<Card>
    {
        public int Compare(Card a, Card b)
        {
            if(a.Rank > b.Rank) return -1;
            if(a.Rank < b.Rank) return 1;
            return 0;
        }
    }
}
