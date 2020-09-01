namespace CaribbeanPokerMain
{
    internal interface IGambler: IDependency
    {
        IWallet Wallet { get; }
        IController Controller { get; }
        Hand Hand { get; }
        int PayAnte();
        bool IsJackpot(int ante, int jackpotAnte);
    }
}