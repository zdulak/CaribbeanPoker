using System;
using System.Collections.Generic;

namespace CaribbeanPokerMain
{
    class Deck
    {
        private List<Card> cards;
        private Random random;
        // Constructor creating a shuffled deck.
        public Deck()
        {
            var cardsDao = new CardsDao();
            random = new Random();
            cards = cardsDao.GetAllCards();
            Shuffle();
        }
        // Modern Fisher–Yates shuffle algorithm.
        public void Shuffle()
        {
            for (int i = 0; i < (cards.Count - 2); ++i)
            {
                int j = random.Next(i, cards.Count);
                Card temp = cards[i];
                cards[i] = cards[j];
                cards[j] = temp;
            }
        }
        // Method returns a hand of cards from the beginning of the deck.
        public Card[] DequeueHand()
        {
            var hand = cards.GetRange(0, 5).ToArray();
            cards.RemoveRange(0, 5);
            return hand;
        }
        // Method adds a hand of cards to the end of the deck.
        public void EnqueueHand(Card[] hand) => cards.AddRange(hand);
        
    }
}