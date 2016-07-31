using System;
using System.Collections.Generic;
using System.Configuration;
using ScenarioSim.Core.Entities;

namespace ScenarioSim.ScenarioCreatorConsole
{
    class FittsScenarioGenerator
    {
        private readonly FittsSettings settings;

        public FittsScenarioGenerator(FittsSettings settings)
        {
            if (settings == null)
                throw new ArgumentNullException(nameof(settings));

            this.settings = settings;
        }

        public Scenario GenerateScenario(Schema schema, string name)
        {
            Scenario scenario = new Scenario
            {
                Id = Guid.NewGuid(),
                Name = name,
                SchemaId = schema.Id,
                Description = "A simple scenario of the fitts' multiphase task schema."
            };

            GenerateScenarioAssetDefinitions(scenario, schema);

            return scenario;
        }

        private void GenerateScenarioAssetDefinitions(Scenario scenario, Schema schema)
        {
            scenario.ScenarioAssets = new List<ScenarioAsset>();
            scenario.ScenarioTaskDefinitions = new List<ScenarioTaskDefinition>();

            ScenarioAsset deviceAsset = new ScenarioAsset
            {
                AssetId = settings.DeviceAssetId,
                Transform = GetTransform(settings.DeviceMeanTransform, settings.DeviceRangeTransform, new Vector3f(1, 1, 0))
            };

            ScenarioAsset target1Asset = new ScenarioAsset
            {
                AssetId = settings.Target1AssetId,
                Transform = GetTransform(settings.Target1MeanTransform, settings.Target1RangeTransform, new Vector3f(1, 1, 0))
            };

            ScenarioAsset tunnelAsset = new ScenarioAsset
            {
                AssetId = settings.TunnelAssetId,
                Transform = GetTunnelTransform(settings.TunnelMeanTransform, settings.TunnelRangeTransform, target1Asset.Transform, new Vector3f(settings.DefaultTunnelLength, settings.DefaultTunnelWidth, 1))
            };

            ScenarioAsset target2Asset = new ScenarioAsset
            {
                AssetId = settings.Target2AssetId,
                Transform = GetTransform(settings.Target2MeanTransform, settings.Target2RangeTransform, new Vector3f(1, 1, 0))
            };

            ScenarioTaskDefinition target1TaskDefinition = new ScenarioTaskDefinition
            {
                TaskValues = new FittsTaskValues((target1Asset.Transform.Position - deviceAsset.Transform.Position).Magnitude, target1Asset.Transform.Scale.X),
                TaskId = ((schema.Task as ParallelTask).Tasks[0] as CompositeTask).Tasks[0].Id
            };

            ScenarioTaskDefinition tunnelTaskDefinition = new ScenarioTaskDefinition
            {
                TaskId = ((schema.Task as ParallelTask).Tasks[0] as CompositeTask).Tasks[1].Id,
                TaskValues =
                    new SteeringTaskValues(settings.DefaultTunnelLength * tunnelAsset.Transform.Scale.X,
                        settings.DefaultTunnelWidth * tunnelAsset.Transform.Scale.Y)
            };

            ScenarioTaskDefinition target2TaskDefinition = new ScenarioTaskDefinition
            {
                TaskId = ((schema.Task as ParallelTask).Tasks[0] as CompositeTask).Tasks[2].Id,
                TaskValues = new DynamicFittsTaskValues
                {
                    EventName = "TUNNEL_GOAL",
                    ParameterName = "Device Position",
                    Target = target2Asset.Transform.Position
                }
            };

            ScenarioTaskDefinition reactionTaskDefinition = new ScenarioTaskDefinition
            {
                TaskId = (schema.Task as ParallelTask).Tasks[1].Id,
                TaskValues = new RandomReactionTaskValues
                {
                    MeanDelay = settings.MeanReactionDelay,
                    VarianceDelay = settings.VarianceReactionDelay
                }
            };

            scenario.ScenarioTaskDefinitions.Add(target1TaskDefinition);
            scenario.ScenarioTaskDefinitions.Add(tunnelTaskDefinition);
            scenario.ScenarioTaskDefinitions.Add(target2TaskDefinition);
            scenario.ScenarioTaskDefinitions.Add(reactionTaskDefinition);

            scenario.ScenarioAssets.Add(deviceAsset);
            scenario.ScenarioAssets.Add(target1Asset);
            scenario.ScenarioAssets.Add(tunnelAsset);
            scenario.ScenarioAssets.Add(target2Asset);
        }

