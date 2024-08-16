using StoryParser.Core.Statement;
using System.Text.RegularExpressions;

namespace StoryParser.Extension
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
                copy = copy.Replace("{" + match + "}", Commands.GetValue(match.ToString()).ToString());
            Commands.Say(character, sprite, copy);
        }
        public IStatement Dispatch(string[] parameters)
        {
            if (parameters.Length != 4)
                throw new ArgumentException(string.Format("{0}数组长度有误", parameters), nameof(parameters));
            return new Say(parameters[1], parameters[2], parameters[3]);
        }
        private readonly string? character, sprite;
        private readonly string dialogue;
    }
}
