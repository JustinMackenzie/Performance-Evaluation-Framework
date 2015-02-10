using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScenarioSim.Playback;
using ScenarioSim.Core;

namespace ScenarioSim.Playback.Tests
{
    class TestCountEnactor : IEventEnactor
    {
        public int Count { get; set; }

        public TestCountEnactor()
        {
            Count = 0;
        }

        public int EventId
        {
            get;
            set;
        }

        public void Enact(ScenarioEvent e)
        {
            Count++;
        }
    }
}
