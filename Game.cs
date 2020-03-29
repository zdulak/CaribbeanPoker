using System;
using System.Collections.Generic;
using System.Text;

namespace battle_of_cards_grupauderzeniowa
{
    class Game
    {
        // fields
        //private Player player;  
        private Deck deck;
        //private DisplayTable displayTable;
        //constructor
        public Game()
        {

        }
        public void Run()
        {
            //stałe obstawianie pola Ante
            int ante = 20;
            int call = 0;
            int current = 980;
            bool beforeCall = true;
            // utworzenie potasowanej talii 52 kart
            deck = new Deck();
            deck.Shuffle();
            // utworzenie dwóch "rąk"
            List <Card> dealerHand = new List<Card>();
            List<Card> playerHand = new List<Card>();
            dealerHand = deck.handDeck();
            List<Card> dealerHandCover = Turn(dealerHand);
            playerHand = deck.handDeck();
            // karta playera uporzadkowana
            playerHand.Sort(new CardComparer_Value());
            DisplayTable.DisplayBoard(dealerHandCover, playerHand, ante, call, current, beforeCall);
            Console.ReadKey();
            beforeCall = false;
            DisplayTable.DisplayBoard(dealerHand, playerHand, ante, call, current, beforeCall);
            HandCombination dealer = Analisis.HandAnalizer(dealerHand);
            HandCombination player = Analisis.HandAnalizer(playerHand);
            Hand handpower = new Hand(dealer);
            int outcome = handpower.CompareTo(player);
            if (outcome == 1) Console.WriteLine("Dealer won");
            else if (outcome == -1) Console.WriteLine ("You won");
            else Console.WriteLine("remis");
            //rozliczenie i powrót do początku
        }

        public List<Card> Turn(List<Card> lc)
        {
            Card backside = new Card(Suits.Clubs, Ranks.King, "\U0001F0A0  ");
            List<Card> outcome = new List<Card>();
            outcome.Add(lc[0]);
            for (int i = 0; i<4; i++)
            {
                outcome.Add(backside);
            }
            return outcome;
        }
        
        
          
        
        
            
                 
            

    }
}