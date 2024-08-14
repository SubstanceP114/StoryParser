using StoryParser.Core.Statement;

namespace StoryParser.Extension.Statements
{
    public class Say : IStatement, IDispatcher
    {
        public Say(string? character, string? sprite, string dialogue)
        {
            Character = character;
            Sprite = sprite;
            Dialogue = dialogue;
        }
        public void Execute()
        {

        }
        public IStatement Dispatch(string[] parameters)
        {
            if (parameters.Length != 4)
                throw new ArgumentException(string.Format("{0}数组长度有误", parameters), nameof(parameters));
            return new Say(parameters[1], parameters[2], parameters[3]);
        }
        public readonly string? Character;
        public readonly string? Sprite;
        public readonly string Dialogue;
    }
}
