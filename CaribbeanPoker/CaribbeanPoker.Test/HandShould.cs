using System;
using Xunit;
using CaribbeanPokerMain;

namespace CaribbeanPoker.Test
{
    public class HandShould
    {
        private readonly Hand _hand;
        public HandShould(Hand hand)
        {
            _hand = hand;
        }
        [Theory]
        [InlineData()]
        public void GetHandCombination_NoCombination_ReturnNothing(Card[] cards)
        {
            _hand.Cards = cards;
            var handCombination = _hand.GetHandCombination();
            Assert.Equal(HandCombination.nothing, handCombination);
        }
    }
}
