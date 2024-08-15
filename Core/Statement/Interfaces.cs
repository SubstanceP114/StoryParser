namespace StoryParser.Core.Statement
{
    /// <summary>
    /// 自定义语句应当实现该接口，请务必编写相应的调度器<see cref="IDispatcher"/>
    /// </summary>
    public interface IStatement
    {
        /// <summary>
        /// 该语句对应的指令
        /// </summary>
        void Execute();
    }
    /// <summary>
    /// 调度器应当实现该接口，再通过<see cref="Dispatcher.Register"/>注册
    /// </summary>
    public interface IDispatcher
    {
        /// <summary>
        /// 通过传入的参数创建相应的语句
        /// </summary>
        /// <param name="parameters">传入参数</param>
        /// <returns>新建语句</returns>
        IStatement Dispatch(string[] parameters);
    }
}
