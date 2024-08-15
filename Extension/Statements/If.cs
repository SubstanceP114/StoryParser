using StoryParser.Core.Input;
using StoryParser.Core.Statement;
using StoryParser.Core.Util;
using StoryParser.Extension.Output;
using StoryParser.Extension.Util;

namespace StoryParser.Extension.Statements
{
    public class If : IStatement, IDispatcher
    {
        public If(List<Condition> conditions, int target)
        {
            this.conditions = conditions;
            this.target = target;
        }
        private bool Meet(Condition condition)
        {
            if (!Commands.DataProvider!.TryGetInt(condition.Variable, out int value))
                return false; // 找不到变量则为假
            return condition.Signal switch
            {
                null => true, // 已找到变量且无需比较则为真
                '>' => value > condition.Value,
                '<' => value < condition.Value,
                '=' => value == condition.Value,
                _ => false,
            };
        }
        public void Execute()
        {
            if (conditions.Count == 0 || conditions.All(Meet))
                Executor.Locate(target - 1);
            Executor.Complete();
        }
        public IStatement Dispatch(string[] parameters)
        {
            if (parameters.Length != 3)
                throw new ArgumentException(string.Format("{0}数组长度有误", parameters), nameof(parameters));
            List<Condition> conditions = new();
            char[] signals = new char[] { '>', '<', '=' };
            foreach (var info in parameters[1].Split(Separators.Parameter))
            {
                string[] infos = info.Split(signals);
                conditions.Add(infos.Length switch
                {
                    1 => new Condition(info),
                    2 => new Condition(infos[0], info[info.IndexOfAny(signals)], int.Parse(infos[1])),
                    _ => throw new ArgumentException(string.Format("{0}条件声明有误", parameters), nameof(parameters)),
                });
            }
            return new If(conditions, int.Parse(parameters[2]));
        }
        private readonly List<Condition> conditions;
        private readonly int target;
    }
}
