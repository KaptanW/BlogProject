using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EFBlogPostDal : GenericRepository<BlogPost>, IBlogPostDal
    {
        public EFBlogPostDal(Context context) : base(context)
        {
        }

        public async Task<List<BlogPost>> BlogsWithComments()
        {
            using (var context = new Context())
            {
                var value = await context.Blogs
               .Include(x => x.blogPostComments)
                 .Include(x => x.AppUser)
                 .Include(x => x.BlogPostImages)
                   .Include(x => x.postTags)
                  .OrderByDescending(x => x.CreateDate)
                .ToListAsync();
                return value;

            }
        }

        public async Task<BlogPost> BlogWithMoreDetails(int id)
        {

            using (var context = new Context())
            {
                var value = await context.Blogs.AsNoTracking().Include(x => x.blogPostComments).ThenInclude(y=>y.User).Include(x => x.AppUser).Include(x => x.BlogPostImages).Include(x => x.postTags).OrderByDescending(x => x.CreateDate).Where(x=>x.Id == id).FirstOrDefaultAsync();
                return value;

            }
        }

        public async Task<List<BlogPost>> SearchBlog(string search)
        {
            using (var context = new Context())
            {
                var value = await context.Blogs.Where(x=>x.Name.Contains(search)).AsNoTracking().Include(x => x.AppUser).Include(x => x.blogPostComments).OrderByDescending(x=>x.CreateDate).ToListAsync();
                return value;

            }
        }

        public async Task<List<BlogPost>> UserBlogPosts(int id)
        {
            using (var context = new Context())
            {
                var value = await context.Blogs.Where(x => x.AppUserId == id).Include(x=>x.BlogPostImages).Include(x=>x.AppUser).Include(x=>x.postTags).AsNoTracking().ToListAsync();
                return value;
            }
        }
    }
}
