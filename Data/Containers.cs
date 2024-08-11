using StoryParser.Setting;
namespace StoryParser.Data
{
    public class Line
    {
        public Line(string line)
        {
            statements = new();
            foreach (string statement in line.Split(Seperators.line))
            {
                string[] parameters = statement.Split(Seperators.statement);
            }
        }
        private List<Statement> statements;
        public void Execute()
        {

        }
    }
    public class File
    {
        private List<Line> lines = new();
        public void AddLine(string line) => lines.Add(new Line(line));
        public Line this[int index] => lines[index];
    }
    public class Script
    {
        private Dictionary<string, File> files = new();
        public void AddFile(string name) => files.Add(name, new());
        public File this[string name] => files[name];
    }
}
