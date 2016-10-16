using ScenarioSim.Core.Entities;
using ScenarioSim.Core.Interfaces;
using ScenarioSim.Services.Mapping;

namespace ScenarioSim.Infrastructure.EfRepositories
{
    public class EfSchemaRepository : EfMappedEntityRepository<Schema, EfSchema>, ISchemaRepository
    {
        public EfSchemaRepository(IDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
