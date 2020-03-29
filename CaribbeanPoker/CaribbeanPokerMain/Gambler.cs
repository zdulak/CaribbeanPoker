using System;
using System.Collections.Generic;
using System.Text;

namespace CaribbeanPokerMain
{
    class Gambler : Hand
    {
        public int Money {get;set;}
        public Gambler() => Money = 1000;
        public void Quit()
        {
            throw new System.NotImplementedException();
        }
        public Ante GetAnte()
        {
            throw new System.NotImplementedException();
        }
        public bool GetJackpot()
        {
            throw new System.NotImplementedException();
        }
        public bool GetCall()
        {
            throw new System.NotImplementedException();
        }
        public bool IsBroke()
        {
            throw new System.NotImplementedException();
        }
    }
}