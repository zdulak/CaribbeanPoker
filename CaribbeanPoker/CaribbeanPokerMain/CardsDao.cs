using System;
using System.Collections.Generic;
using System.IO;

namespace CaribbeanPokerMain
{
    class CardsDao : ICardDao
    {
        private string[] cardsDatabase;
        public CardsDao(string path)
        {
            try
            {
                cardsDatabase = File.ReadAllLines(path);
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("I/O error: " + ex.Message);
            }
        }
        public Card GetCard(Suit suit, Rank rank)
        {
            var picture = cardsDatabase[(int)rank-2+(int)suit*13];
            return new Card(suit, rank, picture: picture);
        }
        public List<Card> GetAllCards()
        {
            var cards = new List<Card>();
            for (int suit = 0; suit < 4; ++suit)
            {
                for (int rank = 2; rank < 15; ++rank)
                {
                    cards.Add(GetCard((Suit)suit, (Rank)rank));
                }
            }
            return cards;
        }
    }
}