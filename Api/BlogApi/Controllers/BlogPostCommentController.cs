using AutoMapper;
using BusinessLayer.Abstract;
using DtoLayer.Dtos.BlogPostCommentDtos;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BlogApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogPostCommentController : ControllerBase
    {
        private readonly IBlogPostCommentService _BlogPostCommentService;

        private readonly IMapper mapper;

        public BlogPostCommentController(IBlogPostCommentService BlogPostCommentPostService, IMapper mapper)
        {
            this._BlogPostCommentService = BlogPostCommentPostService;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> BlogPostCommentList()
        {
            var values = await _BlogPostCommentService.GetList();
            var json = JsonConvert.SerializeObject(values, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return Ok(json);
        }

        [HttpPost]
        public async Task<IActionResult> AddBlogPostComment(AddBlogPostCommentDto addBlogPostCommentDto)
        {
            var values = mapper.Map<BlogPostComments>(addBlogPostCommentDto);
            await _BlogPostCommentService.Insert(values);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBlogPostComment(int id)
        {
            var values = await _BlogPostCommentService.GetById(id);


            await _BlogPostCommentService.Delete(values);


            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBlogPostComment(AddBlogPostCommentDto addBlogPostCommentDto)
        {
            var values = mapper.Map<BlogPostComments>(addBlogPostCommentDto);
            await _BlogPostCommentService.Update(values);
            return Ok();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBlogPostComment(int id)
        {
            var value = await _BlogPostCommentService.GetById(id);
            return Ok(value);
        }
    }
}
