using StoryParser.Core.Input;
using StoryParser.Core.Statement;
using StoryParser.Core.Util;

namespace StoryParser.Extension
{
    public class If : IStatement, IDispatcher
    {
        public If(List<Condition> conditions, int target)
        {
            this.conditions = conditions;
            this.target = target;
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
                if (infos.Length != 2)
                    throw new ArgumentException(string.Format("{0}条件声明有误", parameters), nameof(parameters));
                conditions.Add(new Condition(infos[0], info[info.IndexOfAny(signals)], infos[1]));
            }
            return new If(conditions, int.Parse(parameters[2]));
        }
        private readonly List<Condition> conditions;
        private readonly int target;
        public readonly struct Condition
        {
            public Condition(string var1, char signal, string var2)
            {
                Var1 = var1;
                Signal = signal;
                Var2 = var2;
            }
            public readonly string Var1, Var2;
            public readonly char Signal;
        }
        private bool Meet(Condition condition)
        {
            if (!float.TryParse(condition.Var1, out float v1))
                v1 = float.Parse(Commands.GetValue(condition.Var1).ToString()!);
            if (!float.TryParse(condition.Var2, out float v2))
                v2 = float.Parse(Commands.GetValue(condition.Var2).ToString()!);
            return condition.Signal switch
            {
                '>' => v1 - v2 > 0,
                '<' => v1 - v2 < 0,
                '=' => MathF.Abs(v1 - v2) < .01f,
                _ => false
            };
        }
    }
}
