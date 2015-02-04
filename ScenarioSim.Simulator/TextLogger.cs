using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ScenarioSim.Core
{
    class TextLogger : ILogger
    {
        string filename;

        public TextLogger(string filename)
        {
            this.filename = filename;
        }

        public void Log(string message)
        {
            using (StreamWriter writer = File.AppendText(filename))
                writer.WriteLine(message);
        }
    }
}
