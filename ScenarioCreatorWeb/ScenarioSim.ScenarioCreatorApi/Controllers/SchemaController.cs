using System;
using System.Collections.Generic;
using System.Web.Http;
using ScenarioSim.Core.Entities;
using ScenarioSim.Services.ScenarioCreator;

namespace ScenarioSim.ScenarioCreatorApi.Controllers
{
    /// <summary>
    /// The Api controller that receives all schema related calls.
    /// </summary>
    /// <seealso cref="System.Web.Http.ApiController" />
    public class SchemaController : ApiController
    {
        /// <summary>
        /// The schema manager
        /// </summary>
        private readonly ISchemaManager manager;

        /// <summary>
        /// Initializes a new instance of the <see cref="SchemaController"/> class.
        /// </summary>
        /// <param name="manager">The manager.</param>
        /// <exception cref="System.ArgumentNullException"></exception>
        public SchemaController(ISchemaManager manager)
        {
            if (manager == null)
                throw new ArgumentNullException(nameof(manager));

            this.manager = manager;
        }

        // GET: api/Schema
        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Schema> Get()
        {
            return manager.GetAllSchemas();
        }

        // GET: api/Schema/5
        /// <summary>
        /// Gets the specified schema.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public Schema Get(int id)
        {
            return manager.GetSchema(id);
        }

        // POST: api/Schema
        /// <summary>
        /// Creates the given schema.
        /// </summary>
        /// <param name="schema">The schema.</param>
        public void Post(Schema schema)
        {
            manager.CreateSchema(schema);
        }

        // PUT: api/Schema/5
        /// <summary>
        /// Updates the given schema.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="schema">The schema.</param>
        public void Put(int id, Schema schema)
        {
            manager.UpdateSchema(id, schema);
        }

        // DELETE: api/Schema/5
        /// <summary>
        /// Deletes the specified schema.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public void Delete(int id)
        {
            manager.DeleteSchema(id);
        }
    }
}
