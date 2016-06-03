namespace ScenarioSim.Services.Simulator
{
    /// <summary>
    /// The complication enactor is responsible for acting out a complication.
    /// </summary>
    public interface IComplicationEnactor
    {
        /// <summary>
        /// The identifier of the complication that this enactor represents.
        /// </summary>
        int ComplicationId { get; set; }

        /// <summary>
        /// Enacts the complication.
        /// </summary>
        void Enact();

        /// <summary>
        /// Cleans up any left over resources from the acting of the complication.
        /// </summary>
        void CleanUp();
    }
}
