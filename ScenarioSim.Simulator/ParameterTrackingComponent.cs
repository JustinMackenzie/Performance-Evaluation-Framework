using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ScenarioSim.Core; 

namespace ScenarioSim.Simulator
{
    class ParameterTrackingComponent : ISimulationComponent
    {
        ParameterKeeper parameterKeeper;
        TrackedEventParameters trackedParameters;

        public ParameterTrackingComponent()
        {
            parameterKeeper = new ParameterKeeper();
            trackedParameters = new TrackedEventParameters();
        }

        public void SubmitEvent(ScenarioEvent e)
        {
            foreach (EventParameter p in e.Parameters)
                if (IsTracked(p, e.Id))
                    parameterKeeper.AddParameter(p, e.Timestamp);
        }
        public void AddTrackedParameter(EventParameterPair pair)
        {
            trackedParameters.Items.Add(pair);
        }

        private bool IsTracked(EventParameter parameter, int eventId)
        {
            return (from EventParameterPair p in trackedParameters.Items
                    where p.ParameterName == parameter.Name && p.EventId == eventId
                    select p).Count<EventParameterPair>() > 0;
        }

        public void Start()
        {
            
        }
    }
}
