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
                Console.Write(dealerHand[i].Name + " | ");
            }
            Console.WriteLine();
            
            dealerHand.Sort(new CardComparer_Value());
            Console.WriteLine("Dealer hand sorted by value:");
            for (int i = 0; i < 5; i++)
            {
                Console.Write(dealerHand[i].Name + " | ");
            }
            Console.WriteLine();
            
            dealerHand.Sort(new CardComparer_Suits());
            Console.WriteLine("Dealer hand sorted by suits:");
            for (int i = 0; i < 5; i++)
            {
                Console.Write(dealerHand[i].Name + " | ");
            }
            Console.WriteLine();
            
            playerHand = talia.handDeck();
            Console.WriteLine("Player hand:");
            for (int i = 0; i < 5; i++)
            {
                Console.Write(playerHand[i].Name + " | ");
            }
            Console.WriteLine();
            
            playerHand.Sort(new CardComparer_Value());
            Console.WriteLine("Player hand sorted by value:");
            for (int i = 0; i < 5; i++)
            {
                Console.Write(playerHand[i].Name + " | ");
            }
            Console.WriteLine();

            playerHand.Sort(new CardComparer_Suits());
            Console.WriteLine("Player hand sorted by suits:");
            for (int i = 0; i < 5; i++)
            {
                Console.Write(playerHand[i].Name + " | ");
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("\U0001F0A0  ");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("\U0001F0A1  "); //As
            Console.Write("\U0001F0A2  ");
            Console.Write("\U0001F0A3  ");
            Console.Write("\U0001F0A4  ");
            Console.Write("\U0001F0A5  ");
            Console.Write("\U0001F0A6  ");
            Console.Write("\U0001F0A7  ");
            Console.Write("\U0001F0A8  ");
            Console.Write("\U0001F0A9  ");
            Console.Write("\U0001F0AA  ");
            Console.Write("\U0001F0AB  ");
            //Console.Write("\U0001F0AC  ");
            Console.Write("\U0001F0AD  ");
            Console.WriteLine("\U0001F0AE  ");
            Console.WriteLine();
            Console.Write("\U0001F0B1  ");
            Console.Write("\U0001F0B2  ");
            Console.Write("\U0001F0B3  ");
            Console.Write("\U0001F0B4  ");
            Console.Write("\U0001F0B5  ");
            Console.Write("\U0001F0B6  ");
            Console.Write("\U0001F0B7  ");
            Console.Write("\U0001F0B8  ");
            Console.Write("\U0001F0B9  ");
            Console.Write("\U0001F0BA  ");
            Console.Write("\U0001F0BB  ");
            //Console.Write("\U0001F0BC  ");
            Console.Write("\U0001F0BD  ");
            Console.WriteLine("\U0001F0BE  ");
            Console.WriteLine();
            Console.Write("\U0001F0C1  ");
            Console.Write("\U0001F0C2  ");
            Console.Write("\U0001F0C3  ");
            Console.Write("\U0001F0C4  ");
            Console.Write("\U0001F0C5  ");
            Console.Write("\U0001F0C6  ");
            Console.Write("\U0001F0C7  ");
            Console.Write("\U0001F0C8  ");
            Console.Write("\U0001F0C9  ");
            Console.Write("\U0001F0CA  ");
            Console.Write("\U0001F0CB  ");
            //Console.Write("\U0001F0CC  ");
            Console.Write("\U0001F0CD  ");
            Console.WriteLine("\U0001F0CE  ");
            Console.WriteLine();
            Console.Write("\U0001F0D1  ");
            Console.Write("\U0001F0D2  ");
            Console.Write("\U0001F0D3  ");
            Console.Write("\U0001F0D4  ");
            Console.Write("\U0001F0D5  ");
            Console.Write("\U0001F0D6  ");
            Console.Write("\U0001F0D7  ");
            Console.Write("\U0001F0D8  ");
            Console.Write("\U0001F0D9  ");
            Console.Write("\U0001F0DA  ");
            Console.Write("\U0001F0DB  ");
            //Console.Write("\U0001F0DC  ");
            Console.Write("\U0001F0DD  ");
            Console.WriteLine("\U0001F0DE  ");
            
        }
    }
}
