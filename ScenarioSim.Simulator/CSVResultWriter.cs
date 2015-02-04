using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ScenarioSim.Core
{
    class CSVResultWriter : IResultWriter
    {
        public void Write(Dictionary<string,float> results, string filename)
        {
            using(StreamWriter writer = new StreamWriter(filename + ".csv"))
            {
                foreach (KeyValuePair<string, float> p in results)
                    writer.WriteLine(p.Key + "," + p.Value);
            }
        }
    }
}
