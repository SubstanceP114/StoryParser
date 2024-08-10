namespace Data
{
    public interface ICommand
    {
        /// <summary>
        /// 指令处理方法
        /// </summary>
        public void Execute();
        /// <summary>
        /// 指令结束时的状态，用于跳过
        /// </summary>
        public void Complete();
    }
    /// <summary>
    /// 文本历史记录
    /// </summary>
    public interface ILog
    {
        /// <summary>
        /// 该消息位于哪一个文本
        /// </summary>
        public string FileName { get; }
        /// <summary>
        /// 该消息位于哪一条语句
        /// </summary>
        public int LineIndex { get; }
        public string Character { get; }
        public string Dialogue { get; }
    }
}

