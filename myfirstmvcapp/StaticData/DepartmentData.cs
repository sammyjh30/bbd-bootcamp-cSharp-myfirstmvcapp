using System;
using System.Collections.Generic;
using System.Linq;
using myfirstmvcapp.Models;

namespace myfirstmvcapp.StaticData
{
    public class DepartmentData
    {
        public static List<Department> Department
        {
            get
            {
                return listOfDepartments;
            }
        }

        private static List<Department> listOfDepartments = new List<Department>()
        {
            new Department() { Id = 1, Name = "ATC"},
            new Department() { Id = 2, Name = "Nedbank"},
            new Department() { Id = 3, Name = "Absa"},
            new Department() { Id = 4, Name = "Standard Bank"}
        };

        public static void AddDepartment(Department newDepartment)
        {
            var ID = listOfDepartments[listOfDepartments.Count - 1].Id + 1;
            listOfDepartments.Add(new Department() {Id = ID, Name = newDepartment.Name});
        }

        public static void DeleteDepartment(int id)
        {
            var departmentToRemove = listOfDepartments.Single(r => r.Id == id);
            listOfDepartments.Remove(departmentToRemove);
        }
    }
}