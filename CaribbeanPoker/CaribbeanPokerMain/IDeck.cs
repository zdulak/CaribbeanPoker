namespace CaribbeanPokerMain
{
    internal interface IDeck
    {
        Card CardBack { get; }
        void Shuffle();
        Card[] DequeueHand();
        void EnqueueHand(Card[] hand);
    }
}