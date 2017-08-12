using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class PagingEntity<T>
    {
        public int total;
        public IEnumerable<T> items;
    }
}