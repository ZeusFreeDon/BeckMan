using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeckMan.Del;
using System.Linq.Expressions;

namespace BeckMan.Business.Services
{
    public class MDUserService
    {
        BeckManEntities dbContext;
        public MDUserService()
        {
            dbContext = new BeckManEntities();
        }
        //public List<bsc_user> FindMDUser(bsc_user filter,int pageIndex,int pageSize) {
        //    Expression<Func<bsc_user, bool>> expres = p => p.isDistributor == true;
        //    if (string.IsNullOrEmpty(filter.userCode)){
        //        expres.And(p => p.userCode == filter.userCode);
        //    }
        //    if (string.IsNullOrEmpty(filter.userName))
        //    {
        //        expres.And(p => p.userName == filter.userName);
        //    }
        //    if (filter.isAllowed != null)
        //    {
        //        expres.And(p => p.isAllowed == filter.isAllowed);
        //    }

        //    return dbContext.bsc_user.Where(expres).ToList();
        //}
    }
}
