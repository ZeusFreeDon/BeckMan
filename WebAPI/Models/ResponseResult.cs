using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace WebAPI.Models
{
    public class ResponseResult<T> : HttpResponseMessage
    {
        public bool success;
        public String message;
        public T data;
        public String errorcode;
    }
}