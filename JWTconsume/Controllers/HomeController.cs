using JWTconsume.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Cryptography.Xml;
using System.Text;

namespace JWTconsume.Controllers
{
    public class HomeController : Controller
    {
        string baseurl = "https://localhost:7261/api/";

        private readonly IHttpContextAccessor context;

        public HomeController(IHttpContextAccessor httpContextAccessor)
        {
            context= httpContextAccessor;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Home()
        {
            return View("Home");
        }

        public async Task<IActionResult> Insert(Login? Login)
        {
            using (var client = new HttpClient())
            {
               
                client.BaseAddress = new Uri(baseurl);
                string data = JsonConvert.SerializeObject(Login);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                if (Login?.username != null && Login?.password != null)
                {
                    HttpResponseMessage responseMessage = await client.PostAsync("Login", content);
                    if (responseMessage.IsSuccessStatusCode)
                    {
                        string result = responseMessage.Content.ReadAsStringAsync().Result;
                        Login jsonObject = JsonConvert.DeserializeObject<Login>(result);
                        string token = jsonObject.token.ToString();
                        CurrentUser user = new CurrentUser();
                        user = jsonObject.currentUser;
                        //var ragistered = await GetUser(token);

                        //save session
                        string StringUser = JsonConvert.SerializeObject(user);
                        context.HttpContext.Session.SetString("StringUser", StringUser);


                        return RedirectToAction("Index", "Demosession");
                    }
                    else
                    {
                        Console.WriteLine("Error in api");
                    }
                }
                else
                {
                    Console.WriteLine("Error in login");
                }
                return View("Home");
            }
        }


        //authenticate

        public async Task<Ragistered> GetUser(string token)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseurl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage responseMessage =await client.GetAsync("User/Admin");
                if (responseMessage.IsSuccessStatusCode)
                {
                    string result = responseMessage.Content.ReadAsStringAsync().Result;
                    Responnse jsonObject = JsonConvert.DeserializeObject<Responnse>(result);
                    var dataOfObject = jsonObject.data;
                    return dataOfObject;
                }
                else
                {
                    Console.WriteLine("Error in api");
                }
                return null;
            }
        }

    }
}