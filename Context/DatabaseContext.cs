using BlogWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BlogWebAPI.Context
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("DefaultConnection") { }
       // public BlogContext(DbContextOptions<BlogContext> options) : base(options) { }

        public DbSet<BlogPost> BlogPosts { get; set; }

        public DbSet<Author> Authors { get; set; }
    }
}