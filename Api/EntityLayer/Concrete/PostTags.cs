using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class PostTags
    {
        public int Id { get; set; }

        public string Tag { get; set; }

        public BlogPost BlogPost { get; set; }
    }
}
