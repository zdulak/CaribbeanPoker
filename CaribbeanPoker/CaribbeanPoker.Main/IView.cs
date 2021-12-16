using System.Collections.ObjectModel;

namespace CaribbeanPoker.Main
{
    public interface IView
    {
        void Clear();
        void PrintMsg(string msg);
        void PrintStatus(int money, int jackpot);

        void DisplayBoard(ReadOnlyCollection<Card> dealer, ReadOnlyCollection<Card> player, Card cardBack , string dealerCombination ="????",
            string playerCombination="????");

        void DisplayHand(ReadOnlyCollection<Card> cards, Card cardBack);
    }
}