using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BeckMan.Del;
using BeckMan.Business.Services;
using WebAPI.Models;
using System.Linq.Expressions;
using BeckMan.Business;

namespace WebAPI.Controllers
{
    /// <summary>
    /// 经销商评估信息
    /// </summary>
    public class AssInfomationController : ApiController
    {
        BaseRepository<bec_AssInformation> dbBase = new BaseRepository<bec_AssInformation>();
        private Expression<Func<bec_AssInformation, bool>> CreateQueryFilter(bec_AssInformation filter)
        {
            Expression<Func<bec_AssInformation, bool>> queryexpress = q => true;
            if (!string.IsNullOrEmpty(filter.DisName))
            {
                queryexpress = queryexpress.And(p => p.DisName.Contains(filter.DisName));
            }
            if (!string.IsNullOrEmpty(filter.DisNo))
            {
                queryexpress = queryexpress.And(p => p.DisNo.Contains(filter.DisNo));
            }
            if (!string.IsNullOrEmpty(filter.Year))
            {
                queryexpress = queryexpress.And(p => p.Year.Equals(filter.Year));
            }
            if (filter.bec_Partion != null)
            {
                queryexpress = queryexpress.And(p => p.bec_Partion.Id == filter.bec_Partion.Id);
            }
            if (filter.bec_Aear != null)
            {
                queryexpress = queryexpress.And(p => p.bec_Aear.Id == filter.bec_Aear.Id);
            }
            return queryexpress;
        }

        private Expression<Func<bec_AssInformation, bool>> CreateLinkQuery(string queryString)
        {
            Expression<Func<bec_AssInformation, bool>> queryexpress = q => true;
            queryexpress.Or(p => p.DisNo.Contains(queryString));
            queryexpress.Or(p => p.DisName.Contains(queryString));
            queryexpress.Or(p => p.Year.Contains(queryString));
            queryexpress.Or(p => p.bec_Aear.Name.Contains(queryString));
            queryexpress.Or(p => p.bec_Partion.PartionName.Contains(queryString));
            return queryexpress;
        }

        /// <summary>
        /// 添加经销商
        /// </summary>
        /// <param name="entity"></param>
        [Route("AssInfoMation/Save")]
        public HttpResponseMessage Save([FromBody] bec_AssInformation entity)
        {
            return ExceptionHelp.Execute<bool>(() =>
            {
                return dbBase.Save(entity);
            }, Request);
        }

        /// <summary>
        /// 添加经销商
        /// </summary>
        /// <param name="entity"></param>
        [Route("AssInfoMation/Update")]
        public HttpResponseMessage Update([FromBody] bec_AssInformation entity)
        {
            return ExceptionHelp.Execute<bool>(() =>
            {
                BeckManEntities dbContext = new BeckManEntities();
                bec_AssInformation dbEntity = dbContext.bec_AssInformationSet.Find(entity.Id);
                if (entity.bec_Aear != null) {
                    bec_Aear aear = dbContext.bec_AearSet.Find(entity.bec_Aear.Id);
                    aear.bec_AssInformation.Add(dbEntity);
                }
                if(entity.bec_Partion != null)
                {
                    bec_Partion partion = dbContext.bec_PartionSet.Find(entity.bec_Partion.Id);
                    partion.bec_AssInformation.Add(dbEntity);
                }
                dbContext.SaveChanges();
                return dbBase.Update(entity);
            }, Request);
        }

        /// <summary>
        /// 添加经销商
        /// </summary>
        /// <param name="entity"></param>
        [Route("AssInfoMation/Get/{id}")]
        public HttpResponseMessage Get(int id)
        {
            return ExceptionHelp.Execute<bec_AssInformation>(() =>
            {
                return dbBase.Find(id);
            }, Request);
        }

        /// <summary>
        /// 添加经销商
        /// </summary>
        /// <param name="entity"></param>
        [Route("AssInfoMation/Delete/{id}")]
        public HttpResponseMessage Delete(int id) {

            bec_AssInformation entity = new bec_AssInformation { Id = id };
            return ExceptionHelp.Execute<bool>(() =>
            {
                return dbBase.Delete(entity);
            }, Request);
        }

        /// <summary>
        /// 添加经销商
        /// </summary>
        /// <param name="entity"></param>
        [Route("AssInfoMation/ListPage/{pageIndex}/{pageSize}")]
        public HttpResponseMessage ListPage([FromBody]bec_AssInformation filter, int pageIndex, int pageSize)
        {
            Expression<Func<bec_AssInformation, bool>> queryexpress = CreateQueryFilter(filter);
            Expression<Func<bec_AssInformation, int>> orderexpress = p => p.Id;
            int total = 0;
            return ExceptionHelp.Execute<PagingEntity<bec_AssInformation>>(() =>
            {
                PagingEntity<bec_AssInformation> result = new PagingEntity<bec_AssInformation>();
                result.items = dbBase.LoadPagerEntities(pageSize, pageIndex, out total, queryexpress, true, orderexpress);
                result.total = total;
                return result;
            }, Request);
        }

        /// <summary>
        /// 添加经销商
        /// </summary>
        /// <param name="entity"></param>
        [Route("AssInfoMation/Search/{searchText}/{pageIndex}/{pageSize}")]
        public HttpResponseMessage Search(string searchText, int pageIndex, int pageSize)
        {
            Expression<Func<bec_AssInformation, bool>> queryexpress = CreateLinkQuery(searchText);
            Expression<Func<bec_AssInformation, int>> orderexpress = p => p.Id;
            int total = 0;
            return ExceptionHelp.Execute<PagingEntity<bec_AssInformation>>(() =>
            {
                PagingEntity<bec_AssInformation> result = new PagingEntity<bec_AssInformation>();
                result.items = dbBase.LoadPagerEntities(pageSize, pageIndex, out total, queryexpress, true, orderexpress);
                result.total = total;
                return result;
            }, Request);
        }
    }
}
