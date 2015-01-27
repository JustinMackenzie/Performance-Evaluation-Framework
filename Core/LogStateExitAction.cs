﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UmlStateChart;
using ScenarioSim.Core;

namespace ScenarioSim.UmlStateChart
{
    class LogStateExitAction : IAction
    {
        string name;
        ILogger logger;

        public LogStateExitAction(string name, ILogger logger)
        {
            this.name = name;
            this.logger = logger;
        }

        public void Execute(StateDataContainer dataContainer)
        {
            DateTime timestamp = DateTime.Now;

            string message = string.Format("[{0}] Now exiting: {1} state.", 
                timestamp.ToString(), name);

            logger.Log(message);
        }
    }
}