using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BeckMan.Del;
using BeckMan.Business.Services;
using WebAPI.Models;


namespace WebAPI.Controllers
{
    public class AssInfomationController : ApiController
    {
        AssInfomationService aService = new AssInfomationService();

        public void Add([FromBody] bec_AssInformation entity) {
            aService.Add(entity, 1, 1);
        }
    }
}
