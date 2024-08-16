namespace StoryParser.Extension
{
    public static partial class Commands
    {
        public static partial void Menu(string content, int target);
        public static partial void Say(string? character, string? sprite, string dialogue);
        public static partial object GetValue(string key);
        public static partial void SetValue(string key, int value);
    }
}
