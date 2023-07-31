using BlogWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogWebAPI
{
    public class UserService
    {
        public User GetUserByCredentials(string email, string password)
        {
            User user = null;

            if (email != "email@domain.com" || password != "password")
            {
                return null;
            }
            user = new User()
            {
                Id = "1",
                Email = "mail2saru28@gmail.com",
                Password = "password",
                Name = "Sarvani",
            };
            if (user != null)
            {
                user.Password = string.Empty;
            }

            return user;


        }
    }
}