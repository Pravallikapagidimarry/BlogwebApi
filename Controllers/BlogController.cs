using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using BlogWebAPI.Models;

using System.Web.Http;
using BlogWebAPI.Context;
using System.Web.Http.Description;
using System.Data.Entity.Infrastructure;
using System.Data.Entity;
using System.Net;

namespace BlogApi.Controllers
{
    [RoutePrefix("api/[controller]")]
    public class PostsController : ApiController
    {
        public DatabaseContext _context = new DatabaseContext();
        public PostsController()
        {
           

        }

        // GET: api/blogs
        public IEnumerable<BlogPost> Get()
        {
            return _context.BlogPosts;
        }

        // GET: api/blogs/5
        [ResponseType(typeof(BlogPost))]
        public IHttpActionResult GetBlog(int id)
        {
            BlogPost blogPost = _context.BlogPosts.FirstOrDefault(post => post.BlogPostId == id);

            if (blogPost == null)
            {
                return NotFound();
            }
            return Ok(blogPost);
        }

        // POST: api/blogs
       
        [ResponseType(typeof(BlogPost))]
        public IHttpActionResult Post(BlogPost blogPost)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _context.BlogPosts.Add(blogPost);
            _context.SaveChanges();
            return CreatedAtRoute("DefaultApi", new { id = blogPost.BlogPostId }, blogPost);
        }



        // PUT: api/Customers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCustomer(int id, BlogPost blogPost)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != blogPost.BlogPostId)
            {
                return BadRequest();
            }
            _context.Entry(blogPost).State = EntityState.Modified;
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BlogExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return StatusCode(HttpStatusCode.NoContent);
        }
        // DELETE: api/Customers/5
        [ResponseType(typeof(BlogPost))]
        public IHttpActionResult DeleteCustomer(int id)
        {
            BlogPost customer = _context.BlogPosts.Find(id);
            if (customer == null)
            {
                return NotFound();
            }
            _context.BlogPosts.Remove(customer);
            _context.SaveChanges();
            return Ok(customer);
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }
        private bool BlogExists(int id)
        {
            return _context.BlogPosts.Count(e => e.BlogPostId == id) > 0;
        }
    }
}