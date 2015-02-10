using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ScenarioSim.Core
{
    class CsvSimulatorEventLogger : FileSimulatorEventLogger
    {
        public CsvSimulatorEventLogger(string filename) : base(filename) { }

        protected override string GetLogEntry(ScenarioEvent e)
        {
            StringBuilder builder = new StringBuilder();
            foreach (EventParameter p in e.Parameters)
                builder.Append(string.Format("{0}:{1};", p.Name, p.Value));

            return string.Format("{0},{1},{2},{3}",
                e.Timestamp.ToString(), e.Name, e.Description, builder.ToString());
        }
    }
}
