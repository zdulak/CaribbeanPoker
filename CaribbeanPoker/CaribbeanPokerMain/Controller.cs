using System;
using System.Collections.Generic;
using System.Text;

namespace CaribbeanPokerMain
{
    class Controller
    {
        public void Quit()
        {
            System.Environment.Exit(0);
        }
        public Ante GetAnte()
        {
            Ante ante = 0;
            while(ante == 0) 
            {
                Console.WriteLine("Bet obligatory Ante or write quit in order to close the program.");
                Console.Write("Possible values of the Ante: " );
                foreach (var name in Enum.GetValues(typeof(Ante))) Console.Write((int)name + " ");
                Console.Write("\n");
                try
                {
                    var  input = Console.ReadLine();
                    if (input.ToLower() == "quit") Quit();
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
                input = Console.ReadLine().ToUpper();
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
                Console.WriteLine("Do  you raise? Y/N");
                input = Console.ReadLine().ToUpper();
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
    }
}