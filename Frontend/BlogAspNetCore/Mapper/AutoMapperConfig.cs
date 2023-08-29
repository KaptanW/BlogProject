using AutoMapper;
using BlogAspNetCore.Dtos;
using EntityLayer.Concrete;

namespace BlogAspNetCore.Mapper
{
    public class AutoMapperConfig:Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<RegisterDto, AppUser>().ReverseMap();
            CreateMap<LoginDto, AppUser>().ReverseMap();


            CreateMap<CreateaBlog, BlogPost>().ReverseMap();
        }
    }
}
