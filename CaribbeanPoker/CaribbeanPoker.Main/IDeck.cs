using System.Collections.ObjectModel;

namespace CaribbeanPoker.Main
{
    internal interface IDeck : IDependency
    {
        Card CardBack { get; }
        void Shuffle();
        ReadOnlyCollection<Card> DequeueHand();
        void EnqueueHand(ReadOnlyCollection<Card> hand);
    }
}