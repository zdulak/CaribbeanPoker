namespace CaribbeanPokerMain
{
    internal interface IDealer
    {
        Hand Hand { get; }
        bool IsQualify();
    }
}