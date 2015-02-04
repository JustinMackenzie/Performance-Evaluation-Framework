using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScenarioSim.Core
{
    public interface IStateChartReader
    {
        IStateChartEngine Read(string fileName);
    }
}
