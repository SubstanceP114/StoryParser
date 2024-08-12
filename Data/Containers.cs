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
        }
        private List<Statement> statements;
        public static bool Accelerate { get; private set; }
        public async void Execute()
        {
            Accelerate = false;
            List<Task> tasks = new();
            foreach (var statement in statements)
                tasks.Add(statement.Command());
            tasks.Add(new Task(() =>
            {
                // 结束当前任务
            }));
            foreach (var task in tasks) task.Start();
            await Task.WhenAll(tasks);

        }
    }
    public class File
    {
        private List<Line> lines = new();
        public void AddLine(string fileName, int lineIndex, string line)
        {
            if (line[0] != Seperators.note)
                lines.Add(new Line(fileName, lineIndex, line));
        }
        public Line this[int index] => lines[index];
    }
    public class Folder
    {
        private Dictionary<string, File> files = new();
        public void AddFile(string name) => files.Add(name, new());
        public File this[string name] => files[name];
    }
}
