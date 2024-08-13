using StoryParser.Core.Statement;
using StoryParser.Extension.Util;

namespace StoryParser.Extension.Statements
{
    public class IfStatement : IStatement
    {
        public IfStatement(Conditions conditions, string target)
        {
            this.conditions = conditions;
            this.target = target;
        }
        public Task Command() => new(() =>
        {

        });
        private Conditions conditions;
        private string target;
    }
}
