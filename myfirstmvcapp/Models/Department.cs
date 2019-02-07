using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using myfirstmvcapp.StaticData;

namespace myfirstmvcapp.Models
{
    public class Department
    {
        public int Id { get; set; }
        // [MaxLength(20)]
        public string Name { get; set; }

        public static void UpdateDepartment(int idToUpdate, Department newDepartment)
        {
            var existingDepartment = DepartmentData.Department.FirstOrDefault(p => p.Id == idToUpdate);
            existingDepartment.Name = newDepartment.Name;
        }
        
    }
}

// Tags to limit data are like required/regex/maxlength/etc
