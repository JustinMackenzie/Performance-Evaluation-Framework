using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScenarioSim.Core
{
    class TrackedEventParameters
    {
        public List<EventParameterPair> Items { get; set; }

        public TrackedEventParameters()
        {
            Items = new List<EventParameterPair>();
        }
    }

    struct EventParameterPair
    {
        public int EventId { get; set; }
        public string ParameterName { get; set; }
    }
}
