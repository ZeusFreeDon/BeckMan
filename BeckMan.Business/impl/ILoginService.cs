using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeckMan.Del;

namespace BeckMan.Business.impl
{
    public interface ILoginService
    {
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="userCode"></param>
        /// <param name="password"></param>
        bes_user Login(string userCode, string password);

        /// <summary>
        /// 用户退出
        /// </summary>
        /// <param name="userCode"></param>
        void LogOut(string userCode);
    }
}
