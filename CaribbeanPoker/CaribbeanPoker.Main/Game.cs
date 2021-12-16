using System;
using System.Collections.Generic;

namespace CaribbeanPoker.Main
{
    class Game
    {
        private readonly IGambler _gambler;
        private readonly IDealer _dealer;
        private readonly IDeck _deck;
        private readonly IView _view;
        private int _jackpot;
        private const int JackpotAnte = 10;
        private const int JackpotDefault = 10000;
        public Game(IGambler gambler, IDealer dealer, IDeck deck, IView view)
        {

            _gambler = gambler;
            _dealer = dealer;
            _deck = deck;
            _view = view;
            _jackpot = JackpotDefault;
        }

        public void Run()
        {
            _view.Clear();
            while (!_gambler.Wallet.IsBroke())
            {
                _view.PrintStatus(_gambler.Wallet.Money, _jackpot);
                int ante = _gambler.PayAnte();
                bool isJackpot = _gambler.PayJackpot(ante, JackpotAnte, ref _jackpot);
                _gambler.Hand.Cards = _deck.DequeueHand();
                _gambler.Hand.FlipCards(_gambler.Hand.Cards.Count, sorted: true, true);
                _dealer.Hand.Cards = _deck.DequeueHand();
                _dealer.Hand.FlipCards(1, sorted: false, true); // Reveal the dealer's first card 
                _view.DisplayBoard(_dealer.Hand.Cards, _gambler.Hand.SortedCards, _deck.CardBack,
                    playerCombination: _gambler.Hand.HandCombination.ToString());
                if (_gambler.Controller.GetAnswer("Do  you raise ?"))
                {
                    _gambler.Wallet.Money -= 2*ante;
                    _dealer.Hand.FlipCards(_dealer.Hand.Cards.Count, sorted: true, true);
                    _view.DisplayBoard(_dealer.Hand.SortedCards, _gambler.Hand.SortedCards, _deck.CardBack,
                        _dealer.Hand.HandCombination.ToString(), _gambler.Hand.HandCombination.ToString());
                    if (_dealer.IsQualify())
                    {
                        if (_gambler.Hand > _dealer.Hand)
                        {
                            _view.PrintMsg("You win!");
                            _gambler.Wallet.Money += 4*ante; // return player money and won dealer ante
                            _gambler.Wallet.Money += RankMoney(_gambler.Hand.HandCombination, ante, isJackpot); // won bet bonus money
                        }
                        else if (_dealer.Hand == _gambler.Hand)
                        {
                            _view.PrintMsg("Push!");
                            _gambler.Wallet.Money += 3*ante;
                        }
                        else
                        {
                            _view.PrintMsg("You lose!");
                        }
                    }
                    else
                    {
                        _view.PrintMsg("Dealer folds!");
                        _gambler.Wallet.Money += 4*ante;
                    }
                }
                _dealer.Hand.FlipCards(_dealer.Hand.Cards.Count, sorted: false, false);
                _gambler.Hand.FlipCards(_dealer.Hand.Cards.Count, sorted: false, false);
                _deck.EnqueueHand(_gambler.Hand.Cards);
                _deck.EnqueueHand(_dealer.Hand.Cards);
                _deck.Shuffle();
            }
            _view.PrintMsg("You are broke. Goodbye!");
            _gambler.Controller.Quit();         
        }
        private int RankMoney(HandCombination rank, int ante, bool isJackpot)
        {
            int money = 2*ante; // betted money
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
                        _jackpot -= 5*JackpotAnte;
                        break;
                    case HandCombination.full:
                        money += 10*JackpotAnte;
                        _jackpot -= 10*JackpotAnte;
                        break;
                    case HandCombination.quads:
                        money += 50*JackpotAnte;
                        _jackpot -= 50*JackpotAnte;
                        break;
                    case HandCombination.straight_flush:
                        money += (int)(0.1*_jackpot);
                        _jackpot -= (int)(0.1*_jackpot);
                        break;
                    case HandCombination.royal_flush:
                        money += _jackpot;
                        _jackpot = 0;
                        break;
                }
                if (_jackpot < 0.5*JackpotDefault) _jackpot = JackpotDefault;
            }
            return money;
        }
    }
}