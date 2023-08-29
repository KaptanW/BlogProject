using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class BlogTagManager : IBlogTagService
    {
        private readonly IBlogTagDal blogPostDal;

        public BlogTagManager(IBlogTagDal blogPostDal)
        {
            this.blogPostDal = blogPostDal;
        }

        public async Task<List<PostTags>> BlogsWithComments()
        {
            var value = await blogPostDal.GetList();
            return value;
        }

        public async Task Delete(PostTags t)
        {
            await blogPostDal.Delete(t);
        }

        public async Task<PostTags> GetById(int id)
        {
            return await blogPostDal.GetById(id);
        }

        public async Task<List<PostTags>> GetList()
        {
            return await blogPostDal.GetList();
        }

        public async Task Insert(PostTags t)
        {
            await blogPostDal.Insert(t);
        }

        public async Task Update(PostTags t)
        {
            await blogPostDal.Update(t);
        }
    }
}
