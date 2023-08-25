using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class BlogPostComments
    {
        public int Id { get; set; }

        public string Comment { get; set; }

        public DateTime CreateDate { get; set; }


        public int BlogPostId { get; set; }
        public BlogPost BlogPost { get; set; }
    }
}
