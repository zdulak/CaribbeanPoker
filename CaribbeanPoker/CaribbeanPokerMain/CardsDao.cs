using System;
using System.Collections.Generic;
using System.IO;

namespace CaribbeanPokerMain
{
    class CardsDao : ICardDao
    {
        public Card GetCard(Suit suit, Rank rank)
        {
            string picture;
            string path = @"../Cards/Card_" + suit.ToString() + "_" + rank.ToString() + ".txt";

            try
            {
                picture = File.ReadAllText(path).Replace("\r", String.Empty);
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("I/O error: " + ex.Message);
                //Console.WriteLine(path);
                picture = path;
            }
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