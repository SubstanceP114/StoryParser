using StoryParser.Core.Statement;
using StoryParser.Extension.Output;
using System.Text.RegularExpressions;

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
            var matches = Regex.Matches(Dialogue, @"(?<=\{)[^}]*(?=\})").Cast<Match>().ToList();
            string dialogue = Dialogue;
            foreach (var match in matches)
                if (Commands.DataProvider!.TryGetString(match.ToString(), out string replace))
                    dialogue = dialogue.Replace("{" + match + "}", replace);
            Commands.SayCommand(Character, Sprite, dialogue);
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
