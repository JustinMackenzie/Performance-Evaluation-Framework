using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScenarioSim.Core
{
    interface IResultWriter
    {
        void Write(Dictionary<string,float> results, string filename);
    }
}
