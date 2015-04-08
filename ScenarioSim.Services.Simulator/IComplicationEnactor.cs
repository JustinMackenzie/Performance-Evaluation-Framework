namespace ScenarioSim.Services.Simulator
{
    public interface IComplicationEnactor
    {
        int ComplicationId { get; set; }
        void Enact();
        void CleanUp();
    }
}
