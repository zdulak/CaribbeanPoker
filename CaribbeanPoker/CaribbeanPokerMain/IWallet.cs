namespace CaribbeanPokerMain
{
    internal interface IWallet
    {
        int Money { get; set; }
        bool IsBroke();
        bool IsEnoughForAnte(int ante);
        bool IsEnoughForJackpot(int ante, int jackpotAnte);
    }
}