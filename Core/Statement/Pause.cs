using StoryParser.Core.Input;

namespace StoryParser.Core.Statement
{
    public class Pause : IStatement, IDispatcher
    {
        public void Execute()
        {
            Executor.Pause();
            Executor.Complete();
        }
        public IStatement Dispatch(string[] parameters) => new Pause();
    }
}
