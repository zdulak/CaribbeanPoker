using System;
using System.Collections.Generic;
using System.Text;

namespace CaribbeanPokerMain
{
    class Game
    {
        private Gambler gambler;
        private Dealer dealer;
        private Deck deck;
        private const int JackpotAnte = 10;
        private const int JackpotDefault = 10000;
        private int jackpot;
        public Game()
        {
            gambler = new Gambler();
            dealer = new Dealer();
            deck = new Deck();
            jackpot = JackpotDefault;
        }

        public void Run()
        {
            while (!gambler.IsBroke())
            {
                View.PrintStatus(gambler.Money, jackpot);
                var ante = gambler.GetAnte();
                gambler.Money -= (int)ante;
                var isJackpot = gambler.GetJackpot();
                if (isJackpot) 
                {
                    jackpot += JackpotAnte;
                    gambler.Money -= (int)JackpotAnte;
                }
                gambler.Cards = deck.DequeueHand();
                gambler.Sort();
                gambler.FlipCards(gambler.Cards.Length);
                dealer.Cards = deck.DequeueHand();
                dealer.FlipCards(1); // Reveal the dealer's first card    
                View.DisplayBoard(dealer.Cards, gambler.Cards);
                dealer.Sort();
                if (gambler.GetCall())
                {
                    gambler.Money -= 2*(int)ante;
                    dealer.FlipCards(dealer.Cards.Length);
                    View.DisplayBoard(dealer.Cards, gambler.Cards);
                    if (dealer.IsQualify())
                    {
                        if (gambler > dealer)
                        {
                            View.PrintMsg("You win!");
                            var rank = gambler.HandRank();
                            gambler.Money += 2*(int)ante;
                            gambler.Money += RankMoney(rank, ante, isJackpot);
                        }
                        else if (dealer == gambler)
                        {
                            View.PrintMsg("Push!");
                            gambler.Money += 3*(int)ante;
                        }
                        else
                        {
                            View.PrintMsg("You lose!");
                        }
                    }
                    else
                    {
                        View.PrintMsg("Dealer folds!");
                        gambler.Money += 4*(int)ante;
                    }
                }
                deck.EnqueueHand(gambler.Cards);
                deck.EnqueueHand(dealer.Cards);
                deck.Shuffle();
            }
            View.PrintMsg("You are broke. Goodbye!");
            gambler.Quit();         
        }
        private int RankMoney(int rank, Ante ante, bool isJackpot)
        {
            int money = 2*(int)ante; // bet money
            switch (rank)
            {
                case 1:
                    money *= 1;
                    break;
                case 2:
                    money *= 1;
                    break;
                case 3:
                    money *= 2;
                    break;
                case 4:
                    money *= 3;
                    break;
                case 5:
                    money *= 4;
                    break;
                case 6:
                    money *= 5;
                    break;
                case 7:
                    money *= 7;
                    break;
                case 8:
                    money *= 20;
                    break;
                case 9:
                    money *= 50;
                    break;
                case 10:
                    money *= 100;
                    break;
                default:
                    money = 0;
                    break;
            }
            if (isJackpot && rank > 5)
            {
                switch (rank)
                {
                    case 6:
                        money += 5*JackpotAnte;
                        jackpot -= 5*JackpotAnte;
                        break;
                    case 7:
                        money += 10*JackpotAnte;
                        jackpot -= 10*JackpotAnte;
                        break;
                    case 8:
                        money += 50*JackpotAnte;
                        jackpot -= 50*JackpotAnte;
                        break;
                    case 9:
                        money += (int)(0.1*jackpot);
                        jackpot -= (int)(0.1*jackpot);
                        break;
                    case 10:
                        money += jackpot;
                        jackpot = 0;
                        break;
                    default:
                        money = 0;
                        break;
                }
                if (jackpot < 0.5*JackpotDefault) jackpot = JackpotDefault;
            }
            return money;
        }
    }
}