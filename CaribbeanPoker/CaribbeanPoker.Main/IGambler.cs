namespace CaribbeanPoker.Main
{
    internal interface IGambler: IDependency
    {
        IWallet Wallet { get; }
        IController Controller { get; }
        Hand Hand { get; }
        int PayAnte();
        bool PayJackpot(int ante, int jackpotAnte, ref int jackpot);
    }
}