using BeckMan.Business.Services;
using BeckMan.Del;
using BeckMan.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BeckMan.WebAPI.Controllers
{
    public class RoleController : ApiController
    {
        RoleService roleService = new RoleService();
        public PagingEntity<bec_Role> Get(int start, int limit)
        {
            return new PagingEntity<bec_Role> { total = roleService.Total(), items = roleService.Find(null, start, limit) };
        }

        public bec_Role Get(int id)
        {
            return roleService.Get(id);
        }

        // POST: api/Product
        public bec_Role Post([FromBody]bec_Role role)
        {
            return roleService.Add(role);
        }

        // PUT: api/Product/5
        public void Put(int id, [FromBody]bec_Role role)
        {
            roleService.Update(role);
        }

        // DELETE: api/Product/5
        public void Delete(int id)
        {
            roleService.Delete(new List<int> { id });
        }
    }
}
