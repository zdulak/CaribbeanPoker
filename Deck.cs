using System;
using System.Collections.Generic;

namespace battle_of_cards_grupauderzeniowa
{
    public class Deck: IDeckDAO
    {
        // fields
        private List<Card> cards;
        public string[,] symbolArray = new string[4,13] 
            {{"\U0001F0D1  ","\U0001F0D2  ","\U0001F0D3  ","\U0001F0D4  ","\U0001F0D5  ","\U0001F0D6  ","\U0001F0D7  ",
            "\U0001F0D8  ","\U0001F0D9  ","\U0001F0DA  ","\U0001F0DB  ","\U0001F0DD  ","\U0001F0DE  "},
                {"\U0001F0C1  ","\U0001F0C2  ","\U0001F0C3  ","\U0001F0C4  ","\U0001F0C5  ","\U0001F0C6  ","\U0001F0C7  ",
            "\U0001F0C8  ","\U0001F0C9  ","\U0001F0CA  ","\U0001F0CB  ","\U0001F0CD  ","\U0001F0CE  "},
                {"\U0001F0B1  ","\U0001F0B2  ","\U0001F0B3  ","\U0001F0B4  ","\U0001F0B5  ","\U0001F0B6  ","\U0001F0B7  ",
            "\U0001F0B8  ","\U0001F0B9  ","\U0001F0BA  ","\U0001F0BB  ","\U0001F0BD  ","\U0001F0BE  "},
                {"\U0001F0A1  ","\U0001F0A2  ","\U0001F0A3  ","\U0001F0A4  ","\U0001F0A5  ","\U0001F0A6  ","\U0001F0A7  ",
            "\U0001F0A8  ","\U0001F0A9  ","\U0001F0AA  ","\U0001F0AB  ","\U0001F0AD  ","\U0001F0AE  "}};
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
                    Card car = new Card((Suits) su, (Ranks) ra, symbolArray[su,ra-1]);
                    cards.Add(car);
                }
            }
        }
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
        public List<Card> handDeck()
        {
            List<Card> twohandStaff = new List<Card>();
            for (int i = 0; i<10; i++)
            {
                Card cardToPick =  cards[i];
                twohandStaff.Add(cardToPick);
            }
            return twohandStaff;
        }
    }
}