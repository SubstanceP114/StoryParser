using StoryParser.Setting;
using SaveData = StoryParser.Archive.SaveData;

namespace StoryParser.Data
{
    public struct Condition
    {
        public Condition(string parameter)
        {
            char[] signals = new char[] { '>', '<', '=' };
            string[] infos = parameter.Split(signals);
            variable = infos[0];
            if (infos.Length == 2)
            {
                value = int.Parse(infos[1]);
                signal = parameter[parameter.IndexOfAny(signals)];
            }
        }
        private string variable;
        private char? signal;
        private int? value;
        public static implicit operator bool(Condition condition)
        {
            if (!SaveData.TryGetVariable(condition.variable, out int value))
                return false; // 找不到变量则为假
            return condition.signal switch
            {
                null => true, // 已找到变量且无需比较则为真
                '>' => value > condition.value,
                '<' => value < condition.value,
                '=' => value == condition.value,
                _ => false,
            };
        }
    }
    public struct Conditions
    {
        public Conditions(string parameter)
        {
            list = new();
            foreach (string info in parameter.Split(Seperators.parameter))
                list.Add(new Condition(info));
        }
        private List<Condition> list;
        public static implicit operator bool(Conditions conditions)
        {
            foreach (var condition in conditions.list)
                if (!condition)
                    return false;
            return true;
        }
    }
    public struct Locator
    {
        public Locator(string fileName, int lineIndex)
        {
            FileName = fileName;
            LineIndex = lineIndex;
        }
        public readonly string FileName;
        public readonly int LineIndex;
    }
}
