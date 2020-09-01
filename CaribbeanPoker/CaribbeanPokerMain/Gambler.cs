using System;
using System.Collections.Generic;
using System.Text;

namespace CaribbeanPokerMain
{
    class Gambler : IGambler
    {
        public IWallet Wallet { get; }
        public IController Controller { get;}
        public Hand Hand { get; }
        public Gambler(IController controller, IWallet wallet)
        {
            Wallet = wallet;
            Controller = controller;
            Hand = new Hand();
        }
        public int PayAnte()
        {
            bool isAntePaid = false;
            int ante = 0;
            while (!isAntePaid)
            {
                ante = Controller.GetAnte();
                if (Wallet.IsEnoughForAnte(ante))
                {
                    Wallet.Money -= ante;
                    isAntePaid = true;
                }
                else
                {
                    Controller.View.PrintMsg("Not enough money in the wallet. Choose smaller ante.");
                }
            }
            return ante;
        }
        public bool IsJackpot(int ante, int jackpotAnte)
        {
            bool isJackpot = false;
            if (Wallet.IsEnoughForJackpot(ante, jackpotAnte))
            {
                isJackpot = Controller.GetAnswer("Do  you want to participate in the jackpot?");
                if (isJackpot)
                {
                    Wallet.Money -= jackpotAnte;
                }
            }
            return isJackpot;
        }
    }
}