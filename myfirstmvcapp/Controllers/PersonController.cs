using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using myfirstmvcapp.Models;
using System.Text.Encodings.Web;
using myfirstmvcapp.StaticData;

namespace myfirstmvcapp.Controllers
{
    public class PersonController : Controller
    {
        public IActionResult Details(int? id)
        {
            if (!id.HasValue)
            {
                return NotFound();
            }

            var person = PersonData.People.FirstOrDefault(p => p.Id == id.Value);

            if (person == null)
            {
                return NotFound();
            }

            return View(person);
        }
    }
}