using BeckMan.Business.Services;
using BeckMan.Del;
using BeckMan.WebAPI.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BeckMan.WebAPI.Controllers
{
    /// <summary>
    /// 用户操作
    /// </summary>
    public class UserController : ApiController
    {

        private UserService userService = new UserService();
        private RoleService roleService = new RoleService();

        [Route("api/User/Get")]
        public bec_User Get(int id)
        {
            return userService.Get(id);
        }


        //public PagingEntity<bec_User> Get(int start, int limit)
        //{
        //    return new PagingEntity<bec_User> { total = userService.Total(), items = userService.Find(start, limit) };
        //}

        //public PagingEntity<bec_User> Get(string filter, int start, int limit)
        //{
        //    if (string.IsNullOrEmpty(filter))
        //    {
        //        return Get(start, limit);
        //    }
        //    return new PagingEntity<bec_User> { total = userService.Total(filter), items = userService.Find(filter, start, limit) };
        //}

        // POST: api/Product
        [Route("api/User/Post")]
        public bec_User Post([FromBody]bec_User user)
        {
            return userService.Add(user);
        }

        // PUT: api/Product/5
        [Route("api/User/Put")]
        public void Put(int id, [FromBody]bec_User user)
        {
            userService.Update(user);
        }

        // DELETE: api/Product/5
        [Route("api/User/Delete")]
        public void Delete(int id)
        {
            userService.Delete(new List<int> { id });
        }

        [HttpGet]
        [Route("api/User/{id}/functions")]
        public JObject Functions(int id)
        {
            //获取所有角色，组合功能列表
            bec_Role role = roleService.Get(4);
            if (role.Functions == null)
            {
                return new JObject();
            }
            else
            {
                JObject json = JObject.Parse(role.Functions);
                json.Properties().ToList().ForEach(prop =>
                {
                    JProperty menu = json.Property(prop.Name);
                    JObject menu1 = (JObject)json.GetValue(prop.Name);


                });
                return json;
            }


        }
    }
}
