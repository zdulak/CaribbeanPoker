namespace CaribbeanPokerMain
{
    internal interface IDealer : IDependency
    {
        Hand Hand { get; }
        bool IsQualify();
    }
}