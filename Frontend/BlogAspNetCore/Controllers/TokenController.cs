using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NuGet.Common;
using System.Security.Claims;

namespace BlogAspNetCore.Controllers
{
    public class TokenController : Controller
    {

        private readonly IHttpClientFactory? _httpClientFactory;

        public TokenController(IHttpClientFactory? httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            if(User.Identity.IsAuthenticated)
            {
               
                
                var client = _httpClientFactory.CreateClient();
               
                if (User.IsInRole("Admin"))
                {
                    var responseMessage = await client.GetAsync($"https://localhost:7216/api/Token/GetTokenAdmin/{User.FindFirstValue(ClaimTypes.NameIdentifier)}");
                    if (responseMessage.IsSuccessStatusCode)
                    {
                        string token = await responseMessage.Content.ReadAsStringAsync();


                        HttpContext.Session.SetString("JwtToken", token);

                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    var responseMessage = await client.GetAsync($"https://localhost:7216/api/Token/GetToken/{User.FindFirstValue(ClaimTypes.NameIdentifier)}");
                    if (responseMessage.IsSuccessStatusCode)
                    {
                        string token = await responseMessage.Content.ReadAsStringAsync();


                        HttpContext.Session.SetString("JwtToken", token);

                        return RedirectToAction("Index", "Home");
                    }
                }
                
                
            }
            return View();
        }
    }
}
