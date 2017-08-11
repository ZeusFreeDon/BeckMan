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
    public class RoleService
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

        public int Total(string namefilter)
        {
            return DBContext.bec_RoleSet.Where(p => p.Name.Contains(namefilter)).Count();
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

        public List<bec_Role> Find(int start, int limit)
        {
            return DBContext.bec_RoleSet.OrderBy(p => p.Name).Skip(start).Take(limit).ToList(); ;
        }

        public List<bec_Role> Find(string namefilter, int start, int limit)
        {
            return DBContext.bec_RoleSet.Where(p => p.Name.Contains(namefilter)).OrderBy(p => p.Name).Skip(start).Take(limit).ToList(); ;
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
