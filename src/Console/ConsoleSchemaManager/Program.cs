using CommandLine;
using ConsoleSchemaManager.CommandHandlers;
using ConsoleSchemaManager.Commands;
using ConsoleSchemaManager.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ConsoleSchemaManager
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddTransient<ISchemaService, SchemaService>()
                .BuildServiceProvider();

            ISchemaService schemaService = serviceProvider.GetService<ISchemaService>();

            Parser.Default.ParseArguments<CreateSchemaCommand,
                CreateSchemaEventCommand, 
                CreateSchemaTaskCommand,
                CreateTaskTransitionCommand,
                CreateSchemaAssetCommand>(args)
                .MapResult(
                    (CreateSchemaCommand command) => new CreateSchemaCommandHandler(schemaService).Handle(command),
                    (CreateSchemaEventCommand command) => new CreateSchemaEventCommandHandler(schemaService).Handle(command),
                    (CreateSchemaTaskCommand command) => new CreateSchemaTaskCommandHandler(schemaService).Handle(command),
                    (CreateTaskTransitionCommand command) => new CreateTaskTransitionCommandHandler(schemaService).Handle(command),
                    (CreateSchemaAssetCommand command) => new CreateSchemaAssetCommandHandler(schemaService).Handle(command),
                    errs => 1);
        }
    }
}