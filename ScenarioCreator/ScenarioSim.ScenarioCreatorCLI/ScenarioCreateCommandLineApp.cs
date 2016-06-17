using System;
using System.Collections.Generic;
using ScenarioSim.Core.Entities;
using ScenarioSim.Infrastructure.JsonNetSerializer;
using ScenarioSim.Services.Serialization;
using Task = ScenarioSim.Core.Entities.Task;

namespace ScenarioSim.ScenarioCreatorCLI
{
    class ScenarioCreateCommandLineApp
    {
        static void Main(string[] args)
        {
            string filePath = "C:\\Users\\jmack\\Desktop\\program.json";

            Actor actor = new Actor { Name = "User" };

            Task reactionTask = new Task { Id = Guid.NewGuid(), Actor = actor, Name = "Red Light" };

            Task firstTask = new Task { Id = Guid.NewGuid(), Actor = actor, Name = "Move To Target 1" };
            Task secondTask = new Task { Id = Guid.NewGuid(), Actor = actor, Name = "Steer through Tunnel" };
            Task thirdTask = new Task { Id = Guid.NewGuid(), Actor = actor, Name = "Move To Target 3" };

            CompositeTask compositeTask = new CompositeTask
            {
                Id = Guid.NewGuid(),
                Name = "Fitts Combined Task",
                Actor = actor,
                SubTasks = new List<Task> { firstTask, secondTask, thirdTask }
            };

            ParallelTask rootTask = new ParallelTask
            {
                Id = Guid.NewGuid(),
                Name = "Root Task",
                Actor = actor,
                Tasks = new List<Task> { compositeTask, reactionTask }
            };

            Schema schema = new Schema
            {
                Id = Guid.NewGuid(),
                Name = "Test Schema",
                Task = rootTask,
                Actors = new List<Actor> { actor }
            };

            Scenario scenario1 = new Scenario
            {
                Id = Guid.NewGuid(),
                Schema = schema,
                ScenarioSpecificTasks = new Dictionary<Guid, TaskValues>
                {
                    { firstTask.Id, new FittsTaskValues { D = 10, W = 2, } },
                    { secondTask.Id, new SteeringTaskValues { A = 25, W = 4 } },
                    { thirdTask.Id, new FittsTaskValues { D = 35, W = 2 } },
                    { reactionTask.Id, new ReactionTaskValues { Delay = 10 } }
                },
                Name = "Test Scenario 1"
            };

            Scenario scenario2 = new Scenario
            {
                Id = Guid.NewGuid(),
                Schema = schema,
                ScenarioSpecificTasks = new Dictionary<Guid, TaskValues>
                {
                    { firstTask.Id, new FittsTaskValues { D = 15, W = 4, } },
                    { secondTask.Id, new SteeringTaskValues { A = 20, W = 3 } },
                    { thirdTask.Id, new FittsTaskValues { D = 30, W = 2 } },
                    { reactionTask.Id, new ReactionTaskValues { Delay = 9 } }
                },
                Name = "Test Scenario 2"
            };

            Scenario scenario3 = new Scenario
            {
                Id = Guid.NewGuid(),
                Schema = schema,
                ScenarioSpecificTasks = new Dictionary<Guid, TaskValues>
                {
                    { firstTask.Id, new FittsTaskValues { D = 17, W = 1, } },
                    { secondTask.Id, new SteeringTaskValues { A = 80, W = 5 } },
                    { thirdTask.Id, new FittsTaskValues { D = 80, W = 3 } },
                    { reactionTask.Id, new ReactionTaskValues { Delay = 7 } }
                },
                Name = "Test Scenario 3"
            };

            Program program = new Program
            {
                Id = Guid.NewGuid(),
                Scenarios = new List<Scenario>
                {
                    scenario1,
                    scenario2,
                    scenario3
                }
            };

            IFileSerializer serializer = new JsonNetFileSerializer();

            serializer.Serialize(filePath, program);

            Program result = serializer.Deserialize<Program>(filePath);

            Console.ReadLine();
        }
    }
}
