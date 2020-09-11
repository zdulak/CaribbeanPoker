using System;
using System.Collections.ObjectModel;
using System.Linq;
using Xunit;
using Xunit.Abstractions;
using CaribbeanPoker.Main;

namespace CaribbeanPoker.Test
{
    [Trait("Category", "Hand")]
    public class HandShould
    {
        private readonly ITestOutputHelper _output;
        public HandShould(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void CardsProperty_ForWrongNumberOfCards_ThrowException()
        {
            var testCards = Array.AsReadOnly(new Card[] {new Card(Suit.Spades, Rank.Jack),
                new Card(Suit.Clubs, Rank.King)});
            var hand = new Hand();

            var ex = Assert.Throws<ArgumentException>(() => hand.Cards = testCards);
            Assert.Equal("Cards collection have an invalid length. Acceptable length is 5.", ex.Message);
        }
        [Theory]
        [MemberData(nameof(HandTestData.TestCombinations), MemberType = typeof(HandTestData))]
        public void HandCombination_ForCards_ReturnProperCombination(ReadOnlyCollection<Card> cards, HandCombination expectedCombination)
        {
            var hand = new Hand {Cards = cards};

            var actualCombination = hand.HandCombination;
            //_output.WriteLine(string.Join<Card>(", ", _hand.Cards));
            Assert.Equal(expectedCombination, actualCombination);
        }

        [Theory]
        [MemberData(nameof(HandTestData.TestPairsHandsFirstGreater), MemberType = typeof(HandTestData))]
        public void ComparisonOperators_ForTwoHands_FirstGreater(Hand hand1, Hand hand2)
        {
            Assert.True(hand1 > hand2);
            Assert.True(hand2 < hand1);
            Assert.True(hand1 != hand2);
        }
        [Theory]
        [MemberData(nameof(HandTestData.TestPairsHandsEqual), MemberType = typeof(HandTestData))]
        public void ComparisonOperators_ForTwoHands_Equal(Hand hand1, Hand hand2)
        {
            Assert.True(hand1 == hand2);
            Assert.False(hand1 > hand2);
            Assert.False(hand2 < hand1);
        }

        [Theory]
        [MemberData(nameof(HandTestData.TestFlipCardsArguments), MemberType = typeof(HandTestData))]
        public void FlipCards_ProperlyCardsFlipped(int number, bool sorted, bool faceUp)
        {
            var hand = new Hand {Cards = (ReadOnlyCollection<Card>) HandTestData.TestCombinations.First()[0]};

            hand.FlipCards(number, sorted, faceUp);

            Assert.True(sorted
                ? hand.SortedCards.Take(number).All(c => c.FaceUp == faceUp)
                : hand.Cards.Take(number).All(c => c.FaceUp == faceUp));
        }
    }
}
