namespace ModularCalculator.Core.Modules
{
    public interface IModule
    {
        string Content { get; }
        void OnClick();
    }
}
