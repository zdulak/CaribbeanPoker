namespace CaribbeanPoker.Main
{
    public interface IWallet : IDependency
    {
        int Money { get; set; }
        bool IsBroke();
        bool IsEnoughForAnte(int ante);
        bool IsEnoughForJackpot(int ante, int jackpotAnte);
    }
}