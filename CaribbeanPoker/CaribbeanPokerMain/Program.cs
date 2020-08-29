using System;
using Autofac;

namespace CaribbeanPokerMain
{
    class Program
    {
        public static void Main(string[] args)
        {
            //Console.OutputEncoding = System.Text.Encoding.UTF8;
            var game = new Game();
            game.Run();
            
        }
    }
}
