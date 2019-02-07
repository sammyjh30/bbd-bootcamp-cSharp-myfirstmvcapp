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

            //Looks for first thing that matches condition. If it doesn't find it creates null.
            var person = PersonData.People.FirstOrDefault(p => p.Id == id.Value);

            if (person == null)
            {
                return NotFound();
            }

            return View(person);
        }

         public IActionResult Edit(int? id)
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

        [HttpPost]
        public IActionResult Edit(int id, [Bind("Id,Name,Department,Years")] Person person)
        {
            if (id != person.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                Person.UpdatePerson(id, person);
                return RedirectToAction("Details", new { id = id });
            }

            return View(person);
        }

    }
}