namespace CaribbeanPokerMain
{
    internal interface IController
    {
        IView View { get; }
        void Quit();
        int GetAnte();
        bool GetAnswer(string message);
    }
}