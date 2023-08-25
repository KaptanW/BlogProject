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
    public class BlogPostCommentManager : IBlogPostCommentService
    {
        private readonly IBlogPostCommentsDal blogPostCommentsDal;

        public BlogPostCommentManager(IBlogPostCommentsDal blogPostCommentsDal)
        {
            this.blogPostCommentsDal = blogPostCommentsDal;
        }

        public async Task Delete(BlogPostComments t)
        {
            await blogPostCommentsDal.Delete(t);
        }

        public async Task<BlogPostComments> GetById(int id)
        {
            return await blogPostCommentsDal.GetById(id);
        }

        public async Task<List<BlogPostComments>> GetList()
        {
            return await blogPostCommentsDal.GetList();
        }

        public async Task Insert(BlogPostComments t)
        {
            await blogPostCommentsDal.Insert(t);
        }

        public async Task Update(BlogPostComments t)
        {
            await blogPostCommentsDal.Update(t);
        }
    }
}
