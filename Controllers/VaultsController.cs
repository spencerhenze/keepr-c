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
    public class VaultsController : Controller
    {
        public KeeprContext _db { get; private set; }

        public VaultsController(KeeprContext db)
        {
            _db = db;
        }

        // GET api/vaults (gets only the user's vaults)
        [HttpGet]
        public IEnumerable<Vault> Get()
        {
            //find all vaults where the vault.userId == *req.session.uid*
            var id = GetUserId();
            return _db.Vaults.Where(e => e.UserId == id);
        }

        private string GetUserId()
        {
            byte[] byteId;
            HttpContext.Session.TryGetValue("uid", out byteId);
            var id = System.Text.Encoding.UTF8.GetString(byteId);
            return id;
        }

        // GET api/vaults/Id
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [Authorize]
        // everything beyond this point will require authenication

        // POST api/vaults
        [HttpPost]
        public void Post([FromBody]string value)
        {
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
