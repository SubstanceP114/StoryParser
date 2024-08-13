namespace StoryParser.Core.Util
{
    public readonly struct Locator
    {
        public Locator(string fileName, int lineIndex)
        {
            FileName = fileName;
            LineIndex = lineIndex;
        }
        public readonly string FileName;
        public readonly int LineIndex;
    }
}
