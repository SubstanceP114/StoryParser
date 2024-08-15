using StoryParser.Core.Input;
using StoryParser.Core.Statement;

namespace StoryParser.Extension.Statements
{
    public class Jump : IStatement, IDispatcher
    {
        public Jump(int target) => Target = target;
        public void Execute()
        {
            Executor.Locate(Target - 1);
            Executor.Complete();
        }
        public IStatement Dispatch(string[] parameters)
        {
            if (parameters.Length != 2)
                throw new ArgumentException(string.Format("{0}数组长度有误", parameters), nameof(parameters));
            return new Jump(int.Parse(parameters[1]));
        }
        public readonly int Target;
    }
}
