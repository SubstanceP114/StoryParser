using StoryParser.Core.Statement;
using StoryParser.Extension.Output;

namespace StoryParser.Extension.Statements
{
    public class Menu : IStatement, IDispatcher
    {
        public Menu(string content, int target)
        {
            this.content = content;
            this.target = target;
        }
        public void Execute() => Commands.MenuCommand(content, target);
        public IStatement Dispatch(string[] parameters)
        {
            if (parameters.Length != 3)
                throw new ArgumentException(string.Format("{0}数组长度有误", parameters), nameof(parameters));
            return new Menu(parameters[1], int.Parse(parameters[2]));
        }
        private readonly string content;
        private readonly int target;
    }
}
