using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using myfirstmvcapp.Models;
using System.Text.Encodings.Web;

namespace myfirstmvcapp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
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

        public IActionResult SayHiAgain(string name, int id = 1)
        {
            ViewData["Message"] = "Hello " + name;
            ViewData["ID"] = id;

            return View();
        }
    }
}
