using StoryParser.Data;
using StoryParser.Setting;
using System.Text;

namespace StoryParser.Input
{
    public static class IntermediateFile
    {
        static IntermediateFile()
        {
            folders = new();
            folderName = Global.DefaultFolderName;
            EnterFolder(folderName);
        }
        private static Dictionary<string, Folder> folders;
        private static string folderName;
        /// <summary>
        /// 当前文件夹
        /// </summary>
        public static Folder Current => folders[folderName];
        /// <summary>
        /// 进入指定文件夹
        /// </summary>
        /// <param name="name">文件夹名称</param>
        public static void EnterFolder(string name)
        {
            if (!folders.ContainsKey(name))
                folders.Add(name, new());
            folderName = name;
        }
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
            Current.AddFile(name);
            using (StreamReader sr = new StreamReader(stream, encoding))
            {
                string? line;
                await Task.Run(() =>
                {
                    while ((line = sr.ReadLine()) != null)
                        if (line[0] != Seperators.note)
                            Current[name].AddLine(name, Current[name].Length, line);
                });
            }
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
            Current.AddFile(name);
            using (StreamReader sr = new StreamReader(stream, encoding))
            {
                string? line;
                while ((line = sr.ReadLine()) != null)
                    if (line[0] != Seperators.note)
                        Current[name].AddLine(name, Current[name].Length, line);
            }
            Loaded?.Invoke();
        }
    }
}
