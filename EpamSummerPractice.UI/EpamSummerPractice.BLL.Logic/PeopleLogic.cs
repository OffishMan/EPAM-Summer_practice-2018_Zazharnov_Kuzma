using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EpamSummerPractice.BLL.Interface;
using Entities;
using EpamSummerPractice.DAL.Interface;
using System.Text.RegularExpressions;

namespace EpamSummerPractice.BLL.Logic
{
    public class PeopleLogic : IPeopleLogic
    {
        private readonly IPeopleDao _peopleDao;

        public PeopleLogic(IPeopleDao peopleDao)
        {
            _peopleDao = peopleDao;
        }

        public int Add(string name, string surname, DateTime dateOfBirth, int age, string city, string street, string house_number)
        {
            if (String.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("Name can't be null");
            }
            else
                if (String.IsNullOrEmpty(surname))
            {
                throw new ArgumentNullException("Surname", " can't be null");
            }
            else
                if (DateTime.Now < dateOfBirth)
            {
                throw new Exception("Person can't be added to the database before birth");
            }
            else 
                if(Math.Abs(DateTime.Now.Year - dateOfBirth.Year) > age || Math.Abs(DateTime.Now.Year - dateOfBirth.Year) < age - 1) 
            {
                throw new Exception("Date of birth and age mismatch");
            }
            else
                if (String.IsNullOrEmpty(city))
            {
                throw new ArgumentNullException("City", " name can't be null");
            }
            else
                if (Regex.IsMatch(city, @"\d"))
            {
                throw new Exception("Wrong format of city name");
            }
            else
                if (String.IsNullOrEmpty(street))
            {
                throw new ArgumentNullException("Street name can't be null");
            }
            else
                if (String.IsNullOrEmpty(house_number))
            {
                throw new ArgumentNullException("House number name can't be null");
            }
            else
                if (!Regex.IsMatch(house_number, @"\d"))
            {
                throw new Exception("House number must contain digits");
            }
            else
            {
                var person = new Person
                {
                    Name = name,
                    Surname = surname,
                    DateOfBirth = dateOfBirth, 
                    Age = age, 
                    City = city,
                    Street = street,
                    NumberOfHouse = house_number
                };
                return _peopleDao.Add(person);
            }

        }

        public void Delete(int id)
        {
            if (_peopleDao.ShowById(id) != null)
            {
                _peopleDao.Delete(id);
            }
            else
                throw new Exception("Person wasn't created. You can't remove it");
        }

        public IEnumerable<Person> GetAll()
        {
            return _peopleDao.GetAll();
        }

        public Person ShowById(int id)
        {
            return _peopleDao.ShowById(id);
        }

        public void Update(int id, string name, string surname, DateTime dateOfBirth, int age, string city, string street, string house_number)
        {
            if (_peopleDao.ShowById(id) == null)
            {
                throw new Exception("Person wasn't created. You can't update it");
            }
            else
                if (String.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("Name can't be null");
            }
            else
                if (String.IsNullOrEmpty(surname))
            {
                throw new ArgumentNullException("Surname can't be null");
            }
            else
                if (DateTime.Now < dateOfBirth)
            {
                throw new Exception("Person can't be added to the database before birth");
            }
            else
                if (Math.Abs(DateTime.Now.Year - dateOfBirth.Year) > age + 1)
            {
                throw new Exception("Date of birth and age mismatch");
            }
            else
                if (String.IsNullOrEmpty(city))
            {
                throw new ArgumentNullException("City name can't be null");
            }
            else
                if (Regex.IsMatch(city, @"\d"))
            {
                throw new Exception("Wrong format of city name");
            }
            else
                if (String.IsNullOrEmpty(street))
            {
                throw new ArgumentNullException("Street name can't be null");
            }
            else
                if (String.IsNullOrEmpty(house_number))
            {
                throw new ArgumentNullException("House number name can't be null");
            }
            else
                if (!Regex.IsMatch(house_number, @"\d"))
            {
                throw new Exception("House number must contain digits");
            }
            else
            {
                var person = new Person
                {
                    Name = name,
                    Surname = surname,
                    DateOfBirth = dateOfBirth,
                    Age = age,
                    City = city,
                    Street = street,
                    NumberOfHouse = house_number
                };
                _peopleDao.Update(id, person);
            }
        }
        public string ToString(Person person)
        {
            return $"{person.Id}: {person.Name} {person.Surname} {person.Age} {person.DateOfBirth} {person.City} {person.Street} {person.NumberOfHouse}";
        }        
    }
}
