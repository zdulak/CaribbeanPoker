namespace CaribbeanPokerMain
{
    interface ICardDAO
    {
        Card GetCard(Suit suit, Rank rank);
    }
}