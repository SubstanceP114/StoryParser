using StoryParser.Core.Data;

namespace StoryParser.Extension.Statements
{
    public class SayStatement : Statement
    {
        public SayStatement(string[] parameters)
        {
            switch (parameters.Length)
            {
                case 2:
                    dialogue = parameters[1];
                    break;
                case 3:
                    character = parameters[1];
                    dialogue = parameters[2];
                    break;
                default:
                    throw new ArgumentException(string.Format("{0}数组长度有误", parameters), nameof(parameters));
            }
        }
        public override Task Command() => new(() =>
        {

        });
        private string? character;
        private string? dialogue;
    }
}
