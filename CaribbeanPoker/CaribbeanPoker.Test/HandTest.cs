using System;
using Xunit;
using Xunit.Abstractions;
using CaribbeanPoker.Main;

namespace CaribbeanPoker.Test
{
    [Trait("Category", "Hand")]
    public class HandTest
    {
        private readonly ITestOutputHelper _output;
        public HandTest(ITestOutputHelper output)
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
        [MemberData(nameof(HandTestData.TestCombinations), MemberType = typeof(HandTestData))]
        public void GreaterOperator_TwoHands_ReturnProperOrder(Hand hand1, Hand hand2)
        {
            Assert.True(hand1 > hand2);
            Assert.True(hand2 < hand1);
            Assert.True(hand1 != hand2);
        }
    }
}
