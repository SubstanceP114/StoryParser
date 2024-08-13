using StoryParser.Core.Data;
using StoryParser.Extension.Statements;

namespace StoryParser.Extension.Dispatchers
{
    public class SayDispatcher : Dispatcher
    {
        public SayDispatcher(string name) : base(name) { }
        protected override SayStatement Dispatch(string[] parameters) => new SayStatement(parameters);
    }
}
