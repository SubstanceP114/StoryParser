namespace StoryParser.Data
{
    /// <summary>
    /// 继承类请务必通过<see cref="RegisterStatement"/>注册至<see cref="statements"/>
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
            FileName = fileName;
            LineIndex = lineIndex;
            return this;
        }
        /// <summary>
        /// 该语句位于哪一个脚本
        /// </summary>
        public string FileName { get; private set; } = "";
        /// <summary>
        /// 该语句位于脚本哪一行
        /// </summary>
        public int LineIndex { get; private set; } = 0;
    }
}
