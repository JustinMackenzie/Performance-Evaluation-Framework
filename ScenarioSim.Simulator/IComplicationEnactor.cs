namespace ScenarioSim.Core
{
    public interface IComplicationEnactor
    {
        int ComplicationId { get; set; }
        void Enact();
        void CleanUp();
    }
}
