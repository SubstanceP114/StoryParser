namespace StoryParser.Core.Util
{
    public readonly struct Locator
    {
        public Locator(string name, int index)
        {
            FileName = name;
            LineIndex = index;
        }
        public readonly string FileName;
        public readonly int LineIndex;
    }
}
