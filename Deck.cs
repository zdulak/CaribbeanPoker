using System;
using System.Collections.Generic;

namespace battle_of_cards_grupauderzeniowa
{
    public class Deck
    {
        // fields
        private List<Card> cards;
        private Random random = new Random();
        // properties
        public int Count {get {return cards.Count;}}
        // constructor to create full deck
        public Deck()
        {
            cards = new List<Card>();
            for (int su = 0; su <= 3; su++)
            {
                for (int ra = 1; ra <= 13; ra++)
                {
                    cards.Add(new Card((Suits)su, (Ranks)ra));
                }
            }
        }
        // constructor to create "hand"
        public Deck(IEnumerable<Card> handCards)
        {
            cards = new List<Card>(handCards);
        }
        //methods
        public void Shuffle()
        {
            List<Card> afterShuffle = new List<Card>();
            while (cards.Count > 0)
            {
                // random number 0-51
                int IndexCards = random.Next(cards.Count);
                afterShuffle.Add(cards[IndexCards]);
                cards.RemoveAt(IndexCards);
            }
            cards = afterShuffle;
        }
    }
}