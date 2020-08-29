using System;
using System.Collections.Generic;
using System.Text;

namespace CaribbeanPokerMain
{
    class Gambler
    {
        public Wallet Wallet { get; }
        public Controller Controller { get;}
        public Hand Hand { get; }
        public Gambler()
        {
            Wallet = new Wallet();
            Controller = new Controller();
            Hand = new Hand();
        }
    }
}