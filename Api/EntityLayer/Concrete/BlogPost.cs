using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class BlogPost
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Author { get; set; }

        public DateTime CreateDate { get; set; }

        public List<BlogPostComments> blogPostComments { get;}
    }
}
