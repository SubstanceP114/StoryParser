using StoryParser.Data;

namespace StoryParser.Input
{
    public static class Player
    {
        public static string FileName { get; set; } = "";
        public static int LineIndex { get; set; } = 0;
        public static event Action? Executing;
        public static event Action? Executed;
        public static void Next()
        {
            
        }
    }
}
