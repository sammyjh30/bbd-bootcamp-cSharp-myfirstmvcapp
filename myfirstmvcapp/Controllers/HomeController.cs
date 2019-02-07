using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using myfirstmvcapp.Models;
using System.Text.Encodings.Web;
using Microsoft.Extensions.Caching.Memory;

namespace myfirstmvcapp.Controllers
{
    public class HomeController : Controller
    {

        //Creating a constructor
        private IMemoryCache _cache;

        public HomeController(IMemoryCache memoryCache)
        {
            this._cache = memoryCache;
            // _cache = memoryCache;
        }

        public IActionResult Index()
        {
            Person myVar;

            if (!_cache.TryGetValue<Person>("something", out myVar))
            {
                Console.WriteLine("User does not exists");
                _cache.Set("something", new Person() { Id = 13, Name = "Luke Skywalker", Department = "Death Star", Years = 1000 });
                // Nest time we load the page, the get should succeed
                // Be careful what you put inside, not data that changes a lot.
                // You can control time, etc. but rather put static info
            }
            else{
                Console.WriteLine("User exists");
            }
            // Whatever you get must be a string, so it will cast for you:
            // _cache.Get<string>
            // To set: I want to set this key to something:
            //_cache.Set()


            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public string SayHi(string name, string department = "Unknown")
        {
            return HtmlEncoder.Default.Encode($"Hello {name} from {department}");
        }

        public string SayHi2(int id, string name = "Gery")
        {
            return HtmlEncoder.Default.Encode($"{id}. hi {name}!");
        }

        public IActionResult SayHiAgain(string name, int id = 1)
        {
            ViewData["Message"] = "Hello " + name;
            ViewData["ID"] = id;

            return View();
        }
    }
}
