using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScenarioSim.Core
{
    class ParameterKeeper
    {
        List<KeyValuePair<EventParameter, DateTime>> parameters;

        public List<KeyValuePair<EventParameter, DateTime>> Parameters { get { return parameters; } }

        public ParameterKeeper()
        {
            parameters = new List<KeyValuePair<EventParameter, DateTime>>();
        }

        public void AddParameter(EventParameter parameter, DateTime time)
        {
            parameters.Add(new KeyValuePair<EventParameter, DateTime>(parameter, time));
        }

        public override string ToString()
        {
            string text = "Parameters:";

            foreach (KeyValuePair<EventParameter, DateTime> p in parameters)
            {
                text += string.Format("[{0}] {1}:{2}, ", p.Value, p.Key.Name, p.Key.Value);
            }

            return text;
        }
    }
}
