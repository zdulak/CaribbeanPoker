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
            int ante = 20;
            int call = 40;
            int current = 940;
            

            Deck talia = new Deck();
            talia.Shuffle();
            List<Card> dealerHand = new List<Card>();
            List<Card> playerHand = new List<Card>();
            dealerHand = talia.handDeck();
            playerHand = talia.handDeck();
            playerHand.Sort(new CardComparer_Value());
            
        
            DisplayTable.DisplayBoard(dealerHand,playerHand, ante, call,current);

        }
    }
}
