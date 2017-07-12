using ConsoleSchemaManager.Commands;

namespace ConsoleSchemaManager.CommandHandlers
{
    public interface ICommandHandler<TCommand> where TCommand : ICommand
    {
        int Handle(TCommand command);
    }
}
