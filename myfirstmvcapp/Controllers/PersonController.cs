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
            // PersonInfo

            var person = PersonData.People.FirstOrDefault(p => p.Id == id.Value);

            if (person == null)
            {
                return NotFound();
            }
            var department = DepartmentData.Department;
            var model = new AddPersonModel();
            if (department != null)
            {
                model.DepartmentList = department;
            }
            if (person != null)
            {
                model.PersonInfo = person;
            }
            return View(model);
        }

         public IActionResult Add()
        {
            var department = DepartmentData.Department;
            var model = new AddPersonModel();

            if (department != null)
            {
                model.DepartmentList = department;
            }


            return View(model);
        //    return View();/
        }

         public IActionResult Delete(int? id)
        {
           return View();
        }

        public IActionResult List()
        {
            var person = (from user in PersonData.People
                          select new
                          {
                              Id = user.Id,
                              Name = user.Name,
                              Department = user.Department,
                              Years = user.Years
                          }).ToList().Select(p => new Person()

                          {
                              Id = p.Id,
                              Name = p.Name,
                              Department = p.Department,
                              Years = p.Years
                          });

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

        [HttpPost]
        public IActionResult Add(Person person)
        {
            if (ModelState.IsValid)
            {
                PersonData.AddPerson(person);
                return RedirectToAction("List");
            }

            return View(person);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            if (ModelState.IsValid)
            {
                PersonData.DeletePerson(id);
                return RedirectToAction("List");
            }

            return View();
        }

    }
}