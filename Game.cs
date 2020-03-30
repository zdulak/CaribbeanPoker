using System;
using System.Collections.Generic;
using System.Text;

namespace battle_of_cards_grupauderzeniowa
{
    class Game
    {
        private Deck deck = new Deck();
        private Gambler gambler = new Gambler(980);
        public void Run()
        {
            bool anothergame = true;
            while(anothergame)
            {
                
                // utworzenie potasowanej talii 52 kart
                deck.Shuffle();
                // utworzenie dwóch "rąk"
                List <Card> dealerHand = new List<Card>();
                List<Card> playerHand = new List<Card>();
                dealerHand = deck.handDeck();
                List<Card> dealerHandCover = Turn(dealerHand);
                playerHand = deck.handDeck();
                // karta playera uporzadkowana
                playerHand.Sort(new CardComparer_Value());
                bool beforeCall = true;
                int current= gambler.GetMoney();         
            
                DisplayTable.DisplayBoard(dealerHandCover, playerHand, 20, 0, current, beforeCall);
                bool setcal = gambler.SetCall();
                if (setcal) 
                {
                    beforeCall = false;
                    gambler.SetMoney(current-40);
                    gambler.GetMoney();
                    DisplayTable.DisplayBoard(dealerHand, playerHand, 20, 40, current, beforeCall);
                    Console.WriteLine("Press any key");
                    Console.ReadKey();
                    HandCombination dealer = Analisis.HandAnalizer(dealerHand);
                    HandCombination player = Analisis.HandAnalizer(playerHand);
                    // sprawdzenie czy ręka delera kwlifikuje sie do porównania
                    if (dealer != HandCombination.nothing)
                    {
                        Hand handpower = new Hand(dealer);
                        int outcome = handpower.CompareTo(player);
                        if (outcome == 1)
                        {
                            Console.WriteLine("You lost 60$");
                            gambler.SetMoney(current-20);
                        } 
                        if(outcome == -1) 
                        {
                            Console.WriteLine ("You won aggregate money!!!");
                            int agregate = 1;
                            string generalhand = player.ToString().Substring(0,2);
                            if (generalhand == "PO") {agregate = 100;}
                            if (generalhand == "po") {agregate = 50;}
                            if (generalhand == "qu") {agregate = 100;}
                            if (generalhand == "fu") {agregate = 100;}
                            if (generalhand == "fl") {agregate = 100;}
                            if (generalhand == "st") {agregate = 100;}
                            if (generalhand == "tr") {agregate = 100;}
                            if (generalhand == "dp") {agregate = 100;}
                            gambler.SetMoney(current + agregate * 40);


                        }
                        if(outcome == 0) 
                        {
                            Console.WriteLine("draw, get back Call");
                            gambler.SetMoney(current+40);
                        }
                    }
                    else   //dealer: nothing
                    {
                        foreach (Card item in dealerHand)
                        {
                            if (item.Rank == Ranks.Ace || item.Rank==Ranks.King)  //reka kwalifikacyjna
                            {
                                Hand handpower = new Hand(dealer);
                                int outcome = handpower.CompareTo(player);
                                if (outcome == 1)
                                {
                                    Console.WriteLine("Dealer won, you lost 60$");
                                    gambler.SetMoney(current - 60);
                                    break;
                                } 
                                if(outcome == -1) 
                                {
                                    Console.WriteLine ("You won aggregate money!!!");
                                    int agregate = 1;
                                    string generalhand = player.ToString().Substring(0,2);
                                    if (generalhand == "PO") {agregate = 100;}
                                    if (generalhand == "po") {agregate = 50;}
                                    if (generalhand == "qu") {agregate = 100;}
                                    if (generalhand == "fu") {agregate = 100;}
                                    if (generalhand == "fl") {agregate = 100;}
                                    if (generalhand == "st") {agregate = 100;}
                                    if (generalhand == "tr") {agregate = 100;}
                                    if (generalhand == "dp") {agregate = 100;}
                                    gambler.SetMoney(current + agregate * 40);
                                    break;
                                }
                                if(outcome == 0) 
                                {
                                    Console.WriteLine("draw, get back Call");
                                    gambler.SetMoney(current+40);
                                }
                                break;
                            }
                            else
                            {
                                Console.WriteLine("You won 60 $");
                                gambler.SetMoney(current + 60);
                                break;
                            }
                        }
                    }
                }
                else
                {
                    DisplayTable.DisplayBoard(dealerHandCover, playerHand, 200, 0, current, beforeCall);
                    Console.WriteLine("Would you like to play? - press Y:");
                    string choice2 = Console.ReadLine().ToUpper();
                    if (choice2 != "Y")
                    {
                        anothergame = false;
                    } 
                }
                beforeCall = true;
                if (gambler.GetMoney()<= 0)
                {
                    anothergame = false; 
                } 
            } 
            Console.WriteLine("End of the Game");
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