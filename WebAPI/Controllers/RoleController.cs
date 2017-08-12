using BeckMan.Business.Services;
using BeckMan.Del;
using WebAPI.Models;
using Newtonsoft.Json.Linq;
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

        [Route("api/Role/All")]
        public PagingEntity<bec_Role> Get()
        {
            return new PagingEntity<bec_Role> { total = roleService.Total(), items = roleService.Find() };
        }

        [Route("api/Role/pageList")]
        public PagingEntity<bec_Role> Get(int start, int limit)
        {
            return new PagingEntity<bec_Role> { total = roleService.Total(), items = roleService.Find(start, limit) };
        }

        [Route("api/Role/findList")]
        public PagingEntity<bec_Role> Get(string filter, int start, int limit)
        {
            if (string.IsNullOrEmpty(filter))
            {
                return Get(start, limit);
            }
            return new PagingEntity<bec_Role> { total = roleService.Total(filter), items = roleService.Find(filter, start, limit) };
        }

        [Route("api/Role/Get/{id}")]
        public bec_Role Get(int id)
        {
            return roleService.Get(id);
        }

        [Route("api/Role/Post")]
        // POST: api/Product
        public bec_Role Post([FromBody]bec_Role role)
        {
            return roleService.Add(role);
        }

        [Route("api/Role/Put")]
        // PUT: api/Product/5
        public void Put(int id, [FromBody]bec_Role role)
        {
            roleService.Update(role);
        }

        [Route("api/Role/Delete")]
        // DELETE: api/Product/5
        public void Delete(int id)
        {
            roleService.Delete(new List<int> { id });
        }

        
    }
}
