using System.Collections.Generic;

namespace CaribbeanPokerMain
{
    interface ICardDao : IDependency
    {
        // Method loads a card from a file 
        Card GetCard(Suit suit, Rank rank);
        // Method loads all cards from a file 
        List<Card> GetAllCards();
    }
}