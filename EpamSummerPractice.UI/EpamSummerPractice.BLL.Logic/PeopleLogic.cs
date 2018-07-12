using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EpamSummerPractice.BLL.Interface;
using Entities;

namespace EpamSummerPractice.BLL.Logic
{
    public class PeopleLogic : IPeopleLogic
    {
        public void Add(string name, string surname, string dateOfBirth, int age, string city, string street, string house_number)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Person> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(int id, string name, string surname, string dateOfBirth, int age, string city, string street, string house_number)
        {
            throw new NotImplementedException();
        }
    }
}
