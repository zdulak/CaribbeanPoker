namespace CaribbeanPokerMain
{
    internal interface IDeck : IDependency
    {
        Card CardBack { get; }
        void Shuffle();
        Card[] DequeueHand();
        void EnqueueHand(Card[] hand);
    }
}