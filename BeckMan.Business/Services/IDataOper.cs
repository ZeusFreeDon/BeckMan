using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeckMan.Business.Services
{
    public interface IDataOper<T>
    {
        void Save(T t);

        void Update(T t);

        List<T> findList(T filter, int pageIndex, int pageSize);

        List<T> findList(T filter);

        T Get(int id);
    }
}
