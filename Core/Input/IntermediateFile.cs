using System.Text;

namespace StoryParser.Core.Input
{
    public static class IntermediateFile
    {
        static IntermediateFile()
        {
            Current = new();
        }
        public static Dictionary<string, Statement.File> Current;
        public static event Action? Loading;
        public static event Action? Loaded;
        /// <summary>
        /// 异步读取指定中间文件
        /// </summary>
        /// <param name="name">文件名（并非路径，只是用于标识）</param>
        /// <param name="stream">目标文件流</param>
        /// <param name="encoding">编码方式</param>
        public async static void LoadAsync(string name, Stream stream, Encoding encoding)
        {
            Loading?.Invoke();
            Current.Add(name, new());
            using (StreamReader sr = new StreamReader(stream, encoding))
            {
                string? line;
                await Task.Run(() => { while ((line = sr.ReadLine()) != null) Current[name].AddLine(line); });
            }
            Loaded?.Invoke();
        }
        /// <summary>
        /// 异步读取指定中间文件
        /// <param name="name">文件名（并非路径，只是用于标识）</param>
        /// <param name="content">文本内容</param>
        /// </summary>
        public async static void LoadAsync(string name, string[] content)
        {
            Loading?.Invoke();
            Current.Add(name, new());
            await Task.Run(() => { foreach (string line in content) Current[name].AddLine(line); });
            Loaded?.Invoke();
        }
        /// <summary>
        /// 同步读取指定中间文件
        /// <br/>感觉会卡，推荐使用<see cref="LoadAsync"/>
        /// </summary>
        /// <param name="name">文件名（并非路径，只是用于标识）</param>
        /// <param name="stream">目标文件流</param>
        /// <param name="encoding">编码方式</param>
        public static void Load(string name, Stream stream, Encoding encoding)
        {
            Loading?.Invoke();
            Current.Add(name, new());
            using (StreamReader sr = new StreamReader(stream, encoding))
            {
                string? line;
                while ((line = sr.ReadLine()) != null) Current[name].AddLine(line);
            }
            Loaded?.Invoke();
        }
        /// <summary>
        /// 异步读取指定中间文件
        /// <param name="name">文件名（并非路径，只是用于标识）</param>
        /// <param name="content">文本内容</param>
        /// </summary>
        public static void Load(string name, string[] content)
        {
            Loading?.Invoke();
            Current.Add(name, new());
            foreach (string line in content) Current[name].AddLine(line);
            Loaded?.Invoke();
        }
    }
}
