using StoryParser.Core.Util;

namespace StoryParser.Core.Statement
{
    /// <summary>
    /// 自定义语句应当实现该接口，请务必编写相应的调度器，再通过<see cref="Dispatcher.RegisterDispatcher"/>注册调度器
    /// </summary>
    public interface IStatement
    {
        /// <summary>
        /// 该语句对应的指令
        /// </summary>
        /// <returns>该指令应当执行的任务</returns>
        Task Command();
    }
    /// <summary>
    /// 调度器应当实现该接口
    /// </summary>
    public interface IDispatcher
    {
        IStatement Dispatch(string[] parameters);
    }
}
