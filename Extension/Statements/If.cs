using StoryParser.Core.Statement;
using StoryParser.Core.Util;
using StoryParser.Extension.Util;

namespace StoryParser.Extension.Statements
{
    public class If : IStatement, IDispatcher
    {
        public If(List<Condition> conditions, string target)
        {
            Conditions = conditions;
            Target = target;
        }
        public void Execute()
        {

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
            return new If(conditions, parameters[2]);
        }
        public readonly List<Condition> Conditions;
        public readonly string Target;
    }
}
