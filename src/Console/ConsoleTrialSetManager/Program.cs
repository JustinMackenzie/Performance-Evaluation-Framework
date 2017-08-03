using System;
using CommandLine;
using ConsoleTrialSetManager.Commands;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace ConsoleTrialSetManager
{
    class Program
    {
        static void Main(string[] args)
        {
            IServiceCollection serviceCollection = new ServiceCollection();
            serviceCollection.AddMediatR();

            IServiceProvider provider = serviceCollection.BuildServiceProvider();

            IMediator mediator = provider.GetService<IMediator>();

            Parser.Default.ParseArguments<CreateTrialSetCommand, AddScenarioToTrialSetCommand, 
                RemoveScenarioFromTrialSetCommand, UpdateTrialSetNameCommand>(args)
                .MapResult((CreateTrialSetCommand command) => mediator.Send(command).Result,
                    (AddScenarioToTrialSetCommand command) => mediator.Send(command).Result,
                    (RemoveScenarioFromTrialSetCommand command) => mediator.Send(command).Result,
                    (UpdateTrialSetNameCommand command) => mediator.Send(command).Result,
                    errs => 1);
        }
    }
}