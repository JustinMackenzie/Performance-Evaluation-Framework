using ScenarioSim.Core.Entities;
using ScenarioSim.Services.Playback;

namespace ScenarioSim.Infrastructure.Playback.Tests
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
