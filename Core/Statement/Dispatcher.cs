namespace StoryParser.Core.Statement
{
    public static class Dispatcher
    {
        private static Dictionary<string, IDispatcher> dispatchers = new() { { "PAUSE", new Pause() } };
        /// <summary>
        /// 注册调度器
        /// <br/>读取中间文件前请务必注册相应的调度器
        /// </summary>
        /// <param name="dispatcher">调度器实例</param>
        public static void RegisterDispatcher(string name, IDispatcher dispatcher)
            => dispatchers.Add(name, dispatcher);
        internal static IStatement Execute(string[] parameters)
            => dispatchers[parameters[0]].Dispatch(parameters);
    }
}
