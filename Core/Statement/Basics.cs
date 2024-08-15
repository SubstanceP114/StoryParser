using StoryParser.Core.Input;
using StoryParser.Extension.Output;

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
    public class Void : IStatement
    {
        public void Execute() => Executor.Complete();
    }
    public class End : IStatement, IDispatcher
    {
        public End(int value)
        {
            Value = value;
        }
        public void Execute()
        {
            Executor.EndWith(Value);
            Executor.Pause();
            Executor.Complete();
        }
        public IStatement Dispatch(string[] parameters)
        {
            if (parameters.Length != 2)
                throw new ArgumentException(string.Format("{0}数组长度有误", parameters), nameof(parameters));
            return new End(int.Parse(parameters[1]));
        }
        public readonly int Value;
    }
}
