using System;
using System.Collections.Generic;
using System.Web.Http;
using ScenarioSim.Core.Entities;
using ScenarioSim.Services.ScenarioCreator;

namespace ScenarioSim.ScenarioCreatorApi.Controllers
{
    public class SchemaController : ApiController
    {
        private readonly ISchemaManager manager;

        public SchemaController(ISchemaManager manager)
        {
            if (manager == null)
                throw new ArgumentNullException(nameof(manager));

            this.manager = manager;
        }

        // GET: api/Schema
        public IEnumerable<Schema> Get()
        {
            throw new NotImplementedException();
        }

        // GET: api/Schema/5
        public Schema Get(int id)
        {
            return manager.GetSchema(id);
        }

        // POST: api/Schema
        public void Post(Schema value)
        {
            manager.CreateSchema(value);
        }

        // PUT: api/Schema/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Schema/5
        public void Delete(int id)
        {
        }
    }
}
