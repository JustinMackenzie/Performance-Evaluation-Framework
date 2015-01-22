using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScenarioSim.Core;
using UmlStateChart;

namespace ScenarioSim.UmlStateChart
{
    class StateChartFacade : IStateChart
    {
        StateChart stateChart;
        StateDataContainer dataContainer;

        public StateChartFacade(StateChart stateChart)
        {
            this.stateChart = stateChart;
        }

        public bool IsStateActive(string name)
        {
            State state = stateChart.States[name];

            return state.Activate(dataContainer);
        }

        public void Dispatch(IStateChartEvent e)
        {
            stateChart.Dispatch(dataContainer, TransformToStateChartEvent(e));
        }

        public IList<string> ActiveStates()
        {
            IList<string> result = new List<string>();

            foreach (State s in dataContainer.ActiveStates())
            {
                result.Add(s.Name);
            }

            return result;
        }

        public void Start()
        {
            dataContainer = new StateDataContainer();

            stateChart.Start(dataContainer);
        }

        private StateChartEvent TransformToStateChartEvent(IStateChartEvent e)
        {
            return new StateChartEvent(e.Id);
        }
    }
}
