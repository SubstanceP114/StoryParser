using StoryParser.Core.Statement;
using StoryParser.Extension.Output;
using System.Text.RegularExpressions;

namespace StoryParser.Extension.Statements
{
    public class Say : IStatement, IDispatcher
    {
        public Say(string? character, string? sprite, string dialogue)
        {
            this.character = character;
            this.sprite = sprite;
            this.dialogue = dialogue;
        }
        public void Execute()
        {
            var matches = Regex.Matches(dialogue, @"(?<=\{)[^}]*(?=\})").Cast<Match>().ToList();
            string copy = dialogue;
            foreach (var match in matches)
                if (Commands.DataProvider!.TryGetString(match.ToString(), out string replace))
                    copy = copy.Replace("{" + match + "}", replace);
            Commands.SayCommand(character, sprite, copy);
        }
        public IStatement Dispatch(string[] parameters)
        {
            if (parameters.Length != 4)
                throw new ArgumentException(string.Format("{0}数组长度有误", parameters), nameof(parameters));
            return new Say(parameters[1], parameters[2], parameters[3]);
        }
        private readonly string? character;
        private readonly string? sprite;
        private readonly string dialogue;
    }
}
