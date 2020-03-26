using System;
using System.Collections.Generic;
using System.Text;

namespace CaribbeanPokerMain
{
    class Gambler : Hand
    {
        public int Money {get;set;}
        public Gambler() => Money = 1000;
        public Gambler(Card[] cards): base(cards) => Money = 1000;
        public void Quit()
        {
            throw new System.NotImplementedException();
        }
        public Ante getAnte()
        {
            throw new System.NotImplementedException();
        }
        public bool getJackpot()
        {
            throw new System.NotImplementedException();
        }
        public bool getCall()
        {
            throw new System.NotImplementedException();
        }
        public bool isBroken()
        {
            throw new System.NotImplementedException();
        }
    }
}