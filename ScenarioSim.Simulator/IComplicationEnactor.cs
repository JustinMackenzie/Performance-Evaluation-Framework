﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScenarioSim.Core
{
    public interface IComplicationEnactor
    {
        int ComplicationId { get; set; }
        void Execute();
        void CleanUp();
    }
}
