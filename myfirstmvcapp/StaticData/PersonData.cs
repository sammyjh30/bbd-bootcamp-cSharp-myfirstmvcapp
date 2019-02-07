using System;
using System.Collections.Generic;
using System.Linq;
using myfirstmvcapp.Models;

namespace myfirstmvcapp.StaticData
{
    public class PersonData
    {
        public static List<Person> People 
        {
            get
            {
                return listOfPeople;
            }
        }

        private static List<Person> listOfPeople = new List<Person>()
        {
            new Person() { Id = 1, Name = "Gery", Department = "ATC", Years = 4.9M },
            new Person() { Id = 2, Name = "Rory", Department = "ATC", Years = 15.2M },
            new Person() { Id = 3, Name = "Mike", Department = "ATC", Years = 5.5M },
            new Person() { Id = 4, Name = "R2-D2", Department = "Nedbank", Years = 123.45M },
            new Person() { Id = 5, Name = "BB-8", Department = "Absa", Years = 555.55M },
            new Person() { Id = 6, Name = "C1-10P", Department = "Standard Bank", Years = 99 },
        };

        public static void AddPerson(Person newPerson)
        {
            var ID = listOfPeople[listOfPeople.Count - 1].Id + 1;
            listOfPeople.Add(new Person() {Id = ID, Name = newPerson.Name, Department = newPerson.Department, Years = newPerson.Years});
        }

        public static void DeletePerson(int id)
        {
            var personToRemove = listOfPeople.Single(r => r.Id == id);
            listOfPeople.Remove(personToRemove);
        }
    }
}