using System;
using CommandLine;
using ConsoleSchemaManager.Commands;
using ConsoleSchemaManager.Services;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace ConsoleSchemaManager
{
    class Program
    {
        static void Main(string[] args)
        {
            IServiceCollection serviceCollection = new ServiceCollection();
            serviceCollection.AddMediatR();
            serviceCollection.AddTransient<ISchemaService, SchemaService>();

            IServiceProvider provider = serviceCollection.BuildServiceProvider();

            IMediator mediator = provider.GetService<IMediator>();

            Parser.Default.ParseArguments<CreateSchemaCommand,
                CreateSchemaEventCommand, 
                CreateSchemaTaskCommand,
                CreateTaskTransitionCommand,
                CreateSchemaAssetCommand>(args)
                .MapResult(
                    (CreateSchemaCommand command) => mediator.Send(command).Result,
                    (CreateSchemaEventCommand command) => mediator.Send(command).Result,
                    (CreateSchemaTaskCommand command) => mediator.Send(command).Result,
                    (CreateTaskTransitionCommand command) => mediator.Send(command).Result,
                    (CreateSchemaAssetCommand command) => mediator.Send(command).Result,
                    errs => 1);
        }
    }
}