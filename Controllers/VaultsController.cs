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

    [Authorize]
    // everything beyond this point will require authenication
    public class VaultsController : Controller
    {
        public KeeprContext _db { get; private set; }

        public VaultsController(KeeprContext db)
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

        // GET api/vaults/Id
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // GET api/vaults (gets only the user's vaults)
        [HttpGet]
        public IEnumerable<Vault> Get()
        {
            //find all vaults where the vault.userId == *req.session.uid*
            var id = GetUserId();
            if (id != null)
            {
                return _db.Vaults.Where(e => e.UserId == id);
            }
            else
            {
                return null;
            }
        }


        // POST api/vaults
        [HttpPost]
        public string Post([FromBody]Vault vault)
        {
            
            vault.UserId = GetUserId();
            if (vault.UserId == "")
            {
                // requiring authorization (using [Authorize] at the top of the class) will handle most unauthorized cases by returning an empty page. 
                // This will only be hit if a session persistancy issue is encountered. (the session in the cookies is present, but the server terminated it on its end somehow by respinning)
                return "Not logged in";
            }
            _db.Vaults.Add(vault);
            _db.SaveChanges();
            return "Successfully added vault";
        }

        // PUT api/vaults/id
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/vaults/id
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
