using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ScenarioSim.Core;

namespace ScenarioSim.Playback
{
    public interface IEventEnactor
    {
        int EventId { get; set; }
        void Enact(ScenarioEvent e);
    }
}
