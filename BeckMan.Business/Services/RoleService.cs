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
        BeckManEntities DBContext;

        public RoleService()
        {
            DBContext = new BeckManEntities();
        }

        public int Total()
        {
            return DBContext.bec_RoleSet.Count();
        }

        public bec_Role Add(bec_Role Role)
        {
            DBContext.bec_RoleSet.Add(Role);
            DBContext.SaveChanges();
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
            DBContext.Database.ExecuteSqlCommand(sql);
        }

        public List<bec_Role> Find(bec_Role filter, int start, int limit)
        {
            Expression<Func<bec_Role, bool>> express = null;

            if (filter != null)
            {
                if (!string.IsNullOrEmpty(filter.Name))
                {
                    express.Or(r => r.Name.Contains(filter.Name));
                }
                if (!string.IsNullOrEmpty(filter.ShortName))
                {
                    express.Or(r => r.ShortName.Contains(filter.ShortName));
                }
            }
            if (express == null) {
                express = r => true;
            }

            return DBContext.bec_RoleSet.Where(express).OrderBy(p => p.Id).Skip(start).Take(limit).ToList();

        }

        public bec_Role Get(int id)
        {
            return DBContext.bec_RoleSet.Find(id);
        }

        public void Update(bec_Role Role)
        {
            DBContext.Entry(Role).State = EntityState.Modified;
            DBContext.SaveChanges();
        }
    }
}
