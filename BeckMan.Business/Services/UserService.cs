using System.Linq;
using BeckMan.Del;
using BeckMan.Business.impl;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace BeckMan.Business.Services
{
    public class UserService
    {
        BeckManEntities DBContext;

        private RoleService roleService = new RoleService();
        public UserService()
        {
            DBContext = new BeckManEntities();
        }

        public bec_User Get(int id)
        {
            return DBContext.bec_UserSet.Find(id);
        }

        public bec_User Login(string userCode, string pwd) {
            
            return DBContext.bec_UserSet.SingleOrDefault(u => u.UserCode == userCode && u.Password == pwd);            
        }

        public bec_User Add(bec_User user)
        {
            DBContext.bec_UserSet.Add(user);
            DBContext.SaveChanges();
            return user;
        }

        public List<bec_User> Find(int start, int limit)
        {
            return DBContext.bec_UserSet.OrderBy(p => p.UserName).Skip(start).Take(limit).ToList(); ;
        }

        public List<bec_User> Find(string namefilter, int start, int limit)
        {
            return DBContext.bec_UserSet.Where(p => p.UserName.Contains(namefilter)).OrderBy(p => p.UserName).Skip(start).Take(limit).ToList(); ;
        }

        public int Total()
        {
            return DBContext.bec_RoleSet.Count();
        }

        public int Total(string namefilter)
        {
            return DBContext.bec_RoleSet.Where(p => p.Name.Contains(namefilter)).Count();
        }

        public void Delete(List<int> idList)
        {
            var sql = "delete bec_UserSet where id in (";
            string idString = "";
            foreach (int id in idList)
            {
                idString += id.ToString() + ",";
            }
            idString = idString.TrimEnd(',');
            sql += idString + ")";
            DBContext.Database.ExecuteSqlCommand(sql);
        }

        public void Update(bec_User user)
        {
            DBContext.Entry(user).State = EntityState.Modified;
            DBContext.SaveChanges();
        }
    }
}
