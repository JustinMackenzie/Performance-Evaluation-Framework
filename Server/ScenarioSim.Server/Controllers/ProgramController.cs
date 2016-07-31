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
    [EnableCors("http://localhost:45723", "*", "*")]
    public class ProgramController : ApiController
    {
        private readonly IProgramManager manager;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProgramController"/> class.
        /// </summary>
        /// <param name="manager">The manager.</param>
        /// <exception cref="System.ArgumentNullException"></exception>
        public ProgramController(IProgramManager manager)
        {
            if (manager == null)
                throw new ArgumentNullException(nameof(manager));

            this.manager = manager;
        }

        // GET: api/Program
        public IEnumerable<Program> Get()
        {
            return manager.GetAllPrograms();
        }

        // GET: api/Program/5
        public Program Get(Guid id)
        {
            return manager.GetProgram(id);
        }

        // POST: api/Program
        public void Post(CreateProgramViewModel model)
        {
            Program program = new Program
            {
                Name = model.Name,
                Description = model.Description
            };

            manager.CreateProgram(program);
        }

        // PUT: api/Program/5
        public void Put(Guid id, EditProgramViewModel model)
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
        public void Delete(Guid id)
        {
            manager.DeleteProgram(id);
        }
    }
}
