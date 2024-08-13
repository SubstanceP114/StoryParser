using StoryParser.Core.Statement;

namespace StoryParser.Extension.Statements
{
    public class SayStatement : IStatement
    {
        public SayStatement(string dialogue)
        {
            this.dialogue = dialogue;
        }
        public SayStatement(string character, string dialogue)
        {
            this.character = character;
            this.dialogue = dialogue;
        }
        public Task Command() => new(() =>
        {

        });
        private string? character;
        private string dialogue;
    }
}
