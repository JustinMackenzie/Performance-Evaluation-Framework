using System;
using CommandLine;
using ConsoleScenarioManager.Commands;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace ConsoleScenarioManager
{
    /// <summary>
    /// 
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            IServiceCollection serviceCollection = new ServiceCollection();
            serviceCollection.AddMediatR();

            IServiceProvider provider = serviceCollection.BuildServiceProvider();

            IMediator mediator = provider.GetService<IMediator>();

            Parser.Default.ParseArguments<CreateScenarioCommand,
                AddScenarioAssetCommand,
                RemoveScenarioAssetCommand,
                RemoveScenarioCommand,
                ViewScenarioCommand,
                ViewAllScenariosCommand,
                CreateProcedureCommand>(args)
                .MapResult(
                    (CreateScenarioCommand command) => mediator.Send(command).Result,
                    (AddScenarioAssetCommand command) => mediator.Send(command).Result,
                    (RemoveScenarioAssetCommand command) => mediator.Send(command).Result,
                    (RemoveScenarioCommand command) => mediator.Send(command).Result,
                    (ViewScenarioCommand command) => mediator.Send(command).Result,
                    (ViewAllScenariosCommand command) => mediator.Send(command).Result,
                    (CreateProcedureCommand command) => mediator.Send(command).Result,
                    errs => 1);
        }
    }
}