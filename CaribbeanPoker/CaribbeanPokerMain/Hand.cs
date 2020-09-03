using System;
using System.Collections.Generic;
using System.Linq;

namespace CaribbeanPokerMain
{
    class Hand : IComparable<Hand>, IEquatable<Hand>
    {
        private Card[] _cards;

        public Card[] Cards 
        {
            get => _cards;
            set
            {
                _cards = value;
                // Sort cards first by the size of the groups of identical ranks and then by ranks.
                // SelectMany only takes list of cards from each group and after that it flattens groups into one sequence.
                SortedCards = GroupByRank().OrderByDescending(x => x.Count())
                    .ThenByDescending(x => x.Key).SelectMany(x => x).ToArray();
                // If we have the lowest straight this method exchanges the Ace for the LowAce.
                AceExchange();
            }
        }
        public Card[] SortedCards { get; private set; }

        // Method flips the first n cards  
        public void FlipCards(int number, bool sorted, bool faceUp)
        {
            if (sorted)
            {
                for (var i = 0; i < number; ++i) SortedCards[i].FaceUp = faceUp;
            }
            else
            {
                for (var i = 0; i < number; ++i) Cards[i].FaceUp = faceUp;
            }
            
        }
        public int CompareTo(Hand other)
        {
            var thisCombination = GetHandCombination();
            var otherCombination = other.GetHandCombination();
            return thisCombination != otherCombination ? thisCombination.CompareTo(otherCombination) : CompareByRanks(other);
        }
        public bool Equals(Hand other) => CompareTo(other) == 0;
        public override bool Equals(object other)
        {
            // Check for null and compare run-time types.
            if ((other == null) || this.GetType() != other.GetType()) 
            {
                return false;
            }
            return Equals((Hand)other);
        }
        public static bool operator > (Hand op1, Hand op2) => op1.CompareTo(op2) == 1;
        public static bool operator < (Hand op1, Hand op2) => op1.CompareTo(op2) == -1;
        public static bool operator == (Hand op1, Hand op2) => !(op1 is null) && op1.Equals(op2);
        public static bool operator != (Hand op1, Hand op2) => !(op1 == op2);
        public override int GetHashCode() => SortedCards.Aggregate<Card, int>(1, (x, y) => x.GetHashCode() ^ y.GetHashCode());
        public HandCombination GetHandCombination()
        {
            var isStraight = IsStraight();
            var groupsByRank = GroupByRank().ToArray();
            var isFlush = SortedCards.All(x => x.Suit == SortedCards.First().Suit);
            var isTriplets = groupsByRank.Any(x => x.Count() == 3);
            var isPair = groupsByRank.Any(x => x.Count() == 2);
            if (isFlush && isStraight && SortedCards[0].Rank == Rank.Ace) return HandCombination.royal_flush;
            if (isFlush && isStraight ) return HandCombination.straight_flush;
            if (groupsByRank.Any(x => x.Count() == 4)) return HandCombination.quads;
            if (isTriplets && isPair) return HandCombination.full;
            if (isFlush) return HandCombination.flush;
            if (isStraight) return HandCombination.straight;
            if (isTriplets) return HandCombination.triplets;
            if (groupsByRank.Where(x => x.Count() == 2).Count() == 2) return HandCombination.two_pair;
            return isPair ? HandCombination.pair : HandCombination.nothing;
        }
        private int CompareByRanks(Hand other)
        {
            var pairsCards = SortedCards.Zip(other.SortedCards, (x,y) => (x,y));
            foreach (var (x, y) in pairsCards)
            {
                if (x.Rank > y.Rank) return 1;
                if (x.Rank < y.Rank) return -1;
            }
            return 0;
        }
        private IEnumerable<IGrouping<Rank, Card>> GroupByRank() => Cards.GroupBy(x => x.Rank);
        private bool IsStraight()
        {
            for (var i = 0; i < SortedCards.Length - 1; ++i)
            {
                if (SortedCards[i+1].Rank + 1 != SortedCards[i].Rank) return false;
            }
            return true;
        }
        private void AceExchange()
        {
            var lowestStraight = new Rank[] {Rank.Ace, Rank.Five, Rank.Four, Rank.Three, Rank.Two};
            if (SortedCards.Select(x => x.Rank).SequenceEqual(lowestStraight))
            {
                SortedCards[0] = new Card(SortedCards[0].Suit, Rank.LowAce, SortedCards[0].FaceUp, SortedCards[0].Picture);
                Array.Sort(SortedCards, (x,y) => -x.Rank.CompareTo(y.Rank)); // Sort cards in descending order;
            }
        }
        // // Method sorts cards first by ranks and then by suits.
        // public void Sort()
        // {
        //     var cardComparer = new CardComparer(CardComparer.CompareBy.Rank);
        //     Array.Sort(SortedCards, cardComparer);
        //     cardComparer.CompareField = CardComparer.CompareBy.Suit;
        //     Array.Sort(SortedCards, cardComparer);
        // }
    } 
}