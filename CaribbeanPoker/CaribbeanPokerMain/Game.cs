﻿using System;
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
                gambler.FlipCards(gambler.Cards.Length, sorted: true);
                dealer.Cards = deck.DequeueHand();
                dealer.FlipCards(1, sorted: false); // Reveal the dealer's first card 
                View.TestDisplayBoard(dealer.Cards, gambler.SortedCards, dealer.GetHandCombination(),
                    gambler.GetHandCombination());
                if (gambler.GetCall())
                {
                    gambler.Money -= 2*(int)ante;
                    dealer.FlipCards(dealer.Cards.Length, sorted: true);
                    View.TestDisplayBoard(dealer.SortedCards, gambler.SortedCards,
                        dealer.GetHandCombination(),gambler.GetHandCombination());
                    if (dealer.IsQualify())
                    {
                        if (gambler > dealer)
                        {
                            View.PrintMsg("You win!");
                            var handCombination = gambler.GetHandCombination();
                            gambler.Money += 2*(int)ante;
                            gambler.Money += RankMoney(handCombination, ante, isJackpot);
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
        private int RankMoney(HandCombination rank, Ante ante, bool isJackpot)
        {
            int money = 2*(int)ante; // bet money
            switch (rank)
            {
                case HandCombination.nothing:
                    money *= 1;
                    break;
                case HandCombination.full:
                    money *= 7;
                    break;
                case HandCombination.quads:
                    money *= 20;
                    break;
                case HandCombination.straight_flush:
                    money *= 50;
                    break;
                case HandCombination.royal_flush:
                    money *= 100;
                    break;
                default:
                    money *= ((int)rank-1);
                    break;
            }
            if (isJackpot && (int)rank > 5)
            {
                switch (rank)
                {
                    case HandCombination.flush:
                        money += 5*JackpotAnte;
                        jackpot -= 5*JackpotAnte;
                        break;
                    case HandCombination.full:
                        money += 10*JackpotAnte;
                        jackpot -= 10*JackpotAnte;
                        break;
                    case HandCombination.quads:
                        money += 50*JackpotAnte;
                        jackpot -= 50*JackpotAnte;
                        break;
                    case HandCombination.straight_flush:
                        money += (int)(0.1*jackpot);
                        jackpot -= (int)(0.1*jackpot);
                        break;
                    case HandCombination.royal_flush:
                        money += jackpot;
                        jackpot = 0;
                        break;
                }
                if (jackpot < 0.5*JackpotDefault) jackpot = JackpotDefault;
            }
            return money;
        }
    }
}