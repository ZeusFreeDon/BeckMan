using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeckMan.Del;
using BeckMan.Business.impl;
using System.Linq.Expressions;
using System.Data.Entity;

namespace BeckMan.Business.Services
{
    public class RoleService : IRoleService
    {
        BeckManEntities dbContext;

        public RoleService()
        {
            dbContext = new BeckManEntities();
        }

        public bec_Role Add(bec_Role Role)
        {
            dbContext.bec_RoleSet.Add(Role);
            dbContext.SaveChanges();
            return Role;
        }

        public void Delete(List<int> idList)
        {
            var sql = "delete bec_RoleSet where id in (";
            string idString = "";
            foreach (int id in idList)
            {
                idString += id.ToString() + ",";
            }
            idString = idString.TrimEnd(',');
            sql += idString + ")";
            dbContext.Database.ExecuteSqlCommand(sql);
        }

        public List<bec_Role> Find(bec_Role filter, int pageIndex, int pageSize)
        {
            Expression<Func<bec_Role, bool>> express = null;

            if (!string.IsNullOrEmpty(filter.RName))
            {
                express.Or(r => r.RName.Contains(filter.RName));
            }
            if (!string.IsNullOrEmpty(filter.ShotName))
            {
                express.Or(r => r.ShotName.Contains(filter.ShotName));
            }
            if (express == null) {
                express = r => true;
            }

            return dbContext.bec_RoleSet.Where(express).OrderBy(p => p.Id).ToList();

        }

        public bec_Role Get(int id)
        {
            return dbContext.bec_RoleSet.Find(id);
        }

        public bec_Role Update(bec_Role Role)
        {
            dbContext.Entry(Role).State = EntityState.Modified;
            dbContext.SaveChanges();
            return Role;

        }
    }
}
