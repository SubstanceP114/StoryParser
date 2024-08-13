using StoryParser.Core.Statement;
using StoryParser.Extension.Util;

namespace StoryParser.Extension.Statements
{
    public class SelectStatement : IStatement
    {
        public SelectStatement(List<Option> options)
        {
            this.options = options;
        }
        public Task Command() => new(() =>
        {

        });
        private List<Option> options;
    }
}
