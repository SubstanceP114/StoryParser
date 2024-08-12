using StoryParser.Data.Statements;

namespace StoryParser.Data
{
    public abstract class Dispatcher
    {
        /// <param name="name">调度器对应语句名称</param>
        public Dispatcher(string name) => this.name = name;
        /// <summary>
        /// 调度器对应语句名称
        /// </summary>
        protected readonly string name;
        protected abstract Statement Dispatch(string[] parameters);
        private static Dictionary<string, Dispatcher> dispatchers = new();
        /// <summary>
        /// 注册调度器
        /// <br/>读取中间文件前请务必注册相应的调度器
        /// </summary>
        /// <param name="dispatcher">调度器实例</param>
        public static void RegisterDispatcher(Dispatcher dispatcher)
            => dispatchers.Add(dispatcher.name, dispatcher);
        public static Statement Execute(string[] parameters)
            => dispatchers[parameters[0]].Dispatch(parameters);
    }
    public class SayDispatcher : Dispatcher
    {
        public SayDispatcher(string name) : base(name) { }
        protected override SayStatement Dispatch(string[] parameters) => new SayStatement(parameters);
    }
}
