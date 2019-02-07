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
    public class DepartmentController : Controller
    {
        public IActionResult DepartmentDetails(int? id)
        {
            if (!id.HasValue)
            {
                return NotFound();
            }

            //Looks for first thing that matches condition. If it doesn't find it creates null.
            var department = DepartmentData.Department.FirstOrDefault(p => p.Id == id.Value);

            if (department == null)
            {
                return NotFound();
            }

            return View(department);
        }

        public IActionResult EditDepartment(int? id)
        {
            if (!id.HasValue)
            {
                return NotFound();
            }

            var department = DepartmentData.Department.FirstOrDefault(p => p.Id == id.Value);

            if (department == null)
            {
                return NotFound();
            }

            return View(department);
        }

         public IActionResult AddDepartment()
        {
           return View();
        }

         public IActionResult DeleteDepartment(int? id)
        {
           return View();
        }

        public IActionResult DepartmentList()
        {
            var department = (from user in DepartmentData.Department
                          select new
                          {
                              Id = user.Id,
                              Name = user.Name
                          }).ToList().Select(p => new Department()

                          {
                              Id = p.Id,
                              Name = p.Name
                          });

            if (department == null)
            {
                return NotFound();
            }
            return View(department);
        }

        [HttpPost]
        public IActionResult EditDepartment(int id, [Bind("Id,Name")] Department department)
        {
            if (id != department.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                Department.UpdateDepartment(id, department);
                return RedirectToAction("DepartmentDetails", new { id = id });
            }

            return View(department);
        }

        [HttpPost]
        public IActionResult AddDepartment(Department department)
        {
            if (ModelState.IsValid)
            {
                DepartmentData.AddDepartment(department);
                return RedirectToAction("DepartmentList");
            }

            return View(department);
        }

        [HttpPost]
        public IActionResult DeleteDepartment(int id)
        {
            if (ModelState.IsValid)
            {
                DepartmentData.DeleteDepartment(id);
                return RedirectToAction("DepartmentList");
            }

            return View();
        }

    }
}