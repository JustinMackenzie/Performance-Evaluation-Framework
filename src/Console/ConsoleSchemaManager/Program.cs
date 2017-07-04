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

            Parser.Default.ParseArguments<CreateSchemaCommand>(args)
                .MapResult(
                    options => new CreateSchemaCommandHandler(serviceProvider.GetService<ISchemaService>()).Handle(options),
                    errs => 1);
        }
    }
}