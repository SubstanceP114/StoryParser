using StoryParser.Core.Statement;
using StoryParser.Extension.Statements;
using StoryParser.Extension.Util;

namespace StoryParser.Extension.Dispatchers
{
    public class IfDispatcher : IDispatcher
    {
        public IStatement Dispatch(string[] parameters)
        {
            if (parameters.Length != 3)
                throw new ArgumentException(string.Format("{0}数组长度有误", parameters), nameof(parameters));
            return new IfStatement(new Conditions(parameters[1]), parameters[2]);
        }
    }
}
