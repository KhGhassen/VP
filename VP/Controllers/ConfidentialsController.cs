using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace VP.Controllers
{
    [Authorize]
    [Route("api/confidentials")]
    public class ConfidentialsController : ApiController
    {
        public ConfidentialsController()
        {

        }

        [HttpGet]
        public bool confidentials(string email)
        {
            var user = User.Identity.Name;
            int comparison = String.Compare(user, email, ignoreCase: true);
            if (comparison != 0)
            {
                return false;
            }
            else
            {
                return true;
            }
              
           

        }
    }
}
