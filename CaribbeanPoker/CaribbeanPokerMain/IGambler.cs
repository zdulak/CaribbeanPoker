namespace CaribbeanPokerMain
{
    internal interface IGambler
    {
        Wallet Wallet { get; }
        Controller Controller { get; }
        Hand Hand { get; }
    }
}