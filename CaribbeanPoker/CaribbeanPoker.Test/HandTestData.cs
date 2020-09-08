using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CaribbeanPoker.Main;
using Xunit;

namespace CaribbeanPoker.Test
{
    class HandTestData
    {
        public static TheoryData<Card[], HandCombination> TestCombinations =>
            new TheoryData<Card[], HandCombination>
            {
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
                },
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
                },
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
                },
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
                },
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
                },
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
                },
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
                },
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
                },
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
                },
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
                }
            };
    

        public static TheoryData<Hand, Hand> TestPairsHandsFirstGreater
        {
            get
            {
                var data = new TheoryData<Hand, Hand>();
                var testCombinations = TestCombinations.ToList();
                for (int i = 0; i < testCombinations.Count; i += 2)
                {
                    var hand1 = new Hand {Cards = (Card[]) testCombinations[i][0]};
                    var hand2 = new Hand {Cards = (Card[]) testCombinations[i + 1][0]};
                    data.Add(hand1, hand2);
                }
                // Add pair which only differs by the last card.
                var newCards = new Card[5];
                Array.Copy((Card[])testCombinations[^1][0], newCards, 5);
                newCards[0] = new Card(Suit.Clubs, Rank.Three);
                var newHandNothing = new Hand {Cards = newCards}; // altered hand without any combination.
                data.Add(newHandNothing, new Hand { Cards = (Card[])testCombinations[^1][0] });

                return data;
            }
        }
        public static TheoryData<Hand, Hand> TestPairsHandsEqual
        {
            get
            {
                var data = new TheoryData<Hand, Hand>();
                foreach (var t in TestCombinations)
                {
                    var hand1 = new Hand { Cards = (Card[])t[0] };
                    var hand2 = new Hand { Cards = (Card[])t[0] };
                    data.Add(hand1, hand2);
                }
                return data;
            }
        }
    }
}

