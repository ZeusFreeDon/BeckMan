using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeckMan.WebAPI.Models
{
    public class PagingEntity<T> 
    {
        public int total;
        public IEnumerable<T> items;
    }
}