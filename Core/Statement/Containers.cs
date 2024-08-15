using StoryParser.Core.Util;

namespace StoryParser.Core.Statement
{
    public class Line
    {
        internal Line(string line)
        {
            statements = new();
            foreach (string statement in line.Split(Separators.Line))
                statements.Add(Dispatcher.Execute(statement.Split(Separators.Statement)));
        }
        private List<IStatement> statements;
        public int Length => statements.Count;
        internal void Execute() => statements.ForEach(s => s.Execute());
    }
    public class File
    {
        private List<Line> lines = new();
        public int Length => lines.Count;
        internal void AddLine(string line) => lines.Add(new Line(line));
        public Line this[int index] => lines[index];
    }
}
