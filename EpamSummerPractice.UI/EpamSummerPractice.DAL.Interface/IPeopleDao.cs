using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace EpamSummerPractice.DAL.Interface
{
    public interface IPeopleDao
    {
        int Add(Person person);
        void Update(int id, Person person);
        void Delete(int id);
        Person ShowById(int id);
        IEnumerable<Person> GetAll();
    }
}
