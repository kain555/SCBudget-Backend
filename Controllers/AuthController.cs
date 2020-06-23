using DBAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace BudgetAPI.Controllers
{   
    public class AuthController : ApiController
    {
        [HttpPost]
        public IHttpActionResult Login()
        {

            return Ok();
        }

        //[AllowAnonymous]
        //public string Get(string username, string password)
        //{
        //    if (CheckUser(username, password))
        //    {
        //        return JwtManager.GenerateToken(username);
        //    }

        //    throw new HttpResponseException(HttpStatusCode.Unauthorized);
        //}

        //public bool CheckUser(string username, string password)
        //{
        //    return true;
        //}
    }
}