namespace CaribbeanPoker.Main
{
    internal interface IController : IDependency
    {
        IView View { get; }
        void Quit();
        int GetAnte();
        bool GetAnswer(string message);
    }
}