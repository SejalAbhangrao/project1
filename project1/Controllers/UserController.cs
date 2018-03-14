using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace project1.Controllers
{
    public class UserController : ApiController
    {
        [Route("api/user/createUser")]
        [HttpPost]
        public static void createUser()
        {

        }
    }
}