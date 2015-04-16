namespace ScenarioSim.Core.Entities
{
    /// <summary>
    /// Represents the location to find the actual value of a metric.
    /// </summary>
    public struct ActualValueLocation
    {
        /// <summary>
        /// The identifier of the event that contains the parameter with the actual value.
        /// </summary>
        public int EventId;

        /// <summary>
        /// The name of the parameter that contains the actual value.
        /// </summary>
        public string ParameterName;

        /// <summary>
        /// A constructor with the event identifier and parameter name.
        /// </summary>
        /// <param name="eventId">The event identifier.</param>
        /// <param name="paramName">The name of the parameter.</param>
        public ActualValueLocation(int eventId, string paramName)
        {
            EventId = eventId;
            ParameterName = paramName;
        }
    }
}
