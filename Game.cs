using System;
using System.Collections.Generic;
using System.Text;

namespace battle_of_cards_grupauderzeniowa
{
    class Game
    {
        private Deck deck = new Deck();
        private Gambler gambler = new Gambler(250);
        public void Run()
        {
            int ante = 20;
            bool anothergame = true;
            while(anothergame)
            {
                // utworzenie potasowanej talii 52 kart
                deck.Shuffle();
                // utworzenie dwóch "rąk"
                List <Card> dealerHand = new List<Card>();
                List<Card> playerHand = new List<Card>();
                List<Card> twoHAND = new List<Card>();
                twoHAND = deck.handDeck();
                for (int i = 0; i < 10; i++)
                {
                    if (i<5) dealerHand.Add(twoHAND[i]);
                    else playerHand.Add(twoHAND[i]);
                }
                List<Card> dealerHandCover = Turn(dealerHand);
                // karta playera uporzadkowana
                playerHand.Sort(new CardComparer_Value());
                //plansza przed Call ale juz z Ante
                bool beforeCall = true;
                      
                gambler.SetMoney(gambler.GetMoney()-ante);
                DisplayTable.DisplayBoard(dealerHandCover, playerHand, ante, 0, gambler.GetMoney(), beforeCall);
                bool setcal = gambler.SetCall();
                if (setcal) 
                {
                    beforeCall = false;
                    gambler.SetMoney(gambler.GetMoney()- 2* ante);
                    DisplayTable.DisplayBoard(dealerHand, playerHand, ante, 2*ante, gambler.GetMoney(), beforeCall);
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
                            Console.WriteLine("Press any key");
                            Console.ReadKey();
                            gambler.SetMoney(gambler.GetMoney() - 3 * ante);
                        } 
                        if(outcome == -1) 
                        {
                            Console.WriteLine("You won aggregate money!!!");
                            Console.WriteLine("Press any key");
                            int agregate = 1;
                            string generalhand = player.ToString().Substring(0,2);
                            if (generalhand == "PO") {agregate = 100;}
                            if (generalhand == "po") {agregate = 50;}
                            if (generalhand == "qu") {agregate = 20;}
                            if (generalhand == "fu") {agregate = 7;}
                            if (generalhand == "fl") {agregate = 5;}
                            if (generalhand == "st") {agregate = 4;}
                            if (generalhand == "tr") {agregate = 3;}
                            if (generalhand == "dp") {agregate = 2;}
                            gambler.SetMoney(gambler.GetMoney() + agregate*3*ante +2* ante);
                        }
                        if(outcome == 0) 
                        {
                            Console.WriteLine("draw, get back Call");
                            Console.WriteLine("Press any key");
                            Console.ReadKey();
                            gambler.SetMoney(gambler.GetMoney()+ 2*ante);
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
                                    Console.WriteLine("Press any key");
                                    Console.ReadKey();
                                    gambler.SetMoney(gambler.GetMoney() - 3*ante);
                                    break;
                                } 
                                if(outcome == -1) 
                                {
                                    Console.WriteLine ("You won aggregate money!!!");
                                    Console.WriteLine("Press any key");
                                    Console.ReadKey();
                                    int agregate = 1;
                                    string generalhand = player.ToString().Substring(0,2);
                                    if (generalhand == "PO") {agregate = 100;}
                                    if (generalhand == "po") {agregate = 50;}
                                    if (generalhand == "qu") {agregate = 20;}
                                    if (generalhand == "fu") {agregate = 7;}
                                    if (generalhand == "fl") {agregate = 5;}
                                    if (generalhand == "st") {agregate = 4;}
                                    if (generalhand == "tr") {agregate = 3;}
                                    if (generalhand == "dp") {agregate = 2;}
                                    gambler.SetMoney(gambler.GetMoney() + agregate*3*ante + 3*ante);
                                    break;
                                }
                                if(outcome == 0) 
                                {
                                    Console.WriteLine("draw, get back Call");
                                    Console.WriteLine("Press any key");
                                    Console.ReadKey();
                                    gambler.SetMoney(gambler.GetMoney()+2*ante);
                                    break;
                                }
                                
                            }
                            else
                            {
                                Console.WriteLine("You get back your Ante & Call plus extra Ante");
                                Console.WriteLine("Press any key");
                                Console.ReadKey();
                                gambler.SetMoney(gambler.GetMoney() + 4 *ante);
                                break;
                            }
                        }
                    }
                }
                else
                {
                    Console.Write("Would you like to play? - press Y: ");
                    string choice2 = Console.ReadLine().ToUpper();
                    if (choice2 != "Y")
                    {
                        anothergame = false;
                    } 
                }
                //beforeCall = true;
                if (gambler.GetMoney()<= 0)
                {
                    anothergame = false; 
                } 
            } 
            Console.WriteLine("End of the Game. You lost all your money");
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