using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace WebAPI.Models
{
    public class ApiResult<T> 
    {
        
        public int totalCount = 0;
        public T result;
        public List<T> results;
        public int resultCode = 0;
        public string message = "success";

    }
}