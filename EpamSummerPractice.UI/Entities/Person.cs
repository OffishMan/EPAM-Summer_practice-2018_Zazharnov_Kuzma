using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Age { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string NumberOfHouse { get; set; }
        public List<int> AllMedalsId { get; set; }

        public static string ToString(Person person)
        {
            return $"{person.Name} {person.Surname} {person.Age} {person.DateOfBirth} {person.City} {person.Street} {person.NumberOfHouse}";
        }
    }
}
