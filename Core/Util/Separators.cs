namespace StoryParser.Core.Util
{
    public static class Separators
    {
        public static char Parameter { get; set; } = ' ';
        public static char Statement { get; set; } = '|';
        public static char Line { get; set; } = '^';
        public static char Comment { get; set; } = '#';
    }
}
