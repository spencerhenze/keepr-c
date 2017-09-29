using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using keepr.Models;

namespace keepr.Controllers
{
    [Route("api/[controller]")]
    public class KeepsController : Controller
    {
        // GET api/keeps
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/keeps/Id
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [Authorize]
        // everything beyond this point will require authenication

        // POST api/keeps
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/keeps/id
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/keeps/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
