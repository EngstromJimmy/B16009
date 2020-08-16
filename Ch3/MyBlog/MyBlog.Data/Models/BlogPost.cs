using System;
using System.Collections.Generic;

namespace MyBlog.Data.Models
{
    public class BlogPost
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime PublishDate { get; set; }
        public Category Category { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }
    }
}
