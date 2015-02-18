using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ScenarioSim.Core;

namespace ScenarioSim.Simulator
{
    public interface IStateChartBuilder
    {
        IStateChartEngine Build(Scenario scenario);
    }
}
