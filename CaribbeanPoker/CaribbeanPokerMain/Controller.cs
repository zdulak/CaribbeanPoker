using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CaribbeanPokerMain
{
    class Controller
    {
        private readonly View _view;

        public Controller()
        {
            _view = new View();
        }

        public void Quit()
        {
            Environment.Exit(0);
        }
        public int GetAnte()
        {
            while (true)
            {
                _view.PrintMsg("Bet obligatory ante or write quit in order to close the program.");
                _view.PrintMsg("Possible values of the ante: " + string.Join(" ", Ante.PossibleValues));
                var input = Console.ReadLine();
                if (input == "quit")
                {
                    Quit();
                }
                if (int.TryParse(input, out int ante) && Ante.PossibleValues.Contains(ante))
                {
                    return ante;
                }
                _view.PrintMsg("You have entered an invalid value");
            }
        }
        public bool GetAnswer(string message)
        {
            while (true)
            {
                _view.PrintMsg(message + " Y/N");
                var input = Console.ReadLine().ToUpper();
                switch (input)
                {
                    case "Y":
                        return true;
                    case "N":
                        return false;
                    default:
                        _view.PrintMsg("You have entered an invalid value");
                        break;
                }
            }
        }
    }
}