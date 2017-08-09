using BeckMan.Business.impl;
using BeckMan.Del;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeckMan.Business.Services
{
    public class LoginService : ILoginService
    {
        BeckManEntities dbContext;

        public LoginService()
        {
            dbContext = new BeckManEntities();
        }

        public bes_user Login(string userCode, string password)
        {
            return dbContext.bes_userSet.SingleOrDefault(u => u.UserCode == userCode && u.Password == password);
        }

        public void LogOut(string userCode)
        {   
        }
    }
}
