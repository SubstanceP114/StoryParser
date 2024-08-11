namespace StoryParser.Data
{
    public abstract class Statement
    {
        public Statement(string fileName, int lineIndex)
        {
            FileName = fileName;
            LineIndex = lineIndex;
        }
        /// <summary>
        /// 该语句位于哪一个脚本
        /// </summary>
        public string FileName { get; protected set; }
        /// <summary>
        /// 该语句位于脚本哪一行
        /// </summary>
        public int LineIndex { get; protected set; }
        /// <summary>
        /// 该语句对应的指令
        /// </summary>
        public abstract Task Command { get; }
    }
}
