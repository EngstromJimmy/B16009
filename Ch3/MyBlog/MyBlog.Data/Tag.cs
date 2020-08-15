﻿using System;
using System.Collections.Generic;

namespace MyBlog.Data
{
    public class Tag
    {
        public int Id {get; set; }
        public string Name { get; set; }
        public virtual ICollection<BlogPost> BlogPosts { get; set; }
    }
}
