using System.Data.Entity;
using ScenarioSim.Core.Entities;

namespace ScenarioSim.Infrastructure.EfRepositories
{
    /// <summary>
    /// Represents a database context specific to the scenario domain.
    /// </summary>
    /// <seealso cref="System.Data.Entity.DbContext" />
    public class ScenarioContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ScenarioContext"/> class.
        /// </summary>
        public ScenarioContext() : base("ScenarioContext")
        {
            
        }

        /// <summary>
        /// Gets or sets the schemas.
        /// </summary>
        /// <value>
        /// The schemas.
        /// </value>
        public DbSet<Schema> Schemas { get; set; }
    }
}
