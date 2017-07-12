using ConsoleSchemaManager.Commands;

namespace ConsoleSchemaManager.CommandHandlers
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TCommand">The type of the command.</typeparam>
    public interface ICommandHandler<TCommand> where TCommand : ICommand
    {
        /// <summary>
        /// Handles the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns></returns>
        int Handle(TCommand command);
    }
}
