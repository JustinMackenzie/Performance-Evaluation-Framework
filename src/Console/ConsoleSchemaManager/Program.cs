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

            Parser.Default.ParseArguments<CreateSchemaCommand, CreateScenarioCommand, CreateSchemaEventCommand, CreateSchemaTaskCommand>(args)
                .MapResult(
                    (CreateSchemaCommand options) => new CreateSchemaCommandHandler(serviceProvider.GetService<ISchemaService>()).Handle(options),
                    (CreateScenarioCommand options) => new CreateScenarioCommandHandler(serviceProvider.GetService<ISchemaService>()).Handle(options),
                    (CreateSchemaEventCommand options) => new CreateSchemaEventCommandHandler(serviceProvider.GetService<ISchemaService>()).Handle(options),
                    (CreateSchemaTaskCommand options) => new CreateSchemaTaskCommandHandler(serviceProvider.GetService<ISchemaService>()).Handle(options),
                    errs => 1);
        }
    }
}