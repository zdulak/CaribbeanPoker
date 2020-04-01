using System;
using System.Collections.Generic;
using System.Linq;

namespace CaribbeanPokerMain
{
    class Hand : IComparable<Hand>, IEquatable<Hand>
    {
        public Card[] Cards {get; set;}
        // Method flips first n cards  
        public void FlipCards(int number)
        {
            for (int i = 0; i < number; ++i) Cards[i].FaceUp = true;
        }
        // Method sorts cards first by ranks and then by suits.
        public void Sort()
        {
            var cardComparer = new CardComparer(CardComparer.CompareBy.Rank);
            Array.Sort(Cards, cardComparer);
            cardComparer.CompareField = CardComparer.CompareBy.Suit;
            Array.Sort(Cards, cardComparer);
        }
        public int CompareTo(Hand other)
        {
            var thisHandCombination = GetHandCombination();
            var otherHandCombination = other.GetHandCombination();
            if (thisHandCombination != otherHandCombination)
            {
               return thisHandCombination.CompareTo(otherHandCombination); 
            }
            else
            {
                return EqualCombinationComparer(thisHandCombination, other);
            }
        }
        public bool Equals(Hand other) => CompareTo(other) == 0 ? true: false;
        private bool IsStraight()
        {
            var lowestStraight = new Rank[] {Rank.As, Rank.Five, Rank.Four, Rank.Three, Rank.Two};
            if (Cards.Select(x => x.Rank).SequenceEqual(lowestStraight)) return true;
            for (int i = 0; i < Cards.Length - 1; ++i)
            {
                if (Cards[i+1].Rank + 1 != Cards[i].Rank) return false;
            }
            return true;
        }
        public static bool operator > (Hand op1, Hand op2)
        {
            return op1.CompareTo(op2) == 1;
        }
        public static bool operator < (Hand op1, Hand op2)
        {
            return op1.CompareTo(op2) == -1;
        }
        public static bool operator != (Hand op1, Hand op2)
        {
            return op1.Equals(op2);
        }
        public static bool operator == (Hand op1, Hand op2)
        {
            return op1.Equals(op2);
        }
        private IEnumerable<IGrouping<Rank, Card>> GroupByRank() => Cards.GroupBy(x => x.Rank);

        public HandCombination GetHandCombination()
        {
            Sort();
            var isStraight = IsStraight();
            var groupsByRank = GroupByRank();
            var isFlush = Cards.All(x => x.Suit == Cards.First().Suit);
            var isTriplets = groupsByRank.Any(x => x.Count() == 3);
            var isPair = groupsByRank.Any(x => x.Count() == 2);
            if (isFlush && isStraight && Cards[0].Rank == Rank.As) return HandCombination.royal_flush;
            if (isFlush && isStraight ) return HandCombination.straight_flush;
            if (groupsByRank.Any(x => x.Count() == 4)) return HandCombination.quads;
            if (isTriplets && isPair) return HandCombination.full;
            if (isFlush) return HandCombination.flush;
            if (isStraight) return HandCombination.straight;
            if (isTriplets) return HandCombination.triplets;
            if (groupsByRank.Where(x => x.Count() == 2).Count() == 2) return HandCombination.two_pair;
            if (isPair) return HandCombination.pair;
            return HandCombination.nothing;
        }
        private int EqualCombinationComparer(HandCombination handCombination, Hand other)
        {
            if (handCombination == HandCombination.royal_flush 
                || handCombination == HandCombination.straight_flush
                || handCombination == HandCombination.straight)
            {
                return Cards[0].Rank.CompareTo(other.Cards[0].Rank);   
            }
            else
            {
                return CompareByGroups(other);
            }
        }
        private int CompareByGroups(Hand other)
        {
            var thisGroups = GroupByRank().OrderByDescending(x => x.Count()).ThenByDescending(x => x.Key);
            var otherGroups = other.GroupByRank().OrderByDescending(x => x.Count()).ThenByDescending(x => x.Key);
            var pairsGroups = thisGroups.Zip(otherGroups, (x,y) => (x,y));
            foreach (var pair in pairsGroups)
            {
                if (pair.x.Key > pair.y.Key) return 1;
                if (pair.x.Key < pair.y.Key) return -1;
            }
            return 0;
        }
    } 
}