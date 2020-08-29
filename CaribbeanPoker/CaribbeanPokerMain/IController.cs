namespace CaribbeanPokerMain
{
    internal interface IController
    {
        void Quit();
        int GetAnte();
        bool GetAnswer(string message);
    }
}