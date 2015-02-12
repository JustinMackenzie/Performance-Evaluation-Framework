﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ScenarioSim.Core;

namespace ScenarioSim.Simulator
{
    public class SimulationResult
    {
        public TreeNode<TaskResult> TaskResult { get; set; }
        public ScenarioEventCollection Events { get; set; }
    }
}
