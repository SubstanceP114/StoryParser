using StoryParser.Core.Statement;
using StoryParser.Core.Util;
using StoryParser.Extension.Statements;
using StoryParser.Extension.Util;

namespace StoryParser.Extension.Dispatchers
{
    public class SelectDispatcher : IDispatcher
    {
        private List<Option>? options;
        private string[]? infos;
        public IStatement Dispatch(string[] parameters)
        {
            if (parameters.Length < 2)
                throw new ArgumentException(string.Format("{0}数组长度有误", parameters), nameof(parameters));
            options = new();
            for (int i = 1; i < parameters.Length; i++)
            {
                infos = parameters[i].Split(Separators.Parameter);
                options.Add(infos.Length switch
                {
                    1 => new Option(parameters[i]),
                    3 => new Option(infos[0], infos[1], int.Parse(infos[2])),
                    _ => throw new ArgumentException(string.Format("{0}条件声明有误", parameters), nameof(parameters)),
                });
            }
            return new SelectStatement(options);
        }
    }
}
