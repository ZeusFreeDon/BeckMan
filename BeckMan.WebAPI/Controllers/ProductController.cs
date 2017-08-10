using BeckMan.Business.Services;
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
      
        ProductService productService = new ProductService();


        public PagingEntity<bec_Product> Get(int start, int limit)
        {
            return new PagingEntity<bec_Product> { total = productService.Total(), items = productService.Find(null, start, limit) };
        }

        public PagingEntity<bec_Product> Get(string filter,int start, int limit)
        {
            return Get(start, limit);
        }

        // GET: api/Product/5
        public bec_Product Get(int id)
        {
            return productService.Get(id);
        }

        // POST: api/Product
        public bec_Product Post([FromBody]bec_Product product)
        {
            return productService.Add(product);
        }

        // PUT: api/Product/5
        public void Put(int id, [FromBody]bec_Product product)
        {
            productService.Update(product);
        }

        // DELETE: api/Product/5
        public void Delete(int id)
        {
            productService.Delete(new List<int> { id });
        }

        public IEnumerable<Product> Find(Product filter,string order,int from,int limit) {
          
            return null;
        }
    }
}
