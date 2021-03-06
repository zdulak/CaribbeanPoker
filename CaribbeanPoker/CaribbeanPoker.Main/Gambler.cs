using System;
using System.Collections.Generic;
using System.Text;

namespace CaribbeanPoker.Main
{
    public class Gambler : IGambler
    {
        public IWallet Wallet { get; }
        public IController Controller { get;}
        public Hand Hand { get; }
        public Gambler(IController controller, IWallet wallet, Hand hand)
        {
            Wallet = wallet;
            Controller = controller;
            Hand = hand;
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
        public bool PayJackpot(int ante, int jackpotAnte, ref int jackpot)
        {
            bool isJackpot = false;
            if (Wallet.IsEnoughForJackpot(ante, jackpotAnte))
            {
                isJackpot = Controller.GetAnswer("Do  you want to participate in the jackpot?");
                if (isJackpot)
                {
                    Wallet.Money -= jackpotAnte;
                    jackpot += jackpotAnte;
                }
            }
            return isJackpot;
        }
    }
}