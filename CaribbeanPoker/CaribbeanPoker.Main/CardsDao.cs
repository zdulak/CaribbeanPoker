using System;
using System.Collections.Generic;
using System.IO;

namespace CaribbeanPoker.Main
{
    class CardsDao : ICardDao
    {
        public Card GetCard(Suit suit, Rank rank)
        {
            string picture;
            var path = @"Cards/Card_" + suit.ToString() + "_" + rank.ToString() + ".txt";

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
            for (var suit = 0; suit < 4; ++suit)
            {
                for (var rank = 2; rank < 15; ++rank)
                {
                    cards.Add(GetCard((Suit)suit, (Rank)rank));
                }
            }
            return cards;
        }
    }
}