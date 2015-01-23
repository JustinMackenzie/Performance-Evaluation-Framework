using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScenarioSim.UmlStateChart;
using ScenarioSim.Utility;

namespace ScenarioSim.Core
{
    class Scenario
    {
        IStateChart stateChart;
        StateChartBuilder builder;
        TaskTreeNode task;

        public Scenario(TaskTreeNode task)
        {
            this.task = task;
            builder = new StateChartBuilder();
        }

        public void Start()
        {
            stateChart = new StateChartFacade(builder.Build(task));
            stateChart.Start();
        }
    }
}
