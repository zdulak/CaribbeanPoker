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
            var picture = cardsDatabase[(int)rank+(int)suit*(int)rank-1];
            return new Card(suit, rank, picture: picture);
        }
        public List<Card> GetAllCards()
        {
            var cards = new List<Card>(52);
            for (int suit = 0; suit < 4; ++suit)
            {
                for (int rank = 1; rank < 14; ++rank)
                {
                    cards[rank+suit*rank-1] = GetCard((Suit)suit, (Rank)rank);
                }
            }
            return cards;
        }
    }
}