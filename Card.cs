using System;

namespace battle_of_cards_grupauderzeniowa
{
    public class Card
    {
        // properties
        public Suits Suit {get; set;}
        public Ranks Rank {get; set;}
        public string Name
        {
            get {return Rank.ToString() + " of " + Suit.ToString();}
        }
        //constructor
        public Card(Suits suit, Ranks rank)
        {
            this.Suit = suit;
            this.Rank = rank;
        }
    }
}