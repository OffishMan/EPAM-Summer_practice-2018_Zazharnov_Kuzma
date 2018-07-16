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
        void Update(Person person);
        void Delete(int id);
        Person ShowById(int id);
        IEnumerable<Person> GetAll();

        void AddReward(int idP, int idM);
        void DeleteReward(int idP, int idM);
        bool IsPersonCreated(int id);
        bool IsMedalCreated(int id);
        IEnumerable<string> GetAllRewards();
    }
}
