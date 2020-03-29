using System;
using System.Collections;

namespace CaribbeanPokerMain
{
    class Hand : IComparable<Hand>, IEquatable<Hand>
    {
        public Card[] Cards {get; set;}
        // Method flips first n cards  
        public void FlipCards(int number)
        {
            throw new NotImplementedException();
        }
        public int HandRank()
        {
            throw new NotImplementedException();
        }
        // Method sorts cards first by suits and then by ranks.
        public void Sort()
        {
            var cardComparer = new CardComparer(CardComparer.CompareBy.Suit);
            Array.Sort(Cards, cardComparer);
            cardComparer.CompareField = CardComparer.CompareBy.Rank;
            Array.Sort(Cards, cardComparer);
        }
        public int CompareTo(Hand other)
        {
            throw new NotImplementedException();
        }

        public bool Equals(Hand other)
        {
            throw new NotImplementedException();
        }
    }
}