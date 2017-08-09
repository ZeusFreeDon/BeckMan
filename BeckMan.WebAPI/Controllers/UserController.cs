using BeckMan.Del;
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
        /// <summary>
        /// 获取所有用户
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<bes_user> GetAll() {
            using (BeckManEntities dbContext = new BeckManEntities()) {
                return dbContext.bes_userSet.Where(a => true).ToList();
            }
        }
    }
}
