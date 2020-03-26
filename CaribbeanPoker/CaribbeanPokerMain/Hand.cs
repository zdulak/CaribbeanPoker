using System;
using System.Collections.Generic;

namespace CaribbeanPokerMain
{
    class Hand : IComparable<Hand>, IEquatable<Hand>
    {
        public Card[] cards {get; set;}
        public Hand() {}
        public Hand(Card[] cards) => this.cards = cards;
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