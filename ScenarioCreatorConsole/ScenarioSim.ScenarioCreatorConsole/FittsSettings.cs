using System;
using ScenarioSim.Core.Entities;

namespace ScenarioSim.ScenarioCreatorConsole
{
    public class FittsSettings
    {
        public Transform DeviceMeanTransform { get; set; }
        public Transform DeviceRangeTransform { get; set; }
        public Transform Target1MeanTransform { get; set; }
        public Transform Target1RangeTransform { get; set; }
        public Transform Target2MeanTransform { get; set; }
        public Transform Target2RangeTransform { get; set; }

        public Transform TunnelMeanTransform { get; set; }
        public Transform TunnelRangeTransform { get; set; }

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