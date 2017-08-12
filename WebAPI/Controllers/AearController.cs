using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BeckMan.Del;
using BeckMan.Business.Services;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    /// <summary>
    ///区域操作
    /// </summary>
    public class AearController : ApiController
    {
        AearService aService = new AearService();

        /// <summary>
        /// 添加区域信息
        /// </summary>
        [Route("api/Aear/Add")]
        public void Add([FromBody] bec_Aear entity) {
            aService.Add(entity);
        }
    }
}
