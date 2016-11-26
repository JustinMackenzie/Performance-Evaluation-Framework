using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using ScenarioSim.Core.Entities;
using ScenarioSim.Core.Interfaces;

namespace ScenarioSim.Infrastructure.EfRepositories
{
    public abstract class EfEntityRepository<T> : IEntityRepository<T> where T : Entity
    {
        /// <summary>
        /// Gets or sets the context.
        /// </summary>
        /// <value>
        /// The context.
        /// </value>
        protected IDbContext Context { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="EfEntityRepository{T}"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        protected EfEntityRepository(IDbContext context)
        {
            Context = context;
        }

        public IEnumerable<T> GetAll()
        {
            return Context.Set<T>();
        }

        public T Get(Guid id)
        {
            return Context.Set<T>().Find(id);
        }

        public void Save(T entity)
        {
            DbEntityEntry<T> entry = Context.Entry(entity);

            if (entry == null)
                Context.Set<T>().Add(entity);
            else
                entry.State = EntityState.Modified;
            Context.SaveChanges();
        }

        public void Remove(T entity)
        {
            Context.Set<T>().Remove(entity);
            Context.SaveChanges();
        }
    }
}
