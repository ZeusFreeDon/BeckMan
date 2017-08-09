using System.Linq;
using BeckMan.Del;
using BeckMan.Business.impl;
using System;

namespace BeckMan.Business.Services
{
    public class UserService:IUserService
    {
        BeckManEntities dbContext;
        public UserService()
        {
            dbContext = new BeckManEntities();
        }

        public bes_user Login(string userCode, string pwd) {
            
            return dbContext.bes_userSet.SingleOrDefault(u => u.UserCode == userCode && u.Password == pwd);            
        }

        public bes_user Add(bes_user user)
        {
            dbContext.bes_userSet.Add(user);
            dbContext.SaveChanges();
            return user;
        }
    }
}
