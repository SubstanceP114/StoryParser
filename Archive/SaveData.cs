using StoryParser.Setting;
using System.Text;
using System.Text.Json;
namespace StoryParser.Archive
{
    public static class SaveData
    {
        static SaveData()
        {
            try
            {
                Info = JsonSerializer.Deserialize<GlobalInfo>(File.ReadAllText(Global.ArchivePath, Encoding.UTF8));
            }
            catch
            {
                Info = new();
            }
        }
        public static GlobalInfo Info { get; set; }
        public static LocalInfo Current { get; set; }
        public static int Count => Info.Files.Count;
        public static event Action<GlobalInfo>? Saving;
        public static event Action<GlobalInfo>? Saved;
        public static event Action<LocalInfo>? Loaded;
        /// <summary>
        /// 设置全局变量
        /// </summary>
        /// <param name="key">变量名称</param>
        /// <param name="value">变量变化的值</param>
        public static void SetGlobal(string key, int value)
        {
            if (Info.GlobalVariables.ContainsKey(key))
                Info.GlobalVariables.Add(key, value);
            else Info.GlobalVariables[key] = value;
        }
        /// <summary>
        /// 设置当前存档变量
        /// </summary>
        /// <param name="key">变量名称</param>
        /// <param name="value">变量变化的值</param>
        public static void SetLocal(string key, int value)
        {
            if (Current.LocalVariables.ContainsKey(key))
                Current.LocalVariables[key] = value;
            else Current.LocalVariables[key] += value;
        }
        /// <summary>
        /// 尝试获取一个变量的值
        /// </summary>
        /// <param name="key">变量名称</param>
        /// <param name="value">变量的值</param>
        /// <returns>是否找到该变量</returns>
        public static bool TryGetVariable(string key, out int value)
        {
            if (Info.GlobalVariables.TryGetValue(key, out int globalResult))
            {
                value = globalResult;
                return true;
            }
            if (Current.LocalVariables.TryGetValue(key, out int localResult))
            {
                value = localResult;
                return true;
            }
            value = 0;
            return false;
        }
        /// <summary>
        /// 保存当前进度到指定存档
        /// </summary>
        /// <param name="name">存档名称</param>
        public static async void Save(string name)
        {
            Saving?.Invoke(Info);
            Info.Files.Remove(name);
            Info.Files.Add(name, Current);
            await Task.Run(() => File.WriteAllText(Global.ArchivePath, JsonSerializer.Serialize(Info), Encoding.UTF8));
            Saved?.Invoke(Info);
        }
        /// <summary>
        /// 加载指定存档
        /// </summary>
        /// <param name="name">存档名称</param>
        public static void Load(string name)
        {
            Current = Info.Files[name];
            Loaded?.Invoke(Current);
        }
    }
}
