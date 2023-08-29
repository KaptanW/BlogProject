using AutoMapper;
using BusinessLayer.Abstract;
using DtoLayer.Dtos.BlogPostDtos;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BlogPostApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogPostController : ControllerBase
    {
        private readonly IBlogPostService _BlogPostService;

        private readonly IMapper mapper;

        public BlogPostController(IBlogPostService BlogPostPostService,IMapper mapper)
        {
            this._BlogPostService = BlogPostPostService;
            this.mapper = mapper;
        }

        
        [HttpGet]
        public async Task<IActionResult> BlogPostList()
        {
            var values = await _BlogPostService.BlogsWithComments();
            var json = JsonConvert.SerializeObject(values,Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return Ok(json);
        }
        
        
        [HttpGet("BlogPostListWithSearch")]
        public async Task<IActionResult> BlogPostListWithSearch(string search)
        {
            var values = await _BlogPostService.SearchBlog(search);
            var json = JsonConvert.SerializeObject(values,Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return Ok(json);
        }

        [HttpGet("UserPosts/{id}")]
        public async Task<IActionResult> UserPosts(int id)
        {
            var values = await _BlogPostService.UserBlogPosts(id);
            var json = JsonConvert.SerializeObject(values,Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return Ok(json);
        }
        
        [HttpGet("BlogWithMoreDetails/{id}")]
        public async Task<IActionResult> BlogWithMoreDetails(int id)
        {
            var values = await _BlogPostService.BlogWithMoreDetails(id);
            var json = JsonConvert.SerializeObject(values,Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return Ok(json);
        }

        [HttpPost]
        public async Task<IActionResult> AddBlogPost(BlogPostAdd BlogPost)
        {
            var values = mapper.Map<BlogPost>(BlogPost);
            values.BlogPostImages = new List<BlogPostImages>();
            values.postTags = new List<PostTags>();
            List<AddImage> Images = BlogPost.Images;
            List<AddTag> Tags = BlogPost.Tags;
            for (int i = 0; i < Images.Count; i++)
            {
                // BlogPostImages koleksiyonuna yeni BlogPostImage ekleyin
                values.BlogPostImages.Add(new BlogPostImages
                {
                    Image = Images[i].Image
                });
            }

            for (int i = 0; i < Tags.Count; i++)
            {
                // BlogPostImages koleksiyonuna yeni BlogPostImage ekleyin
                values.postTags.Add(new PostTags
                {
                    Tag = Tags[i].Tag
                });
            }

            await _BlogPostService.Insert(values);

            return Ok(values);



        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBlogPost(int id)
        {
            var values = await _BlogPostService.GetById(id);


            await _BlogPostService.Delete(values);


            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBlogPost(BlogPostAdd BlogPost)
        {
            var values = mapper.Map<BlogPost>(BlogPost);
            await _BlogPostService.Update(values);
            return Ok();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBlogPost(int id)
        {
            var value = await _BlogPostService.GetById(id);
            return Ok(value);
        }
    }
}
