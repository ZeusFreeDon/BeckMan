﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeckMan.Del;

namespace BeckMan.Business.impl
{
    public interface IUserService
    {
        bec_User Add(bec_User user);

        /// <summary>
        /// 查找Marsdata用户
        /// </summary>
        /// <returns></returns>
        //List<bsc_user> FindMDUsers();
    }
}
