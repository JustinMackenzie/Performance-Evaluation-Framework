using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ScenarioSim.Core
{
    class SimulatorEventHandler : ISimulatorEventHandler
    {
        List<SimulatorEvent> events;
        StateChartEventHandler stateChartEventReciever;

        public SimulatorEventHandler(StateChartEventHandler stateChartEventReciever)
        {
            events = new List<SimulatorEvent>();
            this.stateChartEventReciever = stateChartEventReciever;
        }


        public void SubmitEvent(SimulatorEvent e)
        {
            AppendEvent(e);
            IStateChartEvent stateChartEvent = Transform(e);
            stateChartEventReciever.SubmitEvent(stateChartEvent);
        }

        private void AppendEvent(SimulatorEvent e)
        {
            events.Add(e);
        }

        private IStateChartEvent Transform(SimulatorEvent e)
        {
            IStateChartEvent result = new UmlStateChartEvent();
            result.Id = e.Id;
            result.Name = e.Name;
            result.Timestamp = e.Timestamp;

            return result;
        }

        public void WriteToLog(string filename)
        {
            using(StreamWriter writer = new StreamWriter(filename))
            {
                foreach(SimulatorEvent e in events)
                {
                    StringBuilder builder = new StringBuilder();
                    builder.Append(string.Format("[{0}] {1} : {2}. Parameters: ",
                        e.Timestamp.ToString(), e.Name, e.Description));
                    foreach (KeyValuePair<string, object> p in e.Parameters)
                        builder.Append(string.Format("{0} : {1}, ", p.Key, p.Value));
                    writer.WriteLine(builder.ToString());
                }
            }
        }
    }
}
