using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoLayer.Dtos.BlogPostCommentDtos
{
    public class AddBlogPostCommentDto
    {
        public int Id { get; set; }

        public string Comment { get; set; }

        public DateTime CreateDate { get; set; }

        public int BlogPostId { get; set; }
    }
}
