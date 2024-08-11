namespace StoryParser.Data
{
    /// <summary>
    /// 文本历史记录
    /// </summary>
    public interface ILoggable
    {
        public string Character { get; }
        public string Dialogue { get; }
    }
}

