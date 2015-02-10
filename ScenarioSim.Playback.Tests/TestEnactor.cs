using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScenarioSim.Playback;
using ScenarioSim.Core;

namespace ScenarioSim.Playback.Tests
{
    class TestPauseEnactor : IEventEnactor
    {
        IScenarioPlayback playback;

        public TestPauseEnactor(IScenarioPlayback playback)
        {
            this.playback = playback;
        }

        public int EventId
        {
            get;
            set;
        }

        public void Enact(ScenarioEvent e)
        {
            playback.Pause();
        }
    }
}
