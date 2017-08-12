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
    public class AearService
    {
        BeckManEntities DbContext;

        public AearService()
        {
            DbContext = new BeckManEntities();
        }

        public void Add(bec_Aear Aear) {
            DbContext.bec_AearSet.Add(Aear);
            DbContext.SaveChanges();
        }

        public void Update(bec_Aear Aear) {
            DbContext.Entry(Aear).State = System.Data.Entity.EntityState.Modified;
            DbContext.SaveChanges();
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
        
    }
}
