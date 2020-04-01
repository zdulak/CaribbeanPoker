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
            System.Environment.Exit(0);;
        }
        public Ante GetAnte()
        {
            Ante ante = 0;
            while(ante == 0) 
            {
                Console.WriteLine("Bet obligatory Ante or write quit in order to close the program:");
                try
                {
                    var  input = Console.ReadLine();
                    if (input == "quit") Quit();
                    ante = (Ante)Enum.Parse(typeof(Ante), input);
                }
                catch(Exception)
                {
                    Console.WriteLine("You have entered an invalid value.");
                    ante = 0;
                }
            } 
            return ante;

        }
        public bool GetJackpot()
        {
            var input = "start";
            while(input != "Y")
            {
                Console.WriteLine("Do  you want to participate in the jackpot? Y/N");
                input = Console.ReadLine();
                if (input == "Y")
                {
                    return true;
                }
                else if (input == "N")
                {
                    return false;  
                }
                else
                {
                    Console.WriteLine("You have entered an invalid value");
                }
            }
            return true;
        }
        public bool GetCall()
        {
            var input = "start";
            while(input != "Y")
            {
                Console.WriteLine("Do  you call? Y/N");
                input = Console.ReadLine();
                if (input == "Y")
                {
                    return true;
                }
                else if (input == "N")
                {
                    return false;  
                }
                else
                {
                    Console.WriteLine("You have entered an invalid value");
                }
            }
            return true;
        }
        public bool IsBroke() => Money <= 0 ? true: false; 
    }
}