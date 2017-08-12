using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeckMan.Business.Services
{
    public interface IDataOper<T>
    {
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        bool Save(T entity);

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        bool Update(T entity);

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        List<T> findList(T filter, int pageIndex, int pageSize);

        /// <summary>
        /// 条件查询所有
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        List<T> findList(T filter);

        /// <summary>
        /// 主键查询
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T Get(int id);

        /// <summary>
        /// 主键删除
        /// </summary>
        /// <param name="id"></param>
        void Delete(int id);


        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="ids"></param>
        void BachDelete(List<int> ids);
        
    }
}
