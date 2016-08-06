using ScenarioSim.Core.Entities;
using ScenarioSim.Core.Interfaces;

namespace ScenarioSim.Infrastructure.HttpClientRepositories
{
    public class HttpClientSchemaRepository : HttpClientEntityRepository<Schema>, ISchemaRepository
    {
        public HttpClientSchemaRepository(string baseUrl) : base(baseUrl)
        {
        }

        protected override string ResourceName => "schema";
    }
}
