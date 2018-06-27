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
        // Le service Confidentials avec email en parametre , et l'authorization avec token ( on a ajouté le mot clé authorize pour le controleur)
        [HttpGet]
        public bool confidentials(string email)
        {
            // Get le user correspendant au token envoyé et le comparer avec celui passé en parametres
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
