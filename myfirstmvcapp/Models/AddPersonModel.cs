using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using myfirstmvcapp.StaticData;

namespace myfirstmvcapp.Models
{
    public class AddPersonModel : Person
    {
        public Person PersonInfo {get; set;}
        public List<Department> DepartmentList { get; set; }
    }
}