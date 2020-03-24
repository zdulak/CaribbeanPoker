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
            Card[] dealerHand = new Card[5];
            Card[] playerHand = new Card[5];
            dealerHand = talia.handDeck();
            playerHand = talia.handDeck();
            Console.WriteLine("Dealer hand:");
            for (int i = 0; i < 5; i++)
            {
                Console.Write(dealerHand[i].Name + " / ");
            }
            Console.WriteLine();
            Console.WriteLine("Player hand:");
            for (int i = 0; i < 5; i++)
            {
                Console.Write(playerHand[i].Name + " / ");
            }
            Console.WriteLine();
        }
    }
}
