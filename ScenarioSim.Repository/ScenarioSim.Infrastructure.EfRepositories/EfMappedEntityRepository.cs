using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using ScenarioSim.Core.Entities;
using ScenarioSim.Core.Interfaces;
using ScenarioSim.Services.Mapping;

namespace ScenarioSim.Infrastructure.EfRepositories
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <typeparam name="TDataEntity">The type of the data entity.</typeparam>
    /// <seealso cref="ScenarioSim.Core.Interfaces.IEntityRepository{TEntity}" />
    public abstract class EfMappedEntityRepository<TEntity, TDataEntity> : IEntityRepository<TEntity> 
        where TEntity : Entity 
        where TDataEntity : EfEntity
    {
        /// <summary>
        /// Gets or sets the context.
        /// </summary>
        /// <value>
        /// The context.
        /// </value>
        protected ScenarioContext Context { get; set; }

        /// <summary>
        /// Gets or sets the mapper.
        /// </summary>
        /// <value>
        /// The mapper.
        /// </value>
        protected IMapper Mapper { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="EfMappedEntityRepository{TEntity, TDataEntity}"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="mapper">The mapper.</param>
        protected EfMappedEntityRepository(ScenarioContext context, IMapper mapper)
        {
            Context = context;
            Mapper = mapper;
        }

        /// <summary>
        /// Gets all entities.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<TEntity> GetAll()
        {
            return Context.Set<TDataEntity>().Select(Mapper.Map<TDataEntity, TEntity>);
        }

        /// <summary>
        /// Gets the specified entity.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public TEntity Get(Guid id)
        {
            return Mapper.Map<TDataEntity, TEntity>(Context.Set<TDataEntity>().Find(id));
        }

        /// <summary>
        /// Saves the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Save(TEntity entity)
        {
            TDataEntity dataEntity = Mapper.Map<TEntity, TDataEntity>(entity);
            DbEntityEntry<TDataEntity> entry = Context.Entry(dataEntity);

            if (entry == null)
                Context.Set<TDataEntity>().Add(dataEntity);
            else
                entry.State = EntityState.Modified;

            Context.SaveChanges();
        }

        /// <summary>
        /// Removes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Remove(TEntity entity)
        {
            TDataEntity dataEntity = Mapper.Map<TEntity, TDataEntity>(entity);
            Context.Set<TDataEntity>().Remove(dataEntity);
            Context.SaveChanges();
        }
    }
}
