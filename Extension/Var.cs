using StoryParser.Core.Input;
using StoryParser.Core.Statement;

namespace StoryParser.Extension
{
    public class Var : IStatement, IDispatcher
    {
        public Var(string operation, string key, string var1, string var2)
        {
            this.operation = operation;
            this.key = key;
            this.var1 = var1;
            this.var2 = var2;
        }
        public void Execute()
        {
            float v1 = float.TryParse(var1, out float f1) ? f1 : float.Parse(Commands.GetValue(var1).ToString()!);
            float v2 = float.TryParse(var1, out float f2) ? f2 : float.Parse(Commands.GetValue(var2).ToString()!);
            Commands.SetValue(key, (int)(.5f + operation switch
            {
                "ADD" => v1 + v2,
                "SUB" => v1 - v2,
                "MUL" => v1 * v2,
                "DIV" => v1 / v2,
                _ => 0
            }));
            Executor.Complete();
        }
        public IStatement Dispatch(string[] parameters)
        {
            if (parameters.Length != 5)
                throw new ArgumentException(string.Format("{0}数组长度有误", parameters), nameof(parameters));
            if (parameters[2] != "ADD" || parameters[2] != "SUB" || parameters[2] != "MUL" || parameters[2] != "DIV")
                throw new ArgumentException(string.Format("{0}操作声明有误", parameters[2]));
            return new Var(parameters[1], parameters[2], parameters[3], parameters[4]);
        }
        private readonly string operation, key, var1, var2;
    }
}
