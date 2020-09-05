using System;

namespace CaribbeanPokerMain
{
    public class Card
    {
        public Suit Suit {get; }
        public Rank Rank {get; }
        public bool FaceUp {get; set;}
        // ASCII art representing the card. 
        public string Picture {get;} 
        public Card(Suit suit, Rank rank, bool faceUp=false, string picture="")
        {
            Suit = suit;
            Rank = rank;
            FaceUp = faceUp;
            Picture = picture;
        }
        public override string ToString() => Suit.ToString() + " " + Rank.ToString();
        public override int GetHashCode() => Suit.GetHashCode() ^ Rank.GetHashCode();
    }
}