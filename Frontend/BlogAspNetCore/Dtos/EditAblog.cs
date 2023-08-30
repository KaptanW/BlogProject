using DtoLayer.Dtos.BlogPostDtos;

namespace BlogAspNetCore.Dtos
{
    public class EditAblog
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Author { get; set; }

        public int AppUserId { get; set; }


        public DateTime CreateDate { get; set; } = DateTime.Now;

        public List<AddImage> Images { get; set; }
        public List<AddTag> Tags { get; set; }

    
}
}
