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
        bec_Product Add(bec_Product product);

        List<bec_Product> Find(bec_Product filter, int pageIndex, int pageSize);

        void Update(bec_Product product);

        bec_Product Get(int id);
    }
}
