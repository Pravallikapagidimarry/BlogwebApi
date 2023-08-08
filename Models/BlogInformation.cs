using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogWebAPI.Models
{
    public class BlogInformation
    {
        public int BlogPostId { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public string Body { get; set; }
        public string User { get; set; }
        public string UserEmail { get; set; }
        public string Comments { get; set; }
        public string RoleName { get; set; }
        
    }
}