using BlogWebAPI.Models;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace BlogWebAPI.Provider
{
    public class oAuthAppProvider:OAuthAuthorizationServerProvider
    {
       
        public override  Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            return Task.Factory.StartNew(() =>
            {

                var username = context.UserName;
                var password = context.Password;
                var userService = new UserService();
                User user = userService.GetUserByCredentials(username, password);
                if (user != null)
                {
                    var claims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.Name, user.Name),
                        new Claim("UserID", user.Id)
                    };
                    ClaimsIdentity oAuthIdentity = new ClaimsIdentity(claims, Startup.oAuthOptions.AuthenticationType);
                    context.Validated(new AuthenticationTicket(oAuthIdentity, new AuthenticationProperties() { }));
                }
                else
                {
                    context.SetError("invalid_grant", "Error");
                }

            });
            
        }
        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
           if(context.ClientId==null)
            {
                context.Validated();
            }
           return Task.FromResult<object>(null);
        }
    }
}