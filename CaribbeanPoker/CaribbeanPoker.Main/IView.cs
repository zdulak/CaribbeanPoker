namespace CaribbeanPokerMain
{
    public interface IView
    {
        void Clear();
        void PrintMsg(string msg);
        void PrintStatus(int money, int jackpot);

        void DisplayBoard(Card[] dealer, Card[] player, Card cardBack , string dealerCombination ="????",
            string playerCombination="????");

        void DisplayHand(Card[] cards, Card cardBack);
    }
}