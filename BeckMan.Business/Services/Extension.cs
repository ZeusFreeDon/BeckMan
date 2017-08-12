using BeckMan.Del;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeckMan.Business.Services
{
    public static class Extension
    {
        public static T ToJsonResult<T>(this T obj) 
        {
            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.MissingMemberHandling = MissingMemberHandling.Ignore;
            settings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            string result = JsonConvert.SerializeObject(obj, settings);
            obj = (T)JsonConvert.DeserializeObject(result, typeof(T));
            return obj;
        }
    }
}