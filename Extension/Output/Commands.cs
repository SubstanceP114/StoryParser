using StoryParser.Extension.Util;

namespace StoryParser.Extension.Output
{
    public static partial class Commands
    {
        static Commands() => SetDataProvider();
        static partial void Menu(string content, int target);
        public static void MenuCommand(string content, int target) => Menu(content, target);
        static partial void Say(string? character, string? sprite, string dialogue);
        public static void SayCommand(string? character, string? sprite, string dialogue) => Say(character, sprite, dialogue);
        public static IDataProvider? DataProvider { get; private set; }
        static partial void SetDataProvider();
    }
}
