using System;
using System.Collections.Generic;

namespace battle_of_cards_grupauderzeniowa
{
    public class Deck: IDeckDAO
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
        // constructor to create "hand" przez przekazanie gotowej listy
        public Deck(IEnumerable<Card> handCards)
        {
            cards = new List<Card>(handCards);
        }
        
        //methods working as
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
        public IEnumerable<string> GetCardNames()
        {
            string[]CardNames = new string[cards.Count];
            for (int i = 0; i < cards.Count; i++)
            {
                CardNames[i] = cards[i].Name;
            }
            return CardNames;
        }
        public void removeCard(Card removedCard)
        {
            cards.Remove(removedCard);
        }
        public void addCard(Card addedCard)
        {
            cards.Add(addedCard);
        }
        // metoda losująca pięć kart z przetasowanej talii
        public Card[] handDeck()
        {
            Card[] handStaff = new Card[5];
            for (int i = 0; i<5; i++)
            {
                Card cardToPick =  cards[0];
                cards.RemoveAt(0);
                handStaff[i] = cardToPick;
            }
            return handStaff;
        }
    }
}