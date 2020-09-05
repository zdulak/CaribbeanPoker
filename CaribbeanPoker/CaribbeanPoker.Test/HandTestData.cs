using System;
using System.Collections.Generic;
using System.Text;
using CaribbeanPokerMain;

namespace CaribbeanPoker.Test
{
    class HandTestData
    {
        public static IEnumerable<object[]> TestCardsNothing
        {
            get
            {
                yield return new object[]
                {
                    new Card[]
                    {
                        new Card(Suit.Clubs, Rank.Two),
                        new Card(Suit.Diamonds, Rank.Five),
                        new Card(Suit.Hearts, Rank.Seven),
                        new Card(Suit.Diamonds, Rank.Ace),
                        new Card(Suit.Spades, Rank.King)
                    }
                };
                yield return new object[]
                {
                    new Card[]
                    {
                        new Card(Suit.Clubs, Rank.Two),
                        new Card(Suit.Diamonds, Rank.Jack),
                        new Card(Suit.Hearts, Rank.Queen),
                        new Card(Suit.Diamonds, Rank.Ace),
                        new Card(Suit.Spades, Rank.King)
                    }
                };

            }
        }
        public static IEnumerable<object[]> TestCardsRoyalFlush
        {
            get
            {
                yield return new object[]
                {
                    new Card[]
                    {
                        new Card(Suit.Spades, Rank.Ten),
                        new Card(Suit.Spades, Rank.Jack),
                        new Card(Suit.Spades, Rank.Queen),
                        new Card(Suit.Spades, Rank.Ace),
                        new Card(Suit.Spades, Rank.King)
                    }
                };
            }
        }
    }
}
