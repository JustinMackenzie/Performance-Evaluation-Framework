using ScenarioSim.Core.Entities;
using ScenarioSim.Services.Playback;

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
