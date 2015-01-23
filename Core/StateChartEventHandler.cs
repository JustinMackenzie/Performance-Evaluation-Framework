using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScenarioSim.Core
{
    class StateChartEventHandler
    {
        List<IStateChartEvent> events;
        IStateChart stateChart;

        public StateChartEventHandler(IStateChart stateChart)
        {
            events = new List<IStateChartEvent>();
            this.stateChart = stateChart;
        }

        public void SubmitEvent(IStateChartEvent e)
        {
            AppendEvent(e);
            stateChart.Dispatch(e);
        }

        private void AppendEvent(IStateChartEvent e)
        {
            events.Add(e);
        }

        public void Write(string filename)
        {
            using (StreamWriter writer = new StreamWriter(filename))
            {
                foreach (IStateChartEvent e in events)
                {
                    string text = string.Format("[{0}] State Chart Event: {1} : {2} recieved.",
                        e.Timestamp.ToString(), e.Id, e.Name);
                    writer.WriteLine(text);
                }
            }
        }
    }
}
