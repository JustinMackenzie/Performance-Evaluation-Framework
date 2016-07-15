using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ScenarioSim.Server.Controllers
{
    public class PerformerController : ApiController
    {
        // GET: api/Performer
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Performer/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Performer
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Performer/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Performer/5
        public void Delete(int id)
        {
        }
    }
}
