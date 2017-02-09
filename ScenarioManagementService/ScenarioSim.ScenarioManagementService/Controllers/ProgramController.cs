using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;
using ScenarioSim.Core.Entities;
using ScenarioSim.Services.ScenarioCreator;

namespace ScenarioSim.ScenarioManagementService.Controllers
{
    /// <summary>
    /// Used to retrieve and store programs.
    /// </summary>
    /// <seealso cref="System.Web.Http.ApiController" />
    [EnableCors("http://localhost:45723", "*", "*")]
    [Authorize]
    public class ProgramController : ApiController
    {
        private readonly IProgramManager manager;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProgramController"/> class.
        /// </summary>
        /// <param name="manager">The manager.</param>
        public ProgramController(IProgramManager manager)
        {
            if (manager == null)
                throw new ArgumentNullException(nameof(manager));

            this.manager = manager;
        }

        // GET: api/Program
        /// <summary>
        /// Gets all of the programs.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Program> Get()
        {
            return manager.GetAllPrograms();
        }

        // GET: api/Program/5
        /// <summary>
        /// Gets the program with the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public Program Get(Guid id)
        {
            return manager.GetProgram(id);
        }

        // POST: api/Program
        /// <summary>
        /// Adds the specified program
        /// </summary>
        /// <param name="model">The model.</param>
        [Authorize(Roles = "Curriculum Designer, Administrator")]
        public void Post(Program model)
        {
            Program program = new Program
            {
                Name = model.Name,
                Description = model.Description
            };

            manager.CreateProgram(program);
        }

        // PUT: api/Program/5
        /// <summary>
        /// Updates the program with the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="model">The model.</param>
        [Authorize(Roles = "Curriculum Designer, Administrator")]
        public void Put(Guid id, Program model)
        {
            Program program = new Program
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description
            };

            manager.UpdateProgram(id, program);
        }

        // DELETE: api/Program/5
        /// <summary>
        /// Deletes the program with the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        [Authorize(Roles = "Curriculum Designer, Administrator")]
        public void Delete(Guid id)
        {
            manager.DeleteProgram(id);
        }
    }
}
