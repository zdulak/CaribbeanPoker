using System;
using System.Collections.Generic;
using System.Text;

namespace battle_of_cards_grupauderzeniowa
{
    class Program
    {
        static void Main(string[] args)
        {
            // testowanie
            Deck talia = new Deck();
            talia.Shuffle();
            List<Card> dealerHand = new List<Card>();
            List<Card> playerHand = new List<Card>();
            
            
            
            dealerHand = talia.handDeck();
            Console.WriteLine("Dealer hand:");
            for (int i = 0; i < 5; i++)
            {
                Console.Write(dealerHand[i].Name + " - " + dealerHand[i].Icon + " | ");
            }
            Console.WriteLine();
            
            dealerHand.Sort(new CardComparer_Value());
            Console.WriteLine("Dealer hand sorted by value:");
            for (int i = 0; i < 5; i++)
            {
                Console.Write(dealerHand[i].Name + " - " + dealerHand[i].Icon + " | ");
            }
            Console.WriteLine();
            
            dealerHand.Sort(new CardComparer_Suits());
            Console.WriteLine("Dealer hand sorted by suits:");
            for (int i = 0; i < 5; i++)
            {
                Console.Write(dealerHand[i].Name + " - " + dealerHand[i].Icon + " | ");
            }
            Console.WriteLine();
            
            playerHand = talia.handDeck();
            Console.WriteLine("Player hand:");
            for (int i = 0; i < 5; i++)
            {
                Console.Write(dealerHand[i].Name + " - " + dealerHand[i].Icon + " | ");
            }
            Console.WriteLine();
            
            playerHand.Sort(new CardComparer_Value());
            Console.WriteLine("Player hand sorted by value:");
            for (int i = 0; i < 5; i++)
            {
                Console.Write(dealerHand[i].Name + " - " + dealerHand[i].Icon + " | ");
            }
            Console.WriteLine();

            playerHand.Sort(new CardComparer_Suits());
            Console.WriteLine("Player hand sorted by suits:");
            for (int i = 0; i < 5; i++)
            {
                Console.Write(dealerHand[i].Name + " - " + dealerHand[i].Icon + " | ");
            }
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
