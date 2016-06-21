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
        protected ScenarioContext Context { get; set; }

        protected abstract DbSet<T> DbSet { get; }

        protected EfEntityRepository(ScenarioContext context)
        {
            Context = context;
        }

        public IEnumerable<T> GetAll()
        {
            return DbSet;
        }

        public T Get(Guid id)
        {
            return DbSet.Find(id);
        }

        public void Save(T entity)
        {
            DbEntityEntry entry = Context.Entry(entity);

            if (entry == null)
                DbSet.Add(entity);
            else
                entry.State = EntityState.Modified;
        }

        public void Remove(T entity)
        {
            DbSet.Remove(entity);
        }
    }
}
