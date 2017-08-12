using BeckMan.Del;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BeckMan.Business.Services
{
    public class BaseRepository<T> where T : class
    {
        public BaseRepository()
        {
            db = new BeckManEntities();
        }

        //实例化EF框架
        public BeckManEntities db;

        public T Find(params object[] key) {
            return db.Set<T>().Find(key);
        }

        //添加
        public bool Save(T entity)
        {
            db.Entry<T>(entity).State = EntityState.Added;
            return db.SaveChanges() > 0;
        }

        //修改
        public bool Update(T entity)
        {
            db.Set<T>().Attach(entity);
            db.Entry<T>(entity).State = EntityState.Modified;
            return db.SaveChanges() > 0;
        }

        //删除
        public bool Delete(T entity)
        {
            db.Set<T>().Attach(entity);
            db.Entry<T>(entity).State = EntityState.Deleted;
            return db.SaveChanges() > 0;
        }

        //查询
        public IEnumerable<T> LoadEntities(Expression<Func<T, bool>> wherelambda)
        {
            return db.Set<T>().Where<T>(wherelambda).ToJsonResult<IEnumerable<T>>();
        }

        //分页
        public IEnumerable<T> LoadPagerEntities<S>(int pageSize, int pageIndex, out int total,
            Expression<Func<T, bool>> whereLambda, bool isAsc, Expression<Func<T, S>> orderByLambda)
        {
            
            var tempData = db.Set<T>().Where<T>(whereLambda);

            total = tempData.Count();
            IEnumerable<T> result = null;
            //排序获取当前页的数据
            if (isAsc)
            {
                result = tempData.OrderBy<T, S>(orderByLambda).
                      Skip<T>(pageSize * (pageIndex - 1)).
                      Take<T>(pageSize).ToList();
            }
            else
            {
                result = tempData.OrderByDescending<T, S>(orderByLambda).
                     Skip<T>(pageSize * (pageIndex - 1)).
                     Take<T>(pageSize).ToList();
            }
            return result;
        }
    }
}
