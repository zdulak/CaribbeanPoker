using System.Collections.Generic;

namespace CaribbeanPokerMain
{
    class CardComparer : IComparer<Card>
    {
        public enum SortBy
        {
            Suit,
            Rank
        }
        public int Compare(Card x, Card y)
        {
            throw new System.NotImplementedException();
        }
    }
}