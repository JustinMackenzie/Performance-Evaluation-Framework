﻿using System.Collections.Generic;
using ScenarioSim.Core;
using UmlStateChart;

namespace ScenarioSim.UmlStateChart
{
    class UmlStateChartEngine : IStateChartEngine
    {
        StateChart stateChart;
        StateDataContainer dataContainer;

        public bool IsActive { get { return !IsStateActive("Evaluate"); } }

        public UmlStateChartEngine(StateChart stateChart)
        {
            this.stateChart = stateChart;
        }

        public bool IsStateActive(string name)
        {
            State state = stateChart.States[name];

            return dataContainer.ActiveStates().Contains(state);
        }

        public void Dispatch(IStateChartEvent e)
        {
            stateChart.Dispatch(dataContainer, TransformToStateChartEvent(e));
        }

        public List<string> ActiveStates()
        {
            List<string> result = new List<string>();

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