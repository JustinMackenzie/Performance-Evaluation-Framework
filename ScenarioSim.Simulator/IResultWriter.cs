using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScenarioSim.Core
{
    interface IResultWriter
    {
        void Write(Dictionary<string,float> results, string filename);
    }
}
