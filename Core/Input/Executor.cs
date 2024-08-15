using StoryParser.Core.Util;
using StoryParser.Core.Statement;

namespace StoryParser.Core.Input
{
    public static class Executor
    {
        public static Locator Position { get; private set; }
        internal static bool Pause { get; set; }
        private static int count;
        /// <summary>
        /// 开始执行一系列语句
        /// </summary>
        public static event Action? Executing;
        /// <summary>
        /// 一系列语句执行完毕
        /// </summary>
        public static event Action? Executed;
        /// <summary>
        /// 开始处理一行语句
        /// </summary>
        public static event Action<Locator>? LineProcessing;
        /// <summary>
        /// 一行语句处理完毕
        /// </summary>
        public static event Action<Locator>? LineProcessed;
        public static Line CurrentLine =>
            IntermediateFile.Current[Position.FileName][Position.LineIndex];
        /// <summary>
        /// 定位到指定行数
        /// </summary>
        /// <param name="lineIndex">目标行数</param>
        public static void Locate(int lineIndex)
            => Position = new Locator(Position.FileName, lineIndex);
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
        private static void Launch(int count) => Executor.count = count;
        /// <summary>
        /// 语句执行完毕
        /// </summary>
        public static void Complete() => count--;
        public async static void Execute()
        {
            Executing?.Invoke();
            Pause = false;
            while (!Pause)
                await Process();
            Executed?.Invoke();
        }
        private async static Task Process()
        {
            LineProcessing?.Invoke(Position);
            Launch(CurrentLine.Length);
            CurrentLine.Execute();
            await Task.Run(() => count == 0);
            LineProcessed?.Invoke(Position);
            NextLine();
        }
    }
}
