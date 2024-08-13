using StoryParser.Core.Statement;
using StoryParser.Extension.Util;

namespace StoryParser.Extension.Statements
{
    public class IfStatement : IStatement
    {
        public IfStatement()
        {
        }
        public Task Command() => new(() =>
        {

        });
        private Conditions conditions;
        private string target;
    }
}
