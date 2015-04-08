using ScenarioSim.Core.Entities;

namespace ScenarioSim.Services.Playback
{
    public interface IEventEnactor
    {
        int EventId { get; set; }
        void Enact(ScenarioEvent e);
    }
}
