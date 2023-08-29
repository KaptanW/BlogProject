using DtoLayer.Dtos.BlogPostDtos;
using EntityLayer.Concrete;

namespace BlogAspNetCore.Dtos
{
    public class CreateaBlog
    {

        public string Name { get; set; }

        public string Description { get; set; }

        public string Author { get; set; }

        public int AppUserId { get; set; }


        public DateTime CreateDate { get; set; } = DateTime.Now;

        public List<AddImage> Images { get; set; }
        public List<AddTag> Tags { get; set; }


    }
}
