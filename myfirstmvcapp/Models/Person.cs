using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using myfirstmvcapp.StaticData;

namespace myfirstmvcapp.Models
{
    public class Person
    {
        public int Id { get; set; }
        // [MaxLength(20)]
        public string Name { get; set; }
        public string Department { get; set; }
        public decimal Years { get; set; }

        public static void UpdatePerson(int idToUpdate, Person newPerson)
        {
            var existingPerson = PersonData.People.FirstOrDefault(p => p.Id == idToUpdate);
            existingPerson.Name = newPerson.Name;
            existingPerson.Department = newPerson.Department;
            existingPerson.Years = newPerson.Years;
        }

        // public static void CreateNewPerson(Person newPerson)
        // {
        //     var existingPerson = PersonData.People.FirstOrDefault(p => p.Id == idToUpdate);
        //     existingPerson.Name = newPerson.Name;
        //     existingPerson.Department = newPerson.Department;
        //     existingPerson.Years = newPerson.Years;
        // }
        
    }
}

// Tags to limit data are like required/regex/maxlength/etc
