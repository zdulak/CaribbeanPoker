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
        [Theory]
        [MemberData(nameof(HandTestData.TestCombinations), MemberType = typeof(HandTestData))]
        public void GetHandCombination_ForCards_ReturnProperCombination(Card[] cards, HandCombination expectedCombination)
        {
            var hand = new Hand {Cards = cards};

            var actualCombination = hand.GetHandCombination();
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
            var hand = new Hand {Cards = (Card[]) HandTestData.TestCombinations.First()[0]};

            hand.FlipCards(number, sorted, faceUp);

            Assert.True(sorted
                ? hand.SortedCards.Take(number).All(c => c.FaceUp == faceUp)
                : hand.Cards.Take(number).All(c => c.FaceUp == faceUp));
        }
    }
}
