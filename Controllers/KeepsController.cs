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
        public KeeprContext _db { get; private set; }

        public KeepsController(KeeprContext db)
        {
            _db = db;
        }

        private string GetUserId()
        {
            byte[] byteId;
            HttpContext.Session.TryGetValue("uid", out byteId);
            if (byteId != null)
            {
                var id = System.Text.Encoding.UTF8.GetString(byteId);
                return id;

            }
            else
            {
                return "";
            }
        }

        // GET api/keeps
        [HttpGet]
        public IEnumerable<Keep> Get()
        {
            return _db.Keeps;
        }

        // GET api/keeps/Id
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }


        // everything beyond this point will require authenication
        [Authorize]

        // POST api/keeps
        [HttpPost]
        public string Post([FromBody]Keep keep)
        {
            keep.UserId = GetUserId();  //this isn't working
            // keep.UserId = "86870b7f-95cc-4c1a-8125-9b4d200dc5a9";
            // if (keep.UserId == "")
            // {
            //     //requiring authorization (using [Authorize] at the top of the class) will handle most unauthorized cases by returning an empty page. 
            //     //This will only be hit if a session persistancy issue is encountered. (the session in the cookies is present, but the server terminated it on its end somehow by respinning)
            //     return "Not logged in";
            // }
            _db.Keeps.Add(keep);
            _db.SaveChanges();
            return "Successfully added keep";

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
