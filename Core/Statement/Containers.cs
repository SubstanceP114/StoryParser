using StoryParser.Core.Input;
using StoryParser.Core.Util;

namespace StoryParser.Core.Statement
{
    public class Line
    {
        internal Line(string fileName, int lineIndex, string line)
        {
            Position = new Locator(fileName, lineIndex);
            statements = new();
            foreach (string statement in line.Split(Separators.Line))
                statements.Add(Dispatcher.Execute(statement.Split(Separators.Line)));
        }
        private List<IStatement> statements;
        public int Length => statements.Count;
        public Locator Position { get; private set; }
        internal void Execute() => statements.ForEach(s => s.Execute());
    }
    public class File
    {
        private List<Line> lines = new();
        public int Length => lines.Count;
        internal void AddLine(string fileName, int lineIndex, string line)
            => lines.Add(new Line(fileName, lineIndex, line));
        public Line this[int index] => lines[index];
    }
}
