using System;
using System.Collections.Generic;
using System.Text;
using CaribbeanPoker.Main;

namespace CaribbeanPoker.Test
{
    class HandTestData
    {
        public static IEnumerable<object[]> TestCombinations
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
                    },
                    HandCombination.nothing
                };
                yield return new object[]
                {
                    new Card[]
                    {
                        new Card(Suit.Spades, Rank.Ten),
                        new Card(Suit.Spades, Rank.Jack),
                        new Card(Suit.Spades, Rank.Queen),
                        new Card(Suit.Spades, Rank.Ace),
                        new Card(Suit.Spades, Rank.King)
                    },
                    HandCombination.royal_flush
                };
                yield return new object[]
                {
                    new Card[]
                    {
                        new Card(Suit.Clubs, Rank.Jack),
                        new Card(Suit.Clubs, Rank.Eight),
                        new Card(Suit.Clubs, Rank.Queen),
                        new Card(Suit.Clubs, Rank.Ten),
                        new Card(Suit.Clubs, Rank.Nine)
                    },
                    HandCombination.straight_flush
                };
                yield return new object[]
                {
                    new Card[]
                    {
                        new Card(Suit.Spades, Rank.Ace),
                        new Card(Suit.Clubs, Rank.Ace),
                        new Card(Suit.Diamonds, Rank.Ace),
                        new Card(Suit.Hearts, Rank.Ace),
                        new Card(Suit.Spades, Rank.Two)
                    },
                    HandCombination.quads
                };
                yield return new object[]
                {
                    new Card[]
                    {
                        new Card(Suit.Spades, Rank.Queen),
                        new Card(Suit.Clubs, Rank.Queen),
                        new Card(Suit.Hearts, Rank.Queen),
                        new Card(Suit.Hearts, Rank.Two),
                        new Card(Suit.Spades, Rank.Two)
                    },
                    HandCombination.full
                };
                yield return new object[]
                {
                    new Card[]
                    {
                        new Card(Suit.Diamonds, Rank.Two),
                        new Card(Suit.Diamonds, Rank.Five),
                        new Card(Suit.Diamonds, Rank.Seven),
                        new Card(Suit.Diamonds, Rank.Ace),
                        new Card(Suit.Diamonds, Rank.King)
                    },
                    HandCombination.flush
                };
                yield return new object[]
                {
                    new Card[]
                    {
                        new Card(Suit.Spades, Rank.Ace),
                        new Card(Suit.Spades, Rank.Two),
                        new Card(Suit.Spades, Rank.Three),
                        new Card(Suit.Clubs, Rank.Four),
                        new Card(Suit.Spades, Rank.Five)
                    },
                    HandCombination.straight
                };
                yield return new object[]
                {
                    new Card[]
                    {
                        new Card(Suit.Spades, Rank.Ace),
                        new Card(Suit.Clubs, Rank.Nine),
                        new Card(Suit.Diamonds, Rank.Two),
                        new Card(Suit.Hearts, Rank.Two),
                        new Card(Suit.Spades, Rank.Two)
                    },
                    HandCombination.triplets
                };
                yield return new object[]
                {
                    new Card[]
                    {
                        new Card(Suit.Spades, Rank.Ace),
                        new Card(Suit.Clubs, Rank.Ace),
                        new Card(Suit.Diamonds, Rank.Five),
                        new Card(Suit.Hearts, Rank.Two),
                        new Card(Suit.Spades, Rank.Two)
                    },
                    HandCombination.two_pair
                };
                yield return new object[]
                {
                    new Card[]
                    {
                        new Card(Suit.Spades, Rank.Jack),
                        new Card(Suit.Clubs, Rank.King),
                        new Card(Suit.Hearts, Rank.Queen),
                        new Card(Suit.Hearts, Rank.Two),
                        new Card(Suit.Spades, Rank.Two)
                    },
                    HandCombination.pair
                };
            }
        }
    }
}
