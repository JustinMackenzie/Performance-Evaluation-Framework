namespace ScenarioSim.Core.Entities
{
    /// <summary>
    /// Represents a phyiscal entity in the scenario.
    /// </summary>
    public class ScenarioObject
    {
        /// <summary>
        /// The Transform of the entity.
        /// </summary>
        public Transform Transform { get; set; }

        /// <summary>
        /// The identification number of the entity.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The name of the entity. 
        /// </summary>
        public string Name { get; set; }
    }
}
