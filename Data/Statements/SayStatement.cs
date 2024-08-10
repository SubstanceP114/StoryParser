namespace Data
{
    public class SayStatement : ICommand, ILog
    {
        public SayStatement(string character, string dialogue, string fileName, int lineIndex)
        {
            Character = character;
            Dialogue = dialogue;
            FileName = fileName;
            LineIndex = lineIndex;
        }
        public string FileName { get; private set; }
        public int LineIndex { get; private set; }
        public string Character { get; private set; }
        public string Dialogue { get; private set; }
        public void Execute()
        {

        }
        public void Complete()
        {

        }
    }
}
