using AutoMapper;
using DtoLayer.Dtos.BlogPostCommentDtos;
using DtoLayer.Dtos.BlogPostDtos;
using EntityLayer.Concrete;

namespace BlogApi.Mapper
{
    public class AutoMapperConfig:Profile
    {
        public AutoMapperConfig()
        {

            CreateMap<BlogPostAdd, BlogPost>().ReverseMap();
            CreateMap<AddBlogPostCommentDto, BlogPostComments>().ReverseMap();
        }
    }
}
