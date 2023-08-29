using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class BlogPostManager : IBlogPostService
    {
        private readonly IBlogPostDal blogPostDal;

        public BlogPostManager(IBlogPostDal blogPostDal)
        {
            this.blogPostDal = blogPostDal;
        }

        public async Task<List<BlogPost>> BlogsWithComments()
        {
            var value = await blogPostDal.BlogsWithComments();
            return value;
        }

        public async Task<BlogPost> BlogWithMoreDetails(int id)
        {
            var value = await blogPostDal.BlogWithMoreDetails(id);
            return value;
        }

        public async Task Delete(BlogPost t)
        {
            await blogPostDal.Delete(t);
        }

        public async Task<BlogPost> GetById(int id)
        {
            return await blogPostDal.GetById(id);
        }

        public async Task<List<BlogPost>> GetList()
        {
            return await blogPostDal.GetList();
        }

        public async Task Insert(BlogPost t)
        {
            await blogPostDal.Insert(t);
        }

        public async Task<List<BlogPost>> SearchBlog(string search)
        {
            return await blogPostDal.SearchBlog(search);
        }

        public async Task Update(BlogPost t)
        {
            await blogPostDal.Update(t);
        }

        public async Task<List<BlogPost>> UserBlogPosts(int id)
        {
            return await blogPostDal.UserBlogPosts(id);
        }
    }
}
