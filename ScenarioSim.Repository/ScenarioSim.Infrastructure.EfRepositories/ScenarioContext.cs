using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using ScenarioSim.Core.Entities;

namespace ScenarioSim.Infrastructure.EfRepositories
{
    /// <summary>
    /// Represents a database context specific to the scenario domain.
    /// </summary>
    /// <seealso cref="System.Data.Entity.DbContext" />
    public class ScenarioContext : DbContext, IDbContext
    {
        /// <summary>
        /// Gets or sets the actors.
        /// </summary>
        /// <value>
        /// The actors.
        /// </value>
        public DbSet<Actor> Actors { get; set; }

        /// <summary>
        /// Gets or sets the assets.
        /// </summary>
        /// <value>
        /// The assets.
        /// </value>
        public DbSet<Asset> Assets { get; set; }

        /// <summary>
        /// Gets or sets the performances.
        /// </summary>
        /// <value>
        /// The performances.
        /// </value>
        public DbSet<ScenarioPerformance> Performances { get; set; }

        /// <summary>
        /// Gets or sets the program performance.
        /// </summary>
        /// <value>
        /// The program performance.
        /// </value>
        public DbSet<Program> Programs { get; set; }

        /// <summary>
        /// Gets or sets the scenario performance.
        /// </summary>
        /// <value>
        /// The scenario performance.
        /// </value>
        public DbSet<Scenario> Scenarios{ get; set; }

        /// <summary>
        /// Gets or sets the schemas.
        /// </summary>
        /// <value>
        /// The schemas.
        /// </value>
        public DbSet<Schema> Schemas { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ScenarioContext"/> class.
        /// </summary>
        public ScenarioContext() : base("ScenarioContext")
        {          
        }

        /// <summary>
        /// This method is called when the model for a derived context has been initialized, but
        /// before the model has been locked down and used to initialize the context.  The default
        /// implementation of this method does nothing, but it can be overridden in a derived class
        /// such that the model can be further configured before it is locked down.
        /// </summary>
        /// <param name="modelBuilder">The builder that defines the model for the context being created.</param>
        /// <remarks>
        /// Typically, this method is called only once when the first instance of a derived context
        /// is created.  The model for that context is then cached and is for all further instances of
        /// the context in the app domain.  This caching can be disabled by setting the ModelCaching
        /// property on the given ModelBuidler, but note that this can seriously degrade performance.
        /// More control over caching is provided through use of the DbModelBuilder and DbContextFactory
        /// classes directly.
        /// </remarks>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Event>().Ignore(p => p.Parameters);
            modelBuilder.Entity<FittsTaskValues>().Ignore(p => p.IndexOfDifficulty);
            modelBuilder.Entity<Scenario>()
                .Ignore(p => p.Task)
                .Ignore(p => p.TaskTree)
                .Ignore(p => p.ScenarioSpecificTasks)
                .Ignore(p => p.TaskTransitions);
            modelBuilder.Entity<ScenarioPerformance>()
                .Ignore(p => p.TaskPerformances)
                .Ignore(p => p.TaskPerformanceTree);
            modelBuilder.Entity<Task>().Ignore(p => p.TaskValues);
            modelBuilder.Entity<Schema>().Ignore(p => p.TaskTree);
            modelBuilder.ComplexType<Transform>();
            modelBuilder.ComplexType<Vector3f>();

            base.OnModelCreating(modelBuilder);
        }

        /// <summary>
        /// Get DbSet
        /// </summary>
        /// <typeparam name="TEntity">Entity type</typeparam>
        /// <returns>DbSet</returns>
        public new IDbSet<TEntity> Set<TEntity>() where TEntity : Entity
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
        public new DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : Entity
        {
            return base.Entry(entity);
        }
    }
}
