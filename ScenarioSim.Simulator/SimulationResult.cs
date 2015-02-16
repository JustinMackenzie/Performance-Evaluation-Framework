﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ScenarioSim.Core;

namespace ScenarioSim.Simulator
{
    public class SimulationResult
    {
        public User User { get; set; }
        public string ScenarioFile { get; set; }
        public TreeNode<TaskResult> TaskResult { get; set; }
        public ScenarioEventCollection Events { get; set; }
    }
}
