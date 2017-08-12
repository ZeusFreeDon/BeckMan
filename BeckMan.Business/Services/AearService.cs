using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeckMan.Del;

namespace BeckMan.Business.Services
{
    
    /// <summary>
    /// 区域服务
    /// </summary>
    public class AearService : IDataOper<bec_Aear>
    {
        BeckManEntities DbContext;

        public AearService()
        {
            DbContext = new BeckManEntities();
        }        

        public bool Update(bec_Aear Aear) {
            DbContext.Entry(Aear).State = System.Data.Entity.EntityState.Modified;
            int count  = DbContext.SaveChanges();
            return count == 1;
        }

        public bec_Aear Get(int AearID) {
            return DbContext.bec_AearSet.Find(AearID);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="AearName"></param>
        /// <returns>true:存在；false:不存在</returns>
        public bool ExsitAearName(String AearName) {
            return DbContext.bec_AearSet.Where(p => p.Name == AearName).Count() > 1;
        }

        public bool Save(bec_Aear entity)
        {
            DbContext.bec_AearSet.Add(entity);
            int count =DbContext.SaveChanges();
            return count == 1;
        }
        

        public List<bec_Aear> findList(bec_Aear filter, int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }

        public List<bec_Aear> findList(bec_Aear filter)
        {
            throw new NotImplementedException();
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
