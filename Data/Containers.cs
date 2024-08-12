using StoryParser.Setting;

namespace StoryParser.Data
{
    public class Line
    {
        public Line(string fileName, int lineIndex, string line)
        {
            statements = new();
            foreach (string statement in line.Split(Seperators.line))
                statements.Add(Statement.Create(fileName, lineIndex, statement.Split(Seperators.line)));
            Position = new Locator(fileName, lineIndex);
        }
        private List<Statement> statements;
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
