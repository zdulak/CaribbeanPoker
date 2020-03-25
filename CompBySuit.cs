using System;
using System.Collections.Generic;

namespace battle_of_cards_grupauderzeniowa
{
    public class CardComparer_Suits : IComparer<Card>
    {
        public int Compare(Card a, Card b)
        {
            if(a.Suit > b.Suit) return -1;
            if(a.Suit < b.Suit) return 1;
            return 0;
        }
    }
}
