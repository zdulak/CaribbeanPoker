using System;
using Xunit;
using Xunit.Abstractions;
using CaribbeanPokerMain;
using System.Collections.Generic;

namespace CaribbeanPoker.Test
{
    [Trait("Category", "Hand")]
    public class HandShould
    {
        private readonly ITestOutputHelper _output;
        private readonly Hand _hand;
        public HandShould(ITestOutputHelper output)
        {
            _output = output;
            _hand = new Hand();
        }
        [Theory]
        [MemberData(nameof(HandTestData.TestCardsNothing), MemberType = typeof(HandTestData))]
        public void GetHandCombination_NoCombination_ReturnTheSame(Card[] cards)
        {
            _hand.Cards = cards;
            var actualCombination = _hand.GetHandCombination();
            //_output.WriteLine("");
            Assert.Equal(HandCombination.nothing, actualCombination);
        }
        [Theory]
        [MemberData(nameof(HandTestData.TestCardsRoyalFlush), MemberType = typeof(HandTestData))]
        public void GetHandCombination_RoyalFlush_ReturnTheSame(Card[] cards)
        {
            _hand.Cards = cards;
            var actualCombination = _hand.GetHandCombination();
            //_output.WriteLine("");
            Assert.Equal(HandCombination.royal_flush, actualCombination);
        }
    }
}
