using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScenarioSim.Core
{
    public struct ActualValueLocation
    {
        public int EventId;
        public string ParameterName;

        public ActualValueLocation(int eventId, string paramName)
        {
            EventId = eventId;
            ParameterName = paramName;
        }
    }
}
