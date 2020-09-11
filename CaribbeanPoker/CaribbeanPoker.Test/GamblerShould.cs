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
        public void PayAnte_ForProperAnte_ReturnAnteAndDecreaseWalletMoney()
        {
            //Arrange
            var expectedAnte = Ante.PossibleValues[2];
            const int initialMoney = 1000;

            var mockController = new Mock<IController>();
            mockController.Setup(c => c.GetAnte()).Returns(expectedAnte);

            var mockWallet = new Mock<IWallet>();
            mockWallet.Setup(w => w.IsEnoughForAnte(expectedAnte)).Returns(true);
            mockWallet.SetupProperty(w => w.Money, initialMoney);

            var gambler = new Gambler(mockController.Object, mockWallet.Object, new Hand());
            //Act
            var actualAnte = gambler.PayAnte();
            //Assert
            Assert.Equal(expectedAnte, actualAnte);
            Assert.Equal(initialMoney - expectedAnte, mockWallet.Object.Money);
        }
        [Fact]
        public void PayAnte_NotProperAnteThenProper_InvokePrintMsgThenReturnProperAnteAndDecreaseWalletMoney()
        {
            //Arrange
            var expectedAnte = Ante.PossibleValues[0];
            const int initialMoney = 1000;

            var mockController = new Mock<IController>();
            mockController.SetupSequence(c => c.GetAnte()).Returns(Ante.PossibleValues[3])
                .Returns(Ante.PossibleValues[0]);
            mockController.Setup(c => c.View.PrintMsg(It.IsAny<string>()));

            var mockWallet = new Mock<IWallet>();
            mockWallet.Setup(w => w.IsEnoughForAnte(It.IsNotIn(Ante.PossibleValues[3]))).Returns(true);
            mockWallet.SetupProperty(w => w.Money, initialMoney);

            var gambler = new Gambler(mockController.Object, mockWallet.Object, new Hand());
            //Act
            var actualAnte = gambler.PayAnte();
            //Assert
            mockController.Verify(c => c.View.PrintMsg(It.IsAny<string>()), Times.Once,
                "No message printed");
            Assert.Equal(expectedAnte, actualAnte);
            Assert.Equal(initialMoney - expectedAnte, mockWallet.Object.Money);
        }

        [Fact]
        public void PayJackpot_ForProperAnte_ReturnTrueAndIncreaseJackpotAndDecreaseMoney()
        {
            const int initialMoney = 1000;
            const int jackpotAnte = 10;
            const int initialJackpot = 100;
            var jackpot = initialJackpot;
            //Arrange
            var mockController = new Mock<IController>();
            mockController.Setup(c => c.GetAnswer(It.IsAny<string>())).Returns(true);

            var mockWallet = new Mock<IWallet>();
            mockWallet.SetupProperty(w => w.Money, initialMoney);
            mockWallet.Setup(w => w.IsEnoughForJackpot(Ante.PossibleValues[0], jackpotAnte)).Returns(true);

            var gambler = new Gambler(mockController.Object, mockWallet.Object, new Hand());
            //Act
            var isJackpot = gambler.PayJackpot(Ante.PossibleValues[0], jackpotAnte, ref jackpot);
            //Assert
            Assert.True(isJackpot);
            Assert.Equal(initialJackpot + jackpotAnte, jackpot);
            Assert.Equal(initialMoney - jackpotAnte, mockWallet.Object.Money);

        }
    }
}
