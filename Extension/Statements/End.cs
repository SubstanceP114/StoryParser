using StoryParser.Core.Input;
using StoryParser.Core.Statement;
using StoryParser.Extension.Output;

namespace StoryParser.Extension.Statements
{
    public class End : IStatement, IDispatcher
    {
        public End(int value)
        {
            Value = value;
        }
        public void Execute()
        {
            Commands.EndCommand(Value);
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
