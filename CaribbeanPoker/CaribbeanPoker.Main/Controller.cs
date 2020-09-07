using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CaribbeanPoker.Main
{
    class Controller : IController
    {
        public IView View { get; }

        public Controller(IView view)
        {
            View = view;
        }

        public void Quit()
        {
            Environment.Exit(0);
        }
        public int GetAnte()
        {
            while (true)
            {
                View.PrintMsg("Bet obligatory ante or write quit in order to close the program.");
                View.PrintMsg("Possible values of the ante: " + string.Join(" ", Ante.PossibleValues));
                var input = Console.ReadLine();
                if (input == "quit")
                {
                    Quit();
                }
                if (int.TryParse(input, out int ante) && Ante.PossibleValues.Contains(ante))
                {
                    return ante;
                }
                View.PrintMsg("You have entered an invalid value");
            }
        }
        public bool GetAnswer(string message)
        {
            while (true)
            {
                View.PrintMsg(message + " Y/N");
                var input = Console.ReadLine().ToUpper();
                switch (input)
                {
                    case "Y":
                        return true;
                    case "N":
                        return false;
                    default:
                        View.PrintMsg("You have entered an invalid value");
                        break;
                }
            }
        }
    }
}