using System;
using System.Collections.Generic;

namespace CaribbeanPoker.Main
{
    class Deck : IDeck
    {
        private readonly List<Card> _cards;
        public Card CardBack {get;}

        private readonly Random _random;
        // Constructor creating a shuffled deck.
        public Deck(ICardDao cardsDao, Random random)
        {
            _random = random;
            _cards = cardsDao.GetAllCards();
            Shuffle();
            CardBack = cardsDao.GetCard(0,0);
        }
        // Modern Fisher–Yates shuffle algorithm.
        public void Shuffle()
        {
            for (int i = 0; i < (_cards.Count - 2); ++i)
            {
                int j = _random.Next(i, _cards.Count);
                Card temp = _cards[i];
                _cards[i] = _cards[j];
                _cards[j] = temp;
            }
        }
        // Method returns a hand of cards from the beginning of the deck.
        public Card[] DequeueHand()
        {
            var hand = _cards.GetRange(0, 5).ToArray();
            _cards.RemoveRange(0, 5);
            return hand;
        }
        // Method adds a hand of cards to the end of the deck.
        public void EnqueueHand(Card[] hand) => _cards.AddRange(hand);
        
    }
}