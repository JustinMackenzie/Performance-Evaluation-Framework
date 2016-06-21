namespace ScenarioSim.Core.Interfaces
{
    /// <summary>
    /// Represents a single transaction to be commited to the repositories.
    /// </summary>
    public interface IUnitOfWork
    {
        /// <summary>
        /// Gets the schema repository.
        /// </summary>
        /// <value>
        /// The schema repository.
        /// </value>
        ISchemaRepository SchemaRepository { get; }

        /// <summary>
        /// Commits the changes permanently to the repositories.
        /// </summary>
        void Commit();
    }
}
