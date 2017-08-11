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
    public class ProductService
    {
        BeckManEntities DBContext;
        public ProductService()
        {
            DBContext = new BeckManEntities();
        }

        public int Total()
        {
            return DBContext.bec_ProductSet.Count();
        }

        public int Total(string namefilter)
        {
            return DBContext.bec_ProductSet.Where(p => p.Name.Contains(namefilter)).Count() ;
        }

        public bec_Product Add(bec_Product product)
        {
            DBContext.bec_ProductSet.Add(product);
            DBContext.SaveChanges();
            return product;
        }

        public bec_Product Get(int id)
        {
            return DBContext.bec_ProductSet.Find(id);
        }

        public List<bec_Product> Find(int start, int limit)
        {
            return DBContext.bec_ProductSet.OrderBy(p => p.SequeNo).Skip(start).Take(limit).ToList(); ;
        }

        public List<bec_Product> Find(string namefilter, int start, int limit)
        {
            return DBContext.bec_ProductSet.Where(p=>p.Name.Contains(namefilter)).OrderBy(p => p.SequeNo).Skip(start).Take(limit).ToList(); ;
        }

        public void Update(bec_Product product)
        {
            DBContext.Entry(product).State = System.Data.Entity.EntityState.Modified;
            DBContext.SaveChanges();
        }

        public void Delete(List<int> idList)
        {
            var sql = "delete bec_ProductSet where id in (";
            string idString = "";
            foreach (int id in idList)
            {
                idString += id.ToString() + ",";
            }
            idString = idString.TrimEnd(',');
            sql += idString + ")";
            DBContext.Database.ExecuteSqlCommand(sql);
        }
    }
}
