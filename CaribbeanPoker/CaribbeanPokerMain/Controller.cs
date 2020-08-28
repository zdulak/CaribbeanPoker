using System;
using System.Collections.Generic;
using System.Text;

namespace CaribbeanPokerMain
{
    class Controller
    {

        public void Quit()
        {
            Environment.Exit(0);
        }
        public int GetAnte()
        {
            while(true) 
            {
                Console.WriteLine("Bet obligatory ante or write quit in order to close the program.");
                Console.Write("Possible values of the ante: " );
                foreach (var name in Ante.PossibleValues)
                {
                    Console.Write(name + " ");
                }
                Console.Write("\n");
                var input = Console.ReadLine();
                if (input == "quit")
                {
                    Quit();
                }
                else
                {
                    if (!int.TryParse(input, out int ante))
                    {
                        Console.WriteLine("You have entered an invalid value");
                        continue;
                    }
                    foreach (var anteValue in Ante.PossibleValues)
                    {
                        if (ante == anteValue)
                        {
                            return ante;
                        }
                    }
                }
            }
        }
        public bool GetAnswer(string message)
        {
            var input = "start";
            while(input != "Y")
            {
                Console.WriteLine(message + " Y/N");
                input = Console.ReadLine().ToUpper();
                switch (input)
                {
                    case "Y":
                        return true;
                    case "N":
                        return false;
                    default:
                        Console.WriteLine("You have entered an invalid value");
                        break;
                }
            }
            return true;
        }
    }
}