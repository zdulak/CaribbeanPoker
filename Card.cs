using System;

namespace battle_of_cards_grupauderzeniowa
{
    public class Card
    {
        // properties
       
        public Suits Suit { get; set; }
        public Ranks Rank { get; set; }
        public string Icon;
        public string Name
        {
            get { return Rank.ToString() + " of " + Suit.ToString(); }
        }

        public Card(Suits suit, Ranks rank, string icon)
        {
            this.Suit = suit;
            this.Rank = rank;
            this.Icon = icon;
        }
    }
}