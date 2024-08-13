using StoryParser.Core.Setting;

namespace StoryParser.Core.Archive
{
    public struct GlobalInfo
    {
        public Dictionary<string, int> GlobalVariables { get; set; }
        public Dictionary<string, LocalInfo> Files { get; set; }
    }
    public struct LocalInfo
    {
        public LocalInfo(string fileName, int lineIndex, Dictionary<string, int> localVariables)
        {
            FileName = fileName;
            LineIndex = lineIndex;
            LocalVariables = localVariables;
        }
        /// <summary>
        /// 存档进度位于哪一个脚本
        /// </summary>
        public string FileName { get; set; }
        /// <summary>
        /// 存档进度位于脚本哪一行
        /// </summary>
        public int LineIndex { get; set; }
        public Dictionary<string, int> LocalVariables { get; set; }
    }
}
