using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class ExceptionHelp
    {
        public static HttpResponseMessage Execute<T>(Func<T> func,HttpRequestMessage request) {
            HttpResponseMessage message;
            try
            {
                T enity = func();
                message = request.CreateResponse<T>(HttpStatusCode.OK, enity);
            }
            catch (Exception ex)
            {
                message = request.CreateResponse(HttpStatusCode.ExpectationFailed, ex.Message);
            }
            return message;
        }
    }
}