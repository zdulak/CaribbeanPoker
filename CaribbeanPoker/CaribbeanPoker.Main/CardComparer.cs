using System;
using System.Collections.Generic;

namespace CaribbeanPokerMain
{
    class CardComparer : IComparer<Card>
    {
        public enum CompareBy
        {
            Suit,
            Rank
        }
        public  CompareBy CompareField {get; set;}
        public CardComparer(CompareBy compareField) => CompareField = compareField;
        public int Compare(Card x, Card y)
        {
            switch (CompareField)
            {
                case CompareBy.Suit:
                    return x.Suit.CompareTo(y.Suit);
                case CompareBy.Rank:
                    return -x.Rank.CompareTo(y.Rank); // Sort in descending order
                default:
                    throw new ArgumentException("Wrong type to comparison.");
            } 
        }
    }
}