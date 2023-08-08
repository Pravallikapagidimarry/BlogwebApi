using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using BlogWebAPI.Context;
using BlogWebAPI.Models;

namespace BlogWebAPI.Controllers
{
    public class ResultsController : ApiController
    {
        private DatabaseContext db = new DatabaseContext();

        [HttpGet()]
        public IEnumerable<BlogInformation> GetResults()
        {
            int authorId = 1;
            var blogInformation = new List<BlogInformation>();
            var authorInfo = db.Authors.Where(x => x.AuthorId == authorId).FirstOrDefault();
            var userInfo = db.Users.Where(x => x.Id == authorInfo.UserId).FirstOrDefault();
            var list = db.BlogPosts.Where(x => x.AuthorId == authorId).ToList();
            foreach (var blogPost in list)
            {
          

                var comments = db.PostComments.Where(x => x.PostId == blogPost.BlogPostId).ToList();
                foreach (var comment in comments)
                {
                    var blogInfo = new BlogInformation();
                    blogInfo.BlogPostId = blogPost.BlogPostId;
                    blogInfo.Title = blogPost.Title;
                    blogInfo.Summary = blogPost.Summary;
                    blogInfo.Body = blogPost.Body;
                    blogInfo.User = userInfo.Name;
                    blogInfo.UserEmail = userInfo.Email;
                    blogInfo.RoleName = userInfo.RoleName;
                    blogInfo.Comments = comment.Description;
                    blogInformation.Add(blogInfo);
                }
            }
            return blogInformation;

        }


    }
}
