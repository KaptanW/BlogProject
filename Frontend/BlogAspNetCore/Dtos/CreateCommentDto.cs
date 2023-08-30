using EntityLayer.Concrete;

namespace BlogAspNetCore.Dtos
{
    public class CreateCommentDto
    {
       

        public string Comment { get; set; }

        public DateTime CreateDate { get; set; }


        public int BlogPostId { get; set; }

       

        public int UserId { get; set; }

        
    }
}
