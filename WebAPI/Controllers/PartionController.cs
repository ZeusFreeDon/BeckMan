using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BeckMan.Business;
using BeckMan.Del;
using WebAPI.Models;
using BeckMan.Business.Services;

namespace BeckMan.WebAPI.Controllers
{
    /// <summary>
    /// 分区操作的相关API
    /// </summary>
    public class PartionController : ApiController
    {
        PartionService pService = new PartionService();

        /// <summary>
        /// 分区的分页查询
        /// </summary>
        /// <param name="filter">查询条件</param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [Route("api/Partion/pageList")]
        public PagingEntity<bec_Partion> PageList([FromBody]bec_Partion filter, int pageIndex, int pageSize) {
            List<bec_Partion> lists = pService.findList(filter).Skip(pageIndex).Take(pageSize).ToList();
            return new PagingEntity<bec_Partion>() { items = lists, total = lists.Count };
        }

        /// <summary>
        /// 添加分区
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>是否成功</returns>
        [Route("api/Partion/AddPartion")]
        public void AddPartion([FromBody]bec_Partion entity) {
            pService.Save(entity);
        }

        /// <summary>
        /// 更新分区数据
        /// </summary>
        /// <param name="entity"></param>
        [Route("api/Partion/Update")]
        public void Update([FromBody] bec_Partion entity) {
            pService.Update(entity);
        }

        /// <summary>
        /// 查询是否存在分区编号
        /// </summary>
        /// <param name="partionNo">分区编号</param>
        /// <returns></returns>
        [Route("api/Partion/ExsitPartionNo")]
        public bool ExsitPartionNo(string partionNo) {
            return pService.ExsitPartionNo(partionNo);
        }


        /// <summary>
        /// 根据主键查询
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("api/Partion/Get/{id}")]
        public bec_Partion Get(int id) {
            return pService.Get(id);
        }
    }
}