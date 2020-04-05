using System;
using System.Collections.Generic;
using System.Text;

namespace CaribbeanPokerMain
{
    class Gambler : Hand
    {
        public int Money {get;set;}
        public Controller TheController {get;} 
        public Gambler()
        {
            Money = 1000;
            TheController = new Controller();
        } 
        public bool IsBroke() => Money <= 0;
    }
}