using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using CaribbeanPoker.Main;
using Xunit;

namespace CaribbeanPoker.Test
{
    public class HandTestData
    {
        public static TheoryData<ReadOnlyCollection<Card>, HandCombination> TestCombinations =>
            new TheoryData<ReadOnlyCollection<Card>, HandCombination>
            {
                {
                    Array.AsReadOnly(new Card[]
                    {
                        new Card(Suit.Spades, Rank.Ten),
                        new Card(Suit.Spades, Rank.Jack),
                        new Card(Suit.Spades, Rank.Queen),
                        new Card(Suit.Spades, Rank.Ace),
                        new Card(Suit.Spades, Rank.King)
                    }),
                    HandCombination.royal_flush
                },
                {
                    Array.AsReadOnly(new Card[]
                    {
                        new Card(Suit.Clubs, Rank.Jack),
                        new Card(Suit.Clubs, Rank.Eight),
                        new Card(Suit.Clubs, Rank.Queen),
                        new Card(Suit.Clubs, Rank.Ten),
                        new Card(Suit.Clubs, Rank.Nine)
                    }),
                    HandCombination.straight_flush
                },
                {
                    Array.AsReadOnly(new Card[]
                    {
                        new Card(Suit.Spades, Rank.Ace),
                        new Card(Suit.Clubs, Rank.Ace),
                        new Card(Suit.Diamonds, Rank.Ace),
                        new Card(Suit.Hearts, Rank.Ace),
                        new Card(Suit.Spades, Rank.Two)
                    }),
                    HandCombination.quads
                },
                {
                    Array.AsReadOnly(new Card[]
                    {
                        new Card(Suit.Spades, Rank.Queen),
                        new Card(Suit.Clubs, Rank.Queen),
                        new Card(Suit.Hearts, Rank.Queen),
                        new Card(Suit.Hearts, Rank.Two),
                        new Card(Suit.Spades, Rank.Two)
                    }),
                    HandCombination.full
                },
                {
                    Array.AsReadOnly(new Card[]
                    {
                        new Card(Suit.Diamonds, Rank.Two),
                        new Card(Suit.Diamonds, Rank.Five),
                        new Card(Suit.Diamonds, Rank.Seven),
                        new Card(Suit.Diamonds, Rank.Ace),
                        new Card(Suit.Diamonds, Rank.King)
                    }),
                    HandCombination.flush
                },
                {
                    Array.AsReadOnly(new Card[]
                    {
                        new Card(Suit.Spades, Rank.Ace),
                        new Card(Suit.Spades, Rank.Two),
                        new Card(Suit.Spades, Rank.Three),
                        new Card(Suit.Clubs, Rank.Four),
                        new Card(Suit.Spades, Rank.Five)
                    }),
                    HandCombination.straight
                },
                {
                    Array.AsReadOnly(new Card[]
                    {
                        new Card(Suit.Spades, Rank.Ace),
                        new Card(Suit.Clubs, Rank.Nine),
                        new Card(Suit.Diamonds, Rank.Two),
                        new Card(Suit.Hearts, Rank.Two),
                        new Card(Suit.Spades, Rank.Two)
                    }),
                    HandCombination.triplets
                },
                {
                    Array.AsReadOnly(new Card[]
                    {
                        new Card(Suit.Spades, Rank.Ace),
                        new Card(Suit.Clubs, Rank.Ace),
                        new Card(Suit.Diamonds, Rank.Five),
                        new Card(Suit.Hearts, Rank.Two),
                        new Card(Suit.Spades, Rank.Two)
                    }),
                    HandCombination.two_pair
                },
                {
                    Array.AsReadOnly(new Card[]
                    {
                        new Card(Suit.Spades, Rank.Jack),
                        new Card(Suit.Clubs, Rank.King),
                        new Card(Suit.Hearts, Rank.Queen),
                        new Card(Suit.Hearts, Rank.Two),
                        new Card(Suit.Spades, Rank.Two)
                    }),
                    HandCombination.pair
                },
                {
                    Array.AsReadOnly(new Card[]
                    {
                        new Card(Suit.Clubs, Rank.Two),
                        new Card(Suit.Diamonds, Rank.Five),
                        new Card(Suit.Hearts, Rank.Seven),
                        new Card(Suit.Diamonds, Rank.Ace),
                        new Card(Suit.Spades, Rank.King)
                    }),
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
                    var hand1 = new Hand {Cards = (ReadOnlyCollection<Card>) testCombinations[i][0]};
                    var hand2 = new Hand {Cards = (ReadOnlyCollection<Card>) testCombinations[i + 1][0]};
                    data.Add(hand1, hand2);
                }
                // Add pair which only differs by the last card. Needed to fully test CompareByRanks method.
                var newCards = new Card[5];
                ((ReadOnlyCollection<Card>) testCombinations[^1][0]).CopyTo(newCards, 0);
                newCards[0] = new Card(Suit.Clubs, Rank.Three);
                var newHandNothing = new Hand {Cards = Array.AsReadOnly(newCards)}; // altered hand without any combination.
                data.Add(newHandNothing, new Hand { Cards = (ReadOnlyCollection<Card>)testCombinations[^1][0] });

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
                    var hand1 = new Hand { Cards = (ReadOnlyCollection<Card>)t[0] };
                    var hand2 = new Hand { Cards = (ReadOnlyCollection<Card>)t[0] };
                    data.Add(hand1, hand2);
                }
                return data;
            }
        }

        public static TheoryData<int, bool, bool> TestFlipCardsArguments =>
            new TheoryData<int, bool, bool>
            {
                {5, true, true},
                {5, false, true},
                {5, true, false},
                {5, false, false},
                {3, true, true}
            };

    }
}

