using BlogApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        [HttpGet("[action]/{id}")]
        public IActionResult GetToken(string id) 
        {
            return Created("", new CreateToken().TokenCreate(id));
        }


        [HttpGet("[action]/{id}")]
        public IActionResult GetTokenAdmin(string id) 
        {
            return Created("", new CreateToken().TokenCreateAdmin(id));
        }

        [Authorize]
        [HttpGet("[action]")]
        public IActionResult Test()
        {
            return Ok("Oldu.");
        }

    }
}
