using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScenarioSim.Core
{
    class TextStateChartEventLogger : IStateChartEventLogger
    {
        string filename;
        public TextStateChartEventLogger(string filename)
        {
            this.filename = filename;
        }

        public void Log(IStateChartEvent e)
        {
            using(StreamWriter writer = File.AppendText(filename))
            {
                string text = string.Format("[{0}] State Chart Event: {1} : {2} recieved.",
                        e.Timestamp.ToString(), e.Id, e.Name);
                writer.WriteLine(text);
            }   
        }
    }
}
