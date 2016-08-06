using System;
using System.Collections.Generic;
using ScenarioSim.Core.Entities;
using ScenarioSim.Services.ScenarioCreator;

namespace ScenarioSim.ScenarioCreatorConsole
{
    public class FittsMultiPhaseProgramGenerator
    {
        /// <summary>
        /// The manager
        /// </summary>
        private readonly IScenarioManager manager;

        /// <summary>
        /// The program manager
        /// </summary>
        private readonly IProgramManager programManager;

        /// <summary>
        /// The generator
        /// </summary>
        private readonly FittsScenarioGenerator generator;

        /// <summary>
        /// Initializes a new instance of the <see cref="FittsMultiPhaseProgramGenerator"/> class.
        /// </summary>
        /// <param name="manager">The manager.</param>
        /// <param name="programManager">The program manager.</param>
        public FittsMultiPhaseProgramGenerator(IScenarioManager manager, IProgramManager programManager)
        {
            this.manager = manager;
            this.programManager = programManager;
            FittsSettings settings = new FittsSettings
            {
                DefaultTunnelLength = 8,
                DefaultTunnelWidth = 2,
                DeviceAssetId = Guid.Parse("ed2a89be-9a37-4a2f-9193-466a78bf9186"),
                Target2AssetId = Guid.Parse("11b626b7-58ab-4cd5-a561-38116117c56b"),
                TunnelAssetId = Guid.Parse("454d9789-baa2-4f02-a4d0-846aa62d4844"),
                Target1AssetId = Guid.Parse("35c31ab4-52fe-4017-a10e-f2199864c2ec"),
                DevicePositionMean = new Vector3f(0, 0, 0),
                DevicePositionVariance = new Vector3f(10.5f, 4, 0),
                DeviceScaleMean = 1,
                DeviceScaleVariance = 1,
                Target1PositionMean = new Vector3f(0, 0, 0),
                Target1PositionVariance = new Vector3f(10.5f, 4f, 0),
                Target1ScaleMean = 1,
                Target1ScaleVariance = 2,
                Target2PositionMean = new Vector3f(0, 0, 0),
                Target2PositionVariance = new Vector3f(10.5f, 4f, 0),
                Target2ScaleMean = 1,
                Target2ScaleVariance = 2,
                TunnelScaleMean = new Vector3f(1, 1, 1),
                TunnelScaleVariance = new Vector3f(1.25f, 1.25f, 1),
                MaxDimensions = new Vector3f(11.5f, 5f, 0),
                MeanReactionDelay = 5,
                VarianceReactionDelay = 3
            };

            generator = new FittsScenarioGenerator(settings);
        }

        public void Generate(Schema schema, string name, int count)
        {
            Core.Entities.Program program = new Core.Entities.Program
            {
                Id = Guid.NewGuid(),
                Description = "A set of Fitts multi-phase task scenarios.",
                Name = name,
                ScenarioIds = new List<Guid>()
            };

            for (int i = 0; i < count; i++)
            {
                Console.WriteLine($"Generating scenario {i + 1}.");
                Scenario scenario = generator.GenerateScenario(schema, $"Fitts Multiphase Task {i + 1}");
                manager.CreateScenario(scenario);
                program.ScenarioIds.Add(scenario.Id);
            }

            programManager.CreateProgram(program);
        }
    }
}