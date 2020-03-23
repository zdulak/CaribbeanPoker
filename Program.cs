using System;
using System.Collections.Generic;

namespace battle_of_cards_grupauderzeniowa
{
    class Program
    {
        static void Main(string[] args)
        {
            // testowanie
            Deck talia = new Deck();
            talia.Shuffle();
            foreach (string item in talia.GetCardNames())
            {
                Console.WriteLine(item);
            }
        }
    }
}
