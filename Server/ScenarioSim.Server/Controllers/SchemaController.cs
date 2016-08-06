using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using ScenarioSim.Core.Entities;
using ScenarioSim.Server.Models;
using ScenarioSim.Services.ScenarioCreator;

namespace ScenarioSim.Server.Controllers
{
    /// <summary>s
    /// The Api controller that receives all schema related calls.
    /// </summary>
    /// <seealso cref="System.Web.Http.ApiController" />
    [EnableCors("http://localhost:45723", "*", "*")]
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
        public Schema Get(Guid id)
        {
            return manager.GetSchema(id);
        }

        // POST: api/Schema
        /// <summary>
        /// Creates the given schema.
        /// </summary>
        /// <param name="model">The create schema view model.</param>
        public void Post(CreateSchemaViewModel model)
        {
            Schema schema = new Schema
            {
                Name = model.Name,
                Description = model.Description
            };

            manager.CreateSchema(schema);
        }

        // PUT: api/Schema/5
        /// <summary>
        /// Updates the given schema.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="model">The schema.</param>
        public void Put(Guid id, EditSchemaViewModel model)
        {
            Schema schema = new Schema
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description
            };

            manager.UpdateSchema(id, schema);
        }

        // DELETE: api/Schema/5
        /// <summary>
        /// Deletes the specified schema.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public void Delete(Guid id)
        {
            manager.DeleteSchema(id);
        }
    }
}
