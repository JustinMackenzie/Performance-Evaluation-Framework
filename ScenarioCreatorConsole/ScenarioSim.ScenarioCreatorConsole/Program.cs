using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using ScenarioSim.Core.Entities;
using ScenarioSim.Services.ScenarioCreator;

namespace ScenarioSim.ScenarioCreatorConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            UnityContainer container = new UnityContainer();
            container.LoadConfiguration();

            ISchemaManager schemaManager = container.Resolve<ISchemaManager>();
            IScenarioManager scenarioManager = container.Resolve<IScenarioManager>();
            IActorManager actorManager = container.Resolve<IActorManager>();

            Actor actor = new Actor
            {
                Id = Guid.NewGuid(),
                Name = "Fitts' Performer",
                Description = "The user performing the fitt's multiphase task."
            };

            Task navigateToTarget1 = new Task { Id = Guid.NewGuid(), Name = "Navigate to Target 1", ActorId = actor.Id };
            Task navigateThroughTunnel = new Task { Id = Guid.NewGuid(), Name = "Navigate through Tunnel", ActorId = actor.Id };
            Task navigateToTarget2 = new Task { Id = Guid.NewGuid(), Name = "Navigate to Target 2", ActorId = actor.Id };

            CompositeTask compositeTask = new CompositeTask
            {
                Id = Guid.NewGuid(),
                ActorId = actor.Id,
                Name = "Combined Fitts' Task",
                Tasks = new List<Task> { navigateToTarget1, navigateThroughTunnel, navigateToTarget2 }
            };

            Task reactionTask = new Task
            {
                Id = Guid.NewGuid(),
                ActorId = actor.Id,
                Name = "React to Red Light"
            };

            ParallelTask task = new ParallelTask
            {
                Id = Guid.NewGuid(),
                ActorId = actor.Id,
                Name = "Fitts' Multiphase Task",
                Tasks = new List<Task> { compositeTask, reactionTask }
            };

            Schema schema = new Schema
            {
                Id = Guid.NewGuid(),
                Name = "Fitts' Multiphase Task",
                Description =
                    "A three phase task that requires the user to move to a target, navigate a tunnel and then move to a second target, while having to react to a light that appears.",
                Task = task,
                TaskTransitions = new List<TaskTransition>
                {
                    new TaskTransition { SourceId = navigateToTarget1.Id, Id = Guid.NewGuid(), DestinationId = navigateThroughTunnel.Id },
                    new TaskTransition { SourceId = navigateThroughTunnel.Id, Id = Guid.NewGuid(), DestinationId = navigateToTarget2.Id }
                }
            };

            Scenario scenario = new Scenario
            {
                Id = Guid.NewGuid(),
                Description = "A simple scenario of the fitts' multiphase task schema.",
                Name = "Fitts' Multiphase Task 1",
                SchemaId = schema.Id,
                ScenarioTaskDefinitions = new List<ScenarioTaskDefinition>
                {
                    new ScenarioTaskDefinition { TaskId = navigateToTarget1.Id, TaskValues = new FittsTaskValues(4, 1)},
                    new ScenarioTaskDefinition { TaskId = navigateThroughTunnel.Id, TaskValues = new SteeringTaskValues(8, 3)},
                    new ScenarioTaskDefinition { TaskId = navigateToTarget2.Id, TaskValues = new FittsTaskValues(3, 1)},
                },
                ScenarioAssets = new List<ScenarioAsset>
                {
                    new ScenarioAsset { Id = Guid.NewGuid(), Transform = new Transform(new Vector3f(-4,0,0), new Vector3f(0,0,0), new Vector3f(1,1,1))},
                    new ScenarioAsset { Id = Guid.NewGuid(), Transform = new Transform(new Vector3f(4,0,0), new Vector3f(0,0,0), new Vector3f(1,1,1))},
                    new ScenarioAsset { Id = Guid.NewGuid(), Transform = new Transform(new Vector3f(4,3,0), new Vector3f(0,0,0), new Vector3f(1,1,1))},
                    new ScenarioAsset { Id = Guid.NewGuid(), Transform = new Transform(new Vector3f(0,0,0), new Vector3f(0,0,0), new Vector3f(1,1,1))},
                    new ScenarioAsset { Id = Guid.NewGuid(), Transform = new Transform(new Vector3f(-4,-4,0), new Vector3f(0,0,0), new Vector3f(1,1,1))}
                }

            };

            actorManager.CreateActor(actor);
            schemaManager.CreateSchema(schema);
            scenarioManager.CreateScenario(scenario);
        }
    }
}
