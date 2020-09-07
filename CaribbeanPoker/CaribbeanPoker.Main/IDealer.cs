namespace CaribbeanPoker.Main
{
    internal interface IDealer : IDependency
    {
        Hand Hand { get; }
        bool IsQualify();
    }
}