﻿using System.Collections.Generic;
using System.Linq;
using ScenarioSim.Core.Entities;
using ScenarioSim.Services.Simulator;

namespace ScenarioSim.Infrastructure.SimulationComponents
{
    public class ParameterTrackingComponent : ISimulationComponent
    {
        private List<TrackedEventParameter> trackedEventParameters;
        private List<EventParameterPair> trackedParametersRegistry;

        public void SubmitEvent(ScenarioEvent e)
        {
            foreach (EventParameter p in e.Parameters)
                if (IsTracked(p, e.Id))
                    trackedEventParameters.Add(new TrackedEventParameter
                    {
                        Parameter = p,
                        Timestamp = e.Timestamp
                    });
        }
        public void AddTrackedParameter(EventParameterPair pair)
        {
            trackedParametersRegistry.Add(pair);
        }

        private bool IsTracked(EventParameter parameter, int eventId)
        {
            return (from EventParameterPair p in trackedParametersRegistry
                    where p.ParameterName == parameter.Name && p.EventId == eventId
                    select p).Any();
        }

        public void Start()
        {
            trackedEventParameters = new List<TrackedEventParameter>();
            trackedParametersRegistry = new List<EventParameterPair>();
        }


        public void Complete()
        {

        }
    }

    public struct EventParameterPair
    {
        public int EventId { get; set; }
        public string ParameterName { get; set; }
    }
}
