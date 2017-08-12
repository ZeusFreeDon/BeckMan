using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BeckMan.Del;
using BeckMan.Business.Services;
using WebAPI.Models;
using System.Net.Http.Formatting;
using System.Linq.Expressions;
using BeckMan.Business;

namespace WebAPI.Controllers
{
    /// <summary>
    ///区域操作
    /// </summary>
    public class AearController : ApiController
    {
        BaseRepository<bec_Aear> baseDB = new BaseRepository<bec_Aear>();

        /// <summary>
        /// 添加区域信息
        /// </summary>
        [Route("api/Aear/Save")]
        public HttpResponseMessage Save([FromBody] bec_Aear entity)
        {
            bec_Aear sameEntity = baseDB.LoadEntities(a => a.Name == entity.Name).FirstOrDefault();
            if (sameEntity != null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "区域名称重复");
            }
            return ExceptionHelp.Execute<bool>(() =>
            {
                return baseDB.Save(entity);
            }, Request);

        }

        /// <summary>
        /// 修改区域信息
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [Route("api/Aear/Update")]
        public HttpResponseMessage Update([FromBody]bec_Aear entity)
        {
            return ExceptionHelp.Execute<bool>(() =>
            {
                return baseDB.Update(entity);
            }, Request);
        }

        /// <summary>
        /// 修改区域信息
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [Route("api/Aear/Get/{id}")]
        public HttpResponseMessage Get(int id)
        {
            return ExceptionHelp.Execute<bec_Aear>(() =>
            {
                return baseDB.Find(id);
            }, Request);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("api/Aear/Delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            bec_Aear entity = new bec_Aear { Id = id };
            return ExceptionHelp.Execute<bool>(() =>
            {
                return baseDB.Delete(entity);
            }, Request);
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [Route("api/Aear/pageList1/{pageIndex}/{pageSize}")]
        public HttpResponseMessage pageList1([FromBody]bec_Aear filter, int pageIndex, int pageSize)
        {
            Expression<Func<bec_Aear, bool>> queryexpress = CreateQueryFilter(filter);
            Expression<Func<bec_Aear, int>> orderexpress = p => p.Id;
            int total = 0;
            return ExceptionHelp.Execute<PagingEntity<bec_Aear>>(() =>
            {
                PagingEntity<bec_Aear> result = new PagingEntity<bec_Aear>();
                result.items = baseDB.LoadPagerEntities(pageSize, pageIndex, out total, queryexpress, true, orderexpress);
                result.total = total;
                return result;
            }, Request);
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [Route("api/Aear/pageList2/{pageIndex}/{pageSize}")]
        public HttpResponseMessage pageList2([FromBody]bec_Aear filter, int pageIndex, int pageSize)
        {
            Expression<Func<bec_Aear, bool>> queryexpress = CreateQueryFilter(filter);
            Expression<Func<bec_Aear, int>> orderexpress = p => p.Id;
            return ExceptionHelp.Execute<IEnumerable<bec_Aear>>(() =>
            {
                var lists = baseDB.db.bec_AearSet.Where(queryexpress).OrderBy(orderexpress).Skip(pageIndex).Take(pageSize).AsEnumerable();
                return lists;
            }, Request);
        }

        public HttpResponseMessage pageList(bec_Aear filter)
        {
            var query = CreateQueryFilter(filter);
            return ExceptionHelp.Execute<IEnumerable<bec_Aear>>(() =>
            {
                return baseDB.LoadEntities(query);
            }, Request);
        }

        private Expression<Func<bec_Aear, bool>> CreateQueryFilter(bec_Aear filter)
        {
            Expression<Func<bec_Aear, bool>> queryexpress = q => false;
            if (!string.IsNullOrEmpty(filter.Name))
            {
                queryexpress = queryexpress.Or(p => p.Name.Contains(filter.Name));
            }
            if (!string.IsNullOrEmpty(filter.Remak))
            {
                queryexpress = queryexpress.Or(p => p.Remak.Contains(filter.Remak));
            }
            return queryexpress;
        }


    }
}
