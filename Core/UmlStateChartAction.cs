﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UmlStateChart;

namespace ScenarioSim.Core
{
    abstract class UmlStateChartAction : IAction
    {
        public UmlStateChartAction NextAction { get; set; }

        public void Execute(StateDataContainer container)
        {
            ExecuteAction(container);
            if (NextAction != null)
                NextAction.Execute(container);
        }

        public void AddAction(UmlStateChartAction action)
        {
            if (NextAction != null)
            {
                if (NextAction is UmlStateChartAction)
                {
                    (NextAction as UmlStateChartAction).AddAction(action);
                }
            }
            else
                NextAction = action;
        }


        protected abstract void ExecuteAction(StateDataContainer container);
    }
}
