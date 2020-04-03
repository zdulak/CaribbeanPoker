using System;

namespace CaribbeanPokerMain
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.Clear();
            Game game = new Game();
            game.Run();
            
        }
    }
}
