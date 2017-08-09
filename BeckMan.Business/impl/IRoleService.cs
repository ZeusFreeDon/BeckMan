using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeckMan.Del;

namespace BeckMan.Business.impl
{
    public interface IRoleService
    {
        /// <summary>
        /// 添加角色
        /// </summary>
        /// <param name="Role"></param>
        /// <returns></returns>
        bec_Role Add(bec_Role Role);

        bec_Role Update(bec_Role Role);

        /// <summary>
        /// 主键查询
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bec_Role Get(int id);

        /// <summary>
        /// 根据角色id数组批量删除
        /// </summary>
        /// <param name="ids"></param>
        void Delete(List<int> idList);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filter">查询条件</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页显示行</param>
        /// <returns></returns>
        List<bec_Role> Find(bec_Role filter,int pageIndex,int pageSize);
        
    }
}
