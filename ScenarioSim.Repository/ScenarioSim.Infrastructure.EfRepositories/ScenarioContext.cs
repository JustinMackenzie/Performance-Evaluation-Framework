using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace ScenarioSim.Infrastructure.EfRepositories
{
    /// <summary>
    /// Represents a database context specific to the scenario domain.
    /// </summary>
    /// <seealso cref="System.Data.Entity.DbContext" />
    public class ScenarioContext : DbContext, IDbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ScenarioContext"/> class.
        /// </summary>
        public ScenarioContext() : base("ScenarioContext")
        {
            
        }

        /// <summary>
        /// Get DbSet
        /// </summary>
        /// <typeparam name="TEntity">Entity type</typeparam>
        /// <returns>DbSet</returns>
        public new IDbSet<TEntity> Set<TEntity>() where TEntity : EfEntity
        {
            return base.Set<TEntity>();
        }

        /// <summary>
        /// Gets a object for the given entity providing access to
        /// information about the entity and the ability to perform actions on the entity.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="entity">The entity.</param>
        /// <returns>
        /// An entry for the entity.
        /// </returns>
        public new DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : EfEntity
        {
            return base.Entry(entity);
        }
    }
}
