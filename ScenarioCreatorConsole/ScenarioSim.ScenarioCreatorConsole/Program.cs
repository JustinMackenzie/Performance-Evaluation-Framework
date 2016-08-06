using System;
using System.Collections.Generic;
using System.IO;
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
            IAssetManager assetManager = container.Resolve<IAssetManager>();
            IProgramManager programManager = container.Resolve<IProgramManager>();

            FittsMultiPhaseProgramGenerator generator = new FittsMultiPhaseProgramGenerator(scenarioManager, programManager);

            generator.Generate(schemaManager.GetSchema(Guid.Parse("2b439b2e-9530-4e9c-b5e6-2c814275bbd3")), "Multi-Phase Fitts Task Set", 10);

            /*Actor actor = new Actor
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

            Asset target = new Asset { Id = Guid.NewGuid(), Name = "Target", Description = "The target to hit" };
            Asset tunnel = new Asset { Id = Guid.NewGuid(), Name = "Tunnel", Description = "The tunnel to navigate through." };
            Asset device = new Asset { Id = Guid.NewGuid(), Name = "Device", Description = "The device used to target with." };
            Asset finalTarget = new Asset { Id = Guid.NewGuid(), Name = "Final Target", Description = "The final target to hit." };

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
                    new ScenarioTaskDefinition { TaskId = reactionTask.Id, TaskValues = new ReactionTaskValues(3)}
                },
                ScenarioAssets = new List<ScenarioAsset>
                {
                    new ScenarioAsset { Id = Guid.NewGuid(), AssetId = target.Id, Transform = new Transform(new Vector3f(-4,0,0), new Vector3f(0,0,0), new Vector3f(1,1,1))},
                    new ScenarioAsset { Id = Guid.NewGuid(), AssetId = finalTarget.Id, Transform = new Transform(new Vector3f(4,3,0), new Vector3f(0,0,0), new Vector3f(1,1,1))},
                    new ScenarioAsset { Id = Guid.NewGuid(), AssetId = tunnel.Id, Transform = new Transform(new Vector3f(0,0,0), new Vector3f(0,0,0), new Vector3f(1,1,1))},
                    new ScenarioAsset { Id = Guid.NewGuid(), AssetId = device.Id, Transform = new Transform(new Vector3f(-4,-4,0), new Vector3f(0,0,0), new Vector3f(1,1,1))}
                }

            };

            actorManager.CreateActor(actor);
            assetManager.CreateAsset(device);
            assetManager.CreateAsset(target);
            assetManager.CreateAsset(tunnel);
            assetManager.CreateAsset(finalTarget);
            schemaManager.CreateSchema(schema);
            scenarioManager.CreateScenario(scenario);*/
        }


    }
}
