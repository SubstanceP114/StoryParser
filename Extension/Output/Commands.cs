using StoryParser.Core.Statement;
using StoryParser.Extension.Statements;
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
        /// <summary>
        /// 注册Extension命名空间下的所有语句调度器
        /// </summary>
        public static void RegisterExtension()
        {
            Dispatcher.Register("IF", new If(new(), 0));
            Dispatcher.Register("MENU", new Menu("", 0));
            Dispatcher.Register("SAY", new Say(null, null, ""));
            Dispatcher.Register("VARY", new Vary("", 0));
        }
    }
}
