using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BlogWebAPI.Models
{
    
    public class Comments
    {
        [Key]
        public int CommentId { get; set; }
        public string Description { get; set; }
        public int PostId { get; set; }
    }
}