using System;
using System.Collections.Generic;
using System.Text;
using CaribbeanPoker.Main;
using Xunit;
using Moq;

namespace CaribbeanPoker.Test
{
    [Trait("Category", "Gambler")]
    public class GamblerShould
    {
        [Fact]
        public void PayAnte_ForProperAnte_ReturnAnte()
        {
            var expectedAnte = Ante.PossibleValues[0];
            var mockController = new Mock<IController>();
            mockController.Setup(c => c.GetAnte()).Returns(expectedAnte);
            var mockWallet = new Mock<IWallet>();
            mockWallet.Setup(w => w.IsEnoughForAnte(expectedAnte)).Returns(true);
            var gambler = new Gambler(mockController.Object, mockWallet.Object, new Hand());

            var actualAnte = gambler.PayAnte();

            Assert.Equal(expectedAnte, actualAnte);
        }
    }
}
