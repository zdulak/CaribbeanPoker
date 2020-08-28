using System;

namespace CaribbeanPokerMain
{
    internal interface IHand : IComparable<Hand>, IEquatable<Hand>
    {
        Card[] Cards { get; set; }
        Card[] SortedCards { get; }
        void FlipCards(int number, bool sorted, bool faceUp);
        HandCombination GetHandCombination();
    }
}