using BlogWebAPI.Context;
using BlogWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace BlogWebAPI.Controllers
{
    [RoutePrefix("api/[controller]")]
    public class UserController : ApiController
    {
        UserService userService = new UserService();
        public DatabaseContext _context = new DatabaseContext();
        public UserController() { }

        [HttpGet]
        [Authorize]
        public User GetUser(string email,string password)
        {
            User user = userService.GetUserByCredentials(email, password);   
            return user;
        }

        [ResponseType(typeof(User))]
        public IHttpActionResult Post(User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _context.Users.Add(user);
            _context.SaveChanges();
            return CreatedAtRoute("DefaultApi", new { id = user.Id }, user);
        }

    }
}
