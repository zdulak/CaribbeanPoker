using System;
using System.Collections.Generic;
using System.Text;

namespace CaribbeanPokerMain
{
    class Gambler
    {
        public int Money {get; set; }
        public Controller TheController {get;}
        public Hand Hand { get; }
        public Gambler()
        {
            Money = 1000;
            TheController = new Controller();
            Hand = new Hand();
        } 
        public bool IsBroke() => Money <= 0;
    }
}