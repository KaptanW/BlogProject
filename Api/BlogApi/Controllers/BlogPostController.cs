using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BlogApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogPostController : ControllerBase
    {
        private readonly IBlogPostService blogPostService;

        public BlogPostController(IBlogPostService blogPostService)
        {
            this.blogPostService = blogPostService;
        }

        // GET: api/<BlogPostController>
        [HttpGet]
        public async Task<IActionResult>  GetPosts()
        {
           var values = await blogPostService.GetList();
            return Ok(values);
        }

        // GET api/<BlogPostController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<BlogPostController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<BlogPostController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<BlogPostController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
