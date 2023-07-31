using BlogWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BlogWebAPI.Controllers
{
    public class UserController : ApiController
    {
        UserService userService = new UserService();

        public UserController() { }

        [HttpGet]
        [Authorize]
        public User GetUser(string email,string password)
        {
            User user = userService.GetUserByCredentials(email, password);   
            return user;
        }
    }
}
