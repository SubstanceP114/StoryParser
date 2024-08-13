using StoryParser.Core.Util;
using StoryParser.Core.Data;

namespace StoryParser.Core.Input
{
    public static class Executor
    {
        public static Locator Position { get; private set; }
        public static event Action? Executing;
        public static event Action? Executed;
        public static Line CurrentLine => IntermediateFile.Current[Position];
        /// <summary>
        /// 定位到指定文件的指定行数
        /// </summary>
        /// <param name="fileName">目标文件名称</param>
        /// <param name="lineIndex">目标行数</param>
        public static void Locate(string fileName, int lineIndex)
            => Position = new Locator(fileName, lineIndex);
        /// <summary>
        /// 定位到指定文件的指定行数
        /// </summary>
        /// <param name="line">目标行</param>
        public static void Locate(Line line) => Position = line.Position;
        /// <summary>
        /// 定位到指定文件的指定行数
        /// </summary>
        /// <param name="line">目标位置</param>
        public static void Locate(Locator position) => Position = position;
        private static void NextLine()
            => Locate(Position.FileName, Position.LineIndex + 1);
        // 防止反复Execute，支持语句加速执行
        private static int executeCount = 0;
        public static bool Accelerate => executeCount > 2;
        public async static void Execute()
        {
            executeCount++;
            if (executeCount > 1) return;
            Executing?.Invoke();
            await CurrentLine.Execute();
            Executed?.Invoke();
            executeCount = 0;
            NextLine();
        }
    }
}
