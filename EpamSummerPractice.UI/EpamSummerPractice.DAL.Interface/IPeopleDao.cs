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
        void Add(Person person);
        void Update(int id, Person person);
        int Delete(int id);
        Medal ShowById(int id);
        IEnumerable<Person> GetAll();
    }
}
