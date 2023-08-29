using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoLayer.Dtos.BlogPostDtos
{
    public class AddTag
    {
        public int Id { get; set; }

        public string Tag { get; set; }

        public int BlogPostID { get; set; }
    }
}
