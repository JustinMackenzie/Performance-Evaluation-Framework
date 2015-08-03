using ScenarioSim.Core;

namespace ScenarioSim.Playback
{
    public interface IEventEnactor
    {
        int EventId { get; set; }
        void Enact(ScenarioEvent e);
    }
}
