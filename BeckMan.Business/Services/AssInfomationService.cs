using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeckMan.Del;
using System.Data.Entity.Validation;

namespace BeckMan.Business.Services
{
    /// <summary>
    /// 经销商评估信息服务
    /// </summary>
    public class AssInfomationService : IDataOper<bec_AssInformation>
    {
        BeckManEntities dbContext;
        public AssInfomationService()
        {
            dbContext = new BeckManEntities();
        }

        public void BachDelete(List<int> ids)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<bec_AssInformation> findList(bec_AssInformation filter)
        {
            throw new NotImplementedException();
        }

        public List<bec_AssInformation> findList(bec_AssInformation filter, int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }

        public bec_AssInformation Get(int id)
        {
            throw new NotImplementedException();
        }

        public bool Save(bec_AssInformation entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(bec_AssInformation entity)
        {
            throw new NotImplementedException();
        }
    }
}
