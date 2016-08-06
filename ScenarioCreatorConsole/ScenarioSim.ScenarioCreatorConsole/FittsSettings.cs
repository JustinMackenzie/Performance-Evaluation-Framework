using System;
using ScenarioSim.Core.Entities;

namespace ScenarioSim.ScenarioCreatorConsole
{
    public class FittsSettings
    {
        public Vector3f DevicePositionMean { get; set; }
        public Vector3f DevicePositionVariance { get; set; }
        public float DeviceScaleMean { get; set; }
        public float DeviceScaleVariance { get; set; }

        public Vector3f Target1PositionMean { get; set; }
        public Vector3f Target1PositionVariance { get; set; }
        public float Target1ScaleMean { get; set; }
        public float Target1ScaleVariance { get; set; }

        public Vector3f Target2PositionMean { get; set; }
        public Vector3f Target2PositionVariance { get; set; }
        public float Target2ScaleMean { get; set; }
        public float Target2ScaleVariance { get; set; }

        public Vector3f TunnelScaleMean { get; set; }
        public Vector3f TunnelScaleVariance { get; set; }
        public float DefaultTunnelLength { get; set; }
        public float DefaultTunnelWidth { get; set; }

        public Guid DeviceAssetId { get; set; }
        public Guid Target1AssetId { get; set; }
        public Guid Target2AssetId { get; set; }
        public Guid TunnelAssetId { get; set; }
        public Vector3f MaxDimensions { get; set; }

        public float MeanReactionDelay { get; set; }
        public float VarianceReactionDelay { get; set; }
    }
}