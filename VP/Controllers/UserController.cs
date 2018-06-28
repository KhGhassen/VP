using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using RE.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using VP.Models;

namespace VP.Controllers
{
    
    [Route("api/authenticate")]
    public class UserController : ApiController
    {
        private const string LocalLoginProvider = "Local";
        private ApplicationUserManager _userManager;
        //pour la validation du format mail
        RegexUtilities util = new RegexUtilities();
        public UserController()
        {

        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? Request.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
        // Le webService authenticate
        [HttpGet]
        public async Task<string> authenticate(string email, string password)
        {
            try
            {
                //Verifier l'intégrité des parametres
                if (string.IsNullOrEmpty(email) && string.IsNullOrEmpty(password))
                {
                    return "provide an email and a password";
                }
                //Vérifier le format du mail à l'aide d'un regex helper
                else if (!util.IsValidEmail(email))
                {
                    return "false";
                }
                else
                {

                    // creer l'utilisateur localement pour pouvoir génerer son Token à partir du mail et password
                    var user = new ApplicationUser() { UserName = email, Email = email };

                    IdentityResult result = await UserManager.CreateAsync(user, password).ConfigureAwait(false);

                    return "true";
                }
            }
            catch (Exception)
            {

                return "false";
            }

       
          

        }

        private async void create_identity(string email, string password)
        {
            var user = new ApplicationUser() { UserName = email, Email = email };

            IdentityResult result = await UserManager.CreateAsync(user, password);

        }
    }
}
