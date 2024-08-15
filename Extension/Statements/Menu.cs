using StoryParser.Core.Statement;
using StoryParser.Extension.Output;

namespace StoryParser.Extension.Statements
{
    public class Menu : IStatement, IDispatcher
    {
        public Menu(string content, int target)
        {
            Content = content;
            Target = target;
        }
        public void Execute() => Commands.MenuCommand(Content, Target);
        public IStatement Dispatch(string[] parameters)
        {
            if (parameters.Length != 3)
                throw new ArgumentException(string.Format("{0}数组长度有误", parameters), nameof(parameters));
            return new Menu(parameters[1], int.Parse(parameters[2]));
        }
        public readonly string Content;
        public readonly int Target;
    }
}