        private Transform GetTransform(Transform mean, Transform range, Vector3f defaultSize)
        {
            Random random = new Random();

            Vector3f lowScale = mean.Scale / range.Scale;
            Vector3f highScale = mean.Scale * range.Scale;

            Vector3f scale = new Vector3f((float)random.NextDouble() * (highScale.X - lowScale.X) + lowScale.X,
                (float)random.NextDouble() * (highScale.Y - lowScale.Y) + lowScale.Y,
                (float)random.NextDouble() * (highScale.Z - lowScale.Z) + lowScale.Z);

            Vector3f lowPos = mean.Position - range.Position + 0.5f * (defaultSize * scale);
            Vector3f highPos = mean.Position + range.Position - 0.5f * (defaultSize * scale);
            Vector3f diffPos = highPos - lowPos;

            Vector3f position = new Vector3f((float)random.NextDouble() * diffPos.X + lowPos.X,
                (float)random.NextDouble() * diffPos.Y + lowPos.Y,
                0);

            return new Transform(
                position,
                GetVector(mean.Rotation, range.Rotation, random),
                scale);
        }

        private Transform GetTunnelTransform(Transform meanTransform, Transform rangeTransform, Transform target1Transform,
            Vector3f defaultTunnelSize)
        {
            Random random = new Random();

            Vector3f lowScale = meanTransform.Scale / rangeTransform.Scale;
            Vector3f highScale = meanTransform.Scale * rangeTransform.Scale;

            Vector3f scale = new Vector3f((float)random.NextDouble() * (highScale.X - lowScale.X) + lowScale.X,
                (float)random.NextDouble() * (highScale.Y - lowScale.Y) + lowScale.Y,
                (float)random.NextDouble() * (highScale.Z - lowScale.Z) + lowScale.Z);

            Vector3f size = scale * defaultTunnelSize;

            Vector3f target1Pos = target1Transform.Position;
            float degreesToRotate = 0;
            Vector3f position = new Vector3f(0, 0, 0);

            while (true)
            {
                degreesToRotate = 360 * (float)random.NextDouble();
                float radians = degreesToRotate * (float)Math.PI / 180;

                Vector3f startPosition = new Vector3f(
                    target1Transform.Position.X + scale.X * defaultTunnelSize.X * 0.5f + 1,
                    target1Transform.Position.Y,
                    0);

                Vector3f topLeftCorner = startPosition - new Vector3f(scale.X * defaultTunnelSize.X * 0.5f + 1, scale.Y * defaultTunnelSize.Y * 0.5f, 0);
                Vector3f topRightCorner = startPosition - new Vector3f(scale.X * defaultTunnelSize.X * -0.5f - 1, scale.Y * defaultTunnelSize.Y * 0.5f, 0);
                Vector3f bottomLeftCorner = startPosition - new Vector3f(scale.X * defaultTunnelSize.X * 0.5f + 1, scale.Y * defaultTunnelSize.Y * -0.5f, 0);
                Vector3f bottomRightCorner = startPosition - new Vector3f(scale.X * defaultTunnelSize.X * -0.5f - 1, scale.Y * defaultTunnelSize.Y * -0.5f, 0);

                position = RotatePointAroundPoint(startPosition, target1Pos, radians);

                if (IsObjectOutInBounds(settings.MaxDimensions, RotatePointAroundPoint(topLeftCorner, target1Pos, radians))
                     && IsObjectOutInBounds(settings.MaxDimensions, RotatePointAroundPoint(topRightCorner, target1Pos, radians))
                     && IsObjectOutInBounds(settings.MaxDimensions, RotatePointAroundPoint(bottomLeftCorner, target1Pos, radians))
                     && IsObjectOutInBounds(settings.MaxDimensions, RotatePointAroundPoint(bottomRightCorner, target1Pos, radians)))
                    break;
            }

            // 90 degrees in target 1 space to tunnel is 0 degrees in tunnel space.
            return new Transform(position, new Vector3f(0, 0, degreesToRotate), scale);
        }

        private bool IsObjectOutInBounds(Vector3f maxDimensions, Vector3f rotatePointAroundPoint)
        {
            if (Math.Abs(rotatePointAroundPoint.X) > Math.Abs(maxDimensions.X))
                return false;
            if (Math.Abs(rotatePointAroundPoint.Y) > Math.Abs(maxDimensions.Y))
                return false;

            return true;
        }

        private Vector3f RotatePointAroundPoint(Vector3f startPoint, Vector3f rotationPoint, float radians)
        {
            double cosTheta = Math.Cos(radians);
            double sinTheta = Math.Sin(radians);

            return new Vector3f(
                (float)
                    (cosTheta * (startPoint.X - rotationPoint.X) - sinTheta * (startPoint.Y - rotationPoint.Y) +
                     rotationPoint.X),
                (float)
                    (sinTheta * (startPoint.X - rotationPoint.X) + cosTheta * (startPoint.Y - rotationPoint.Y) +
                     rotationPoint.Y),
                0);
        }

        private Vector3f GetVector(Vector3f mean, Vector3f range, Random random)
        {
            return new Vector3f(
                mean.X + 2.0f * range.X * (float)random.NextDouble() - range.X,
                mean.Y + 2.0f * range.Y * (float)random.NextDouble() - range.Y,
                0);
        }
    }
}
