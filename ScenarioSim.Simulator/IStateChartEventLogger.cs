﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScenarioSim.Core
{
    interface IStateChartEventLogger
    {
        void Log(IStateChartEvent e);
    }
}