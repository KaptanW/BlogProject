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
using NuGet.Common;
using System.Diagnostics;
using System.Drawing.Printing;
using System.Net.Http;
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
        public async Task<IActionResult> Edit(int id)
        {
            string jwtToken = HttpContext.Session.GetString("JwtToken");
            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {jwtToken}");
            var responseMessage = await client.GetAsync($"https://localhost:7216/api/BlogPost/BlogWithMoreDetails/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsondata = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<EditAblog>(jsondata);
                return View(value);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditAblog editAblog)
        {
            editAblog.AppUserId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            editAblog.Author = "";
            string jwtToken = HttpContext.Session.GetString("JwtToken");
            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {jwtToken}");
            var jsondata = JsonConvert.SerializeObject(editAblog);
            StringContent content = new StringContent(jsondata, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7216/api/BlogPost", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return View("Index");
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
                HttpContext.Session.SetString("BlogId", values.Id.ToString());
                return View(values);
            }
            return View();
        }


        public async Task<IActionResult> Deleteblog(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7216/api/BlogPost/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

      


        [HttpGet]
        public PartialViewResult CommentAdd()
        {
            return PartialView();
        }

        [HttpPost]
        public async Task<IActionResult> CommentAdd(CreateComment createaComment)
        {
            string jwtToken = HttpContext.Session.GetString("JwtToken");
            string BlogId = HttpContext.Session.GetString("BlogId");
            createaComment.BlogPostId = int.Parse(BlogId);
            createaComment.UserId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {jwtToken}");
            var jsondata = JsonConvert.SerializeObject(createaComment);
            StringContent content = new StringContent(jsondata, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7216/api/BlogPostComment", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> DeleteComment(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7216/api/BlogPostComment/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}