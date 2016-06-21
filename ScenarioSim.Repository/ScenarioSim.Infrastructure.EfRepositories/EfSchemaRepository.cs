using System.Data.Entity;
using ScenarioSim.Core.Entities;
using ScenarioSim.Core.Interfaces;

namespace ScenarioSim.Infrastructure.EfRepositories
{
    public class EfSchemaRepository : EfEntityRepository<Schema>, ISchemaRepository
    {
        public EfSchemaRepository(ScenarioContext context) : base(context)
        {
        }

        protected override DbSet<Schema> DbSet => Context.Schemas;
    }
}
