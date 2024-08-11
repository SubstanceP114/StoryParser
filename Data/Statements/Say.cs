
namespace StoryParser.Data.Statements
{
    public class Say : Statement, ILoggable
    {
        public Say(string fileName, int lineIndex, string character, string dialogue) : base(fileName, lineIndex)
        {
            Character = character;
            Dialogue = dialogue;
        }
        public string Character { get; private set; }
        public string Dialogue { get; private set; }
        public override Task Command => new(() => { });
    }
}
