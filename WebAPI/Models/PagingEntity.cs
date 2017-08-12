using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace WebAPI.Models
{
    public class PagingEntity<T>
    {
        public int total;
        public IEnumerable<T> items;
    }
}