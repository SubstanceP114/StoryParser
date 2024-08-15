using StoryParser.Core.Input;
using StoryParser.Core.Statement;
using StoryParser.Extension.Output;

namespace StoryParser.Extension.Statements
{
    public class Vary : IStatement, IDispatcher
    {
        public Vary(string key, int value)
        {
            this.key = key;
            this.value = value;
        }
        public void Execute()
        {
            if (Commands.DataProvider!.TryGetInt(key, out int value))
                Commands.DataProvider.SetInt(key, value + this.value);
            else Commands.DataProvider.SetInt(key, this.value);
            Executor.Complete();
        }
        public IStatement Dispatch(string[] parameters)
        {
            if (parameters.Length != 3)
                throw new ArgumentException(string.Format("{0}数组长度有误", parameters), nameof(parameters));
            return new Menu(parameters[1], int.Parse(parameters[2]));
        }
        private readonly string key;
        private readonly int value;
    }
}
