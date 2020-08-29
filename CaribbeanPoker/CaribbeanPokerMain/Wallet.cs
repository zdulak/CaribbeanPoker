namespace CaribbeanPokerMain
{
    class Wallet
    {
        public Wallet()
        {
            Money = 100;
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