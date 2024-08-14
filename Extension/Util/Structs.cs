using StoryParser.Core.Util;
using SaveData = StoryParser.Core.Archive.SaveData;

namespace StoryParser.Extension.Util
{
    public readonly struct Condition
    {
        public Condition(string variable)
        {
            Variable = variable;
        }
        public Condition(string variable, char signal, int value)
        {
            Variable = variable;
            Signal = signal;
            Value = value;
        }
        public readonly string Variable;
        public readonly char? Signal;
        public readonly int? Value;
        //public static implicit operator bool(Condition condition)
        //{
        //    if (!SaveData.TryGetVariable(condition.Variable, out int value))
        //        return false; // 找不到变量则为假
        //    return condition.Signal switch
        //    {
        //        null => true, // 已找到变量且无需比较则为真
        //        '>' => value > condition.Value,
        //        '<' => value < condition.Value,
        //        '=' => value == condition.Value,
        //        _ => false,
        //    };
        //}
    }
    //public readonly struct Option
    //{
    //    public Option(string description)
    //    {
    //        Description = description;
    //    }
    //    public Option(string description, string variable, int value)
    //    {
    //        Description = description;
    //        Variable = variable;
    //        Value = value;
    //    }
    //    public readonly string Description;
    //    public readonly string? Variable;
    //    public readonly int? Value;
    //    public static implicit operator string(Option option) => option.Description;
    //}
}
