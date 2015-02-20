﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScenarioSim.Core
{
    public class ScenarioEvent
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime Timestamp { get; set; }
        public EventParameterCollection Parameters { get; set; }
    }
}