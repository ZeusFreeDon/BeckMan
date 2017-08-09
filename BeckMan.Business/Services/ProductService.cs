using BeckMan.Business.impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeckMan.Del;
using System.Linq.Expressions;

namespace BeckMan.Business.Services
{
    public class ProductService : IProductService
    {
        BeckManEntities DBContext;
        public ProductService()
        {
            DBContext = new BeckManEntities();
        }
        public void add(bec_Product product)
        {
            DBContext.bec_ProductSet.Add(product);
            DBContext.SaveChanges();
        }

        public bec_Product Get(int id)
        {
            return DBContext.bec_ProductSet.Find(id);
        }

        public List<bec_Product> pageList(bec_Product filter, int pageIndex, int pageSize)
        {
            Expression<Func<bec_Product, bool>> express = null;
            if (!string.IsNullOrEmpty(filter.PName))
            {
                express.Or(p => p.PName.Contains(filter.PName));
            }
            if (!string.IsNullOrEmpty(filter.Year))
            {
                express.Or(p => p.Year == filter.Year);
            }
            return DBContext.bec_ProductSet.Where(express).OrderBy(p => p.SequeNo).ToList(); ;
        }

        public void update(bec_Product product)
        {
            DBContext.Entry(product).State = System.Data.Entity.EntityState.Modified;
            DBContext.SaveChanges();
        }
    }
}
