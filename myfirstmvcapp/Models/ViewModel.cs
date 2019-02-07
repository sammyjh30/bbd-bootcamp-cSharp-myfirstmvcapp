using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using myfirstmvcapp.StaticData;

namespace myfirstmvcapp.Models
{
    public class ViewModel
    {
        public Department DepartmentInfo { get; set; }
        public List<Person> DepartmentPeople { get; set; }
    }
}