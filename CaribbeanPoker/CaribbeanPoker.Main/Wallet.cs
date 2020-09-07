namespace CaribbeanPoker.Main
{
    class Wallet : IWallet
    {
        public Wallet()
        {
            Money = 1000;
        }
        public int Money { get; set; }
        public bool IsBroke() => Money < 3 * Ante.PossibleValues[0];

        public bool IsEnoughForAnte(int ante)
        {
            return Money >= 3 * ante;
        }
        public bool IsEnoughForJackpot(int ante, int jackpotAnte)
        {
            return Money >= 2 * ante + jackpotAnte;
        }
    }
}