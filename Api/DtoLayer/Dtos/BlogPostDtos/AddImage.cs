using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoLayer.Dtos.BlogPostDtos
{
    public  class AddImage
    {
        public int Id { get; set; }

        public string Image { get; set; }

        public int BlogPostID { get; set; }
    }
}
