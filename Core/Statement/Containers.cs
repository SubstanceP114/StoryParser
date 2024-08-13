using StoryParser.Core.Util;

namespace StoryParser.Core.Statement
{
    public class Line
    {
        public Line(string fileName, int lineIndex, string line)
        {
            Position = new Locator(fileName, lineIndex);
            statements = new();
            foreach (string statement in line.Split(Separators.Line))
                statements.Add(Dispatcher.Execute(statement.Split(Separators.Line)));
        }
        private List<IStatement> statements;
        public Locator Position { get; private set; }
        public Task Execute()
        {
            List<Task> tasks = new();
            foreach (var statement in statements)
                tasks.Add(statement.Command());
            foreach (var task in tasks) task.Start();
            return Task.WhenAll(tasks);
        }
    }
    public class File
    {
        private List<Line> lines = new();
        public int Length => lines.Count;
        public void AddLine(string fileName, int lineIndex, string line)
            => lines.Add(new Line(fileName, lineIndex, line));
        public Line this[int index] => lines[index];
    }
    public class Folder
    {
        private Dictionary<string, File> files = new();
        public void AddFile(string name) => files.Add(name, new());
        public File this[string name] => files[name];
        public Line this[Locator position] => files[position.FileName][position.LineIndex];
    }
}
