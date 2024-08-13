using StoryParser.Core.Util;

namespace StoryParser.Core.Data
{
    /// <summary>
    /// 继承类请务必编写相应的调度器，再通过<see cref="Dispatcher.RegisterDispatcher"/>注册调度器
    /// </summary>
    public abstract class Statement
    {
        /// <summary>
        /// 该语句对应的指令
        /// </summary>
        /// <returns>该指令应当执行的任务</returns>
        public abstract Task Command();
        /// <summary>
        /// 用于创建新语句
        /// </summary>
        /// <param name="fileName"><see cref="FileName"/></param>
        /// <param name="lineIndex"><see cref="LineIndex"/></param>
        /// <param name="parameters">创建新语句用到的参数</param>
        /// <returns>新语句</returns>
        public static Statement Create(string fileName, int lineIndex, string[] parameters)
            => Dispatcher.Execute(parameters).Locate(fileName, lineIndex);
        private Statement Locate(string fileName, int lineIndex)
        {
            Position = new Locator(fileName, lineIndex);
            return this;
        }
        public Locator Position { get; private set; }
    }
}
