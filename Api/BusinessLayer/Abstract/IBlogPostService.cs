﻿using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IBlogPostService : IGenericService<BlogPost>
    {
        Task<List<BlogPost>> BlogsWithComments();
        Task<List<BlogPost>> SearchBlog(string search);

        Task<List<BlogPost>> UserBlogPosts(int id);
        Task<BlogPost> BlogWithMoreDetails(int id);
    }
}
