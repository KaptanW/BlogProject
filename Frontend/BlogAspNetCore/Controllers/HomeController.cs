using BlogAspNetCore.Dtos;
using BlogAspNetCore.Models;
using DtoLayer.Dtos.BlogPostDtos;
using EntityLayer.Concrete;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using System.Drawing.Printing;
using System.Security.Claims;
using System.Text;
using X.PagedList;

namespace BlogAspNetCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpClientFactory _httpClientFactory;
        

        public HomeController(ILogger<HomeController> logger, IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int? page)
        {
            var pageNumber = page ?? 1; 
            var pageSize = 5; 
            string jwtToken = HttpContext.Session.GetString("JwtToken");
            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {jwtToken}");
            var responseMessage = await client.GetAsync("https://localhost:7216/api/BlogPost");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsondata = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<BlogPost>>(jsondata);
                
                return View(values.ToPagedList(pageNumber, pageSize));
            }
            
            return View();
        }


        [HttpGet]
        public async Task<IActionResult> SearchBlog(string search)
        {
            string jwtToken = HttpContext.Session.GetString("JwtToken");
            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {jwtToken}");
            var responseMessage = await client.GetAsync($"https://localhost:7216/api/BlogPost/BlogPostListWithSearch?search={search}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsondata = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<BlogPost>>(jsondata);

                return View(values);
            }

            return View();
        }
        
        [HttpGet]
        public async Task<IActionResult> UserPosts(int id)
        {
          
            string jwtToken = HttpContext.Session.GetString("JwtToken");
            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {jwtToken}");
            var responseMessage = await client.GetAsync($"https://localhost:7216/api/BlogPost/UserPosts/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsondata = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<BlogPost>>(jsondata);
                if(values != null)
                {

                ViewBag.UserName = values[0].AppUser.UserName;
                return View(values);
                }
            }

            return View();
        }


        [HttpGet]
        public async Task<IActionResult> BlogAPost()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> BlogAPost(CreateaBlog createaBlog)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            createaBlog.Author = User.Identity.Name;
            createaBlog.AppUserId = int.Parse(userId);
        
            string jwtToken = HttpContext.Session.GetString("JwtToken");
            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {jwtToken}");
            var jsondata = JsonConvert.SerializeObject(createaBlog);
            StringContent content = new StringContent(jsondata, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7216/api/BlogPost", content);
            if(responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> BlogDetails(int id)
        {

            string jwtToken = HttpContext.Session.GetString("JwtToken");
            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {jwtToken}");
            var responseMessage = await client.GetAsync($"https://localhost:7216/api/BlogPost/BlogWithMoreDetails/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsondata = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<BlogPost>(jsondata);

                return View(values);
            }
            return View();
        }
    }
}