using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ScenarioSim.Simulator;

namespace ScenarioSim.Core
{
    public class ParameterKeeper
    {
        List<TrackedEventParameter> parameters;

        public List<TrackedEventParameter> Parameters { get { return parameters; } }

        public ParameterKeeper()
        {
            parameters = new List<TrackedEventParameter>();
        }

        public void AddParameter(EventParameter parameter, DateTime time)
        {
            parameters.Add(new TrackedEventParameter() { Parameter = parameter, Timestamp = time });
        }

        public override string ToString()
        {
            string text = "Parameters:";

            foreach (TrackedEventParameter p in parameters)
                text += string.Format("[{0}] {1}:{2}, ", p.Timestamp, p.Parameter.Name, p.Parameter.Value);

            return text;
        }
    }
}
