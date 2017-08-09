using BeckMan.Del;
using BeckMan.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BeckMan.WebAPI.Controllers
{
    public class ProductController : ApiController
    {
        BeckManDBContext dbContext = new BeckManDBContext();

        // GET: api/Product
        public IEnumerable<Product> Get()
        {
            return dbContext.Product;
        }

        public PagingEntity<Product> Get(int start, int limit)
        {
            int count = dbContext.Product.Count();
            var products= dbContext.Product.OrderBy(p=>p.SequnNo).Skip(start).Take(limit);
            return new PagingEntity<Product> { total=count, items=products };
        }

        public PagingEntity<Product> Get(string filter,int start, int limit)
        {
            if (string.IsNullOrEmpty(filter.Trim())){
                return Get(start, limit);
            }
            int count = dbContext.Product.Where(p => p.Name.IndexOf(filter) >= 0).Count();
            var products = dbContext.Product.Where(p=>p.Name.IndexOf(filter) >=0).OrderBy(p => p.SequnNo).Skip(start).Take(limit);
            return new PagingEntity<Product> { total = count, items = products };
        }

        // GET: api/Product/5
        public Product Get(int id)
        {
            return dbContext.Product.FirstOrDefault(p => p.ID == id);
        }

        // POST: api/Product
        public void Post([FromBody]Product product)
        {
            dbContext.Product.Add(product);
            dbContext.SaveChanges();
        }

        // PUT: api/Product/5
        public void Put(int id, [FromBody]Product product)
        {
            var item = dbContext.Product.FirstOrDefault(p => p.ID == id);
            item.Name = product.Name;
            item.Remark = product.Remark;
            item.Year = product.Year;
            item.SequnNo = product.SequnNo;
            dbContext.SaveChanges();
        }

        // DELETE: api/Product/5
        public void Delete(int id)
        {
            dbContext.Product.Remove(dbContext.Product.FirstOrDefault(p => p.ID == id));
            dbContext.SaveChanges();
        }

        public IEnumerable<Product> Find(Product filter,string order,int from,int limit) {
          
            return null;
        }
    }
}
