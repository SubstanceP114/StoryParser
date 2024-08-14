using StoryParser.Core.Statement;

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
