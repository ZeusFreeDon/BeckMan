using BeckMan.Business.Services;
using BeckMan.Del;
using WebAPI.Models;
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


        [Route("api/Product/listPage")]
        public PagingEntity<bec_Product> Get(int start, int limit)
        {
            return new PagingEntity<bec_Product> { total = productService.Total(), items = productService.Find(start, limit) };
        }

        [Route("api/Product/findList")]
        public PagingEntity<bec_Product> Get(string filter,int start, int limit)
        {
            if (string.IsNullOrEmpty(filter))
            {
                return Get(start, limit);
            }
            return new PagingEntity<bec_Product> { total = productService.Total(filter), items = productService.Find(filter, start, limit) };
        }

        [Route("api/Product/Get/{id}")]
        // GET: api/Product/5
        public bec_Product Get(int id)
        {
            return productService.Get(id);
        }

        [Route("api/Product/Post")]
        // POST: api/Product
        public bec_Product Post([FromBody]bec_Product product)
        {
            return productService.Add(product);
        }

        [Route("api/Product/Put")]
        // PUT: api/Product/5
        public void Put(int id, [FromBody]bec_Product product)
        {
            productService.Update(product);
        }

        [Route("api/Product/Delete")]
        // DELETE: api/Product/5
        public void Delete(int id)
        {
            productService.Delete(new List<int> { id });
        }        
    }
}
