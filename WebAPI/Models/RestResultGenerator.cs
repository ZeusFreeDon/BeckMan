using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class RestResultGenerator
    {
        public static ResponseResult<T> CreateResult<T>(T data, string message) {
            ResponseResult<T> result = new Models.ResponseResult<T>();
            result.data = data;
            result.success = true;
            result.message = message;
            return result;
        }
    }
}