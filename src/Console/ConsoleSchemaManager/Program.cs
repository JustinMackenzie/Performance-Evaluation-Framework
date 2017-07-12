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
                CreateScenarioCommand, 
                CreateSchemaEventCommand, 
                CreateSchemaTaskCommand,
                CreateTaskTransitionCommand>(args)
                .MapResult(
                    (CreateSchemaCommand options) => new CreateSchemaCommandHandler(schemaService).Handle(options),
                    (CreateScenarioCommand options) => new CreateScenarioCommandHandler(schemaService).Handle(options),
                    (CreateSchemaEventCommand options) => new CreateSchemaEventCommandHandler(schemaService).Handle(options),
                    (CreateSchemaTaskCommand options) => new CreateSchemaTaskCommandHandler(schemaService).Handle(options),
                    (CreateTaskTransitionCommand options) => new CreateTaskTransitionCommandHandler(schemaService).Handle(options),
                    errs => 1);
        }
    }
}