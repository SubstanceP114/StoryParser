using StoryParser.Core.Statement;
using StoryParser.Extension.Statements;

namespace StoryParser.Extension.Dispatchers
{
    public class SayDispatcher : IDispatcher
    {
        public IStatement Dispatch(string[] parameters)
        {
            return parameters.Length switch
            {
                2 => new SayStatement(parameters[1]),
                3 => new SayStatement(parameters[1], parameters[2]),
                _ => throw new ArgumentException(string.Format("{0}数组长度有误", parameters), nameof(parameters)),
            };
        }
    }
}
