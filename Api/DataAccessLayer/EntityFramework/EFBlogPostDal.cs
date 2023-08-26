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
                var value = await context.Blogs.AsNoTracking().Include(x => x.blogPostComments).ToListAsync();
                return value;

            }
        }

        public async Task<List<BlogPost>> SearchBlog(string search)
        {
            using (var context = new Context())
            {
                var value = await context.Blogs.Where(x=>x.Name.Contains(search)).AsNoTracking().Include(x => x.blogPostComments).ToListAsync();
                return value;

            }
        }
    }
}
