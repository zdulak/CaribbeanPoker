using System;
using System.Collections.Generic;
using System.Text;

namespace battle_of_cards_grupauderzeniowa
{
    class Gambler
    {
        private int money;
        
        public Gambler(int money)
        {
            this.money = money;
        }
        public int GetMoney()
        {
            return money;
        }
        public void SetMoney(int status)
        {
            money = status;
        }
        public bool SetCall()
        {
            Console.Write("Would you like to CALL - press Y: ");
            string choice1 = Console.ReadLine().ToUpper();
            if (choice1 == "Y") return true;
            return false;
        }

    }
}