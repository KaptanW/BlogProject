﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class BlogPost
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Author { get; set; }

        public int AppUserId { get; set; }

        public AppUser AppUser { get; set; }


        public DateTime CreateDate { get; set; } = DateTime.Now;

        public List<BlogPostComments>? blogPostComments { get; set; }

        public List<PostTags>? postTags { get; set; }

        public List<BlogPostImages>? BlogPostImages { get; set; }
    }
}
