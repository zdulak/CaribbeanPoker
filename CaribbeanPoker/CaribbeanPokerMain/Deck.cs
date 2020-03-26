using System;
using System.Collections.Generic;

namespace CaribbeanPokerMain
{
    class Deck: ICardDAO
    {
        private List<Card> cards;
        private Random random;
        // Constructor creating a shuffled deck.
        public Deck()
        {
            random = new Random();
            cards = new List<Card>(52);
            for (int suit = 0; suit < 4; ++suit)
            {
                for (int rank = 1; rank < 14; ++rank)
                {
                    // TODO: Replace with GetCard(Suit suit, Rank rank)
                    cards[rank+suit*rank-1] = new Card((Suit)suit, (Rank)rank);
                }
            }
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
        // Method loads a card from a file 
        public Card GetCard(Suit suit, Rank rank)
        {
            throw new NotImplementedException();
        }
    }
}