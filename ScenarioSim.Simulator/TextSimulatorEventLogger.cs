using System.Text;

namespace ScenarioSim.Core
{
    class TextSimulatorEventLogger : FileSimulatorEventLogger
    {
        public TextSimulatorEventLogger(string filename) : base(filename) { }

        protected override string GetLogEntry(ScenarioEvent e)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(string.Format("[{0}] Name: {1}; Description: {2}; Parameters: ",
                e.Timestamp.ToString(), e.Name, e.Description));
            foreach (EventParameter p in e.Parameters)
                builder.Append(string.Format("[{0} : {1}], ", p.Name, p.Value));

            return builder.ToString();
        }
    }
}
