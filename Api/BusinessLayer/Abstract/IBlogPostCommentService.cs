using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IBlogPostCommentService : IGenericService<BlogPostComments>
    {

        Task<List<BlogPostComments>> CommentsforBlog(int id);
    }
}
