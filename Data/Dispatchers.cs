using StoryParser.Data.Statements;

namespace StoryParser.Data
{
    public abstract class Dispatcher
    {
        public Dispatcher(string name) => this.name = name;
        protected readonly string name;
        protected abstract Statement Dispatch(string[] parameters);
        private static Dictionary<string, Dispatcher> dispatchers = new();
        public static void AddDispatcher(Dispatcher dispatcher)
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
