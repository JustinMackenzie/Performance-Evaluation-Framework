using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ScenarioSim.Core
{
    abstract class FileSimulatorEventLogger : ISimulatorEventLogger
    {
        string filename;

        public FileSimulatorEventLogger(string filename)
        {
            this.filename = filename;
        }

        public void Log(ScenarioEvent e)
        {
            using (StreamWriter writer = File.AppendText(filename))
                writer.WriteLine(GetLogEntry(e));
        }

        protected abstract string GetLogEntry(ScenarioEvent e);
    }
}
