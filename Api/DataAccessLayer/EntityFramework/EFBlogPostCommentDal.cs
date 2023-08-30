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
    public class EFBlogPostCommentDal : GenericRepository<BlogPostComments>, IBlogPostCommentsDal
    {
        public EFBlogPostCommentDal(Context context) : base(context)
        {
        }

        public async Task<List<BlogPostComments>> CommentsforBlog(int id)
        {
            using (var context = new Context())
            {
                
                var result = await context.BlogsComments.Where(x=>x.BlogPostId == id).Include(x=>x.User).ToListAsync();
                    return result;
            }
        }
    }
}
