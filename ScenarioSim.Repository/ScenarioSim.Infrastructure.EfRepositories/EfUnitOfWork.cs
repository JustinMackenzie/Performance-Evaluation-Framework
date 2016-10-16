using ScenarioSim.Core.Interfaces;

namespace ScenarioSim.Infrastructure.EfRepositories
{
    /// <summary>
    /// A unit of work implementation that uses entity framework.
    /// </summary>
    /// <seealso cref="ScenarioSim.Core.Interfaces.IUnitOfWork" />
    public class EfUnitOfWork : IUnitOfWork
    {
        /// <summary>
        /// The scenario database context.
        /// </summary>
        private readonly ScenarioContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="EfUnitOfWork"/> class.
        /// </summary>
        public EfUnitOfWork()
        {
            context = new ScenarioContext();
        }

        /// <summary>
        /// Gets the schema repository.
        /// </summary>
        /// <value>
        /// The schema repository.
        /// </value>
        public ISchemaRepository SchemaRepository { get; }

        /// <summary>
        /// Commits the changes permanently to the repositories.
        /// </summary>
        public void Commit()
        {
            context.SaveChanges();
        }
    }
}
