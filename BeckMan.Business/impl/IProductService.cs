using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeckMan.Del;

namespace BeckMan.Business.impl
{
    public interface IProductService
    {
        void add(bec_Product product);

        List<bec_Product> pageList(bec_Product filter, int pageIndex, int pageSize);

        void update(bec_Product product);

        bec_Product Get(int id);
    }
}
