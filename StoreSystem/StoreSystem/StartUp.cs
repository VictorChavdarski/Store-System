namespace StoreSystem
{
    using StoreSystem.Core;
    using StoreSystem.Core.Contracts;

    public class StartUp
    {
        static void Main(string[] args)
        {
            IEngine engine = new Engine();
            engine.Run();
        }
    }
}
