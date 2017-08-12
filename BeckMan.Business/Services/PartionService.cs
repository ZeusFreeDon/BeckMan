using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeckMan.Del;
using System.Linq.Expressions;

namespace BeckMan.Business.Services
{
    /// <summary>
    /// 分区服务
    /// </summary>
    public class PartionService : IDataOper<bec_Partion>
    {
        BeckManEntities dbContext;

        public PartionService()
        {
            dbContext = new BeckManEntities();
        }

        public bool Save(bec_Partion entity)
        {
            dbContext.bec_PartionSet.Add(entity);
            return dbContext.SaveChanges() == 1;
        }

        public bool Update(bec_Partion entity)
        {
            dbContext.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            return dbContext.SaveChanges() == 1;
        }

        public bec_Partion Get(int Id)
        {
            return dbContext.bec_PartionSet.Find(Id);
        }

        public List<bec_Partion> findList(bec_Partion filter)
        {
            Expression<Func<bec_Partion, bool>> express = p => false;
            if (!string.IsNullOrEmpty(filter.PartionName))
            {
                express = express.Or(p => p.PartionName.Contains(filter.PartionName));
            }
            if (!string.IsNullOrEmpty(filter.PartionID))
            {
                express = express.Or(p => p.PartionID.Contains(filter.PartionID));
            }
            return dbContext.bec_PartionSet.Where(express).ToList();
        }

        /// <summary>
        /// 判断区分区编号是否存在
        /// </summary>
        /// <param name="partionID">分区编号</param>
        /// <returns></returns>
        public bool ExsitPartionNo(String partionID)
        {
            return dbContext.bec_PartionSet.SingleOrDefault(p => p.PartionID == partionID) != null;
        }

        public List<bec_Partion> findList(bec_Partion filter, int pageIndex, int pageSize)
        {
            Expression<Func<bec_Partion, bool>> express = p => false;
            if (!string.IsNullOrEmpty(filter.PartionName))
            {
                express = express.Or(p => p.PartionName.Contains(filter.PartionName));
            }
            if (!string.IsNullOrEmpty(filter.PartionID))
            {
                express = express.Or(p => p.PartionID.Contains(filter.PartionID));
            }
            int skipCount = (pageIndex - 1) * pageSize;
            return dbContext.bec_PartionSet.Where(express).Skip(skipCount).Take(pageSize).ToList();
            
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void BachDelete(List<int> ids)
        {
            throw new NotImplementedException();
        }
    }
}
