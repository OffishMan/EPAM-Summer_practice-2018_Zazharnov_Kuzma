using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace EpamSummerPractice.BLL.Interface
{
    public interface IPeopleLogic
    {
        int Add(string name, string surname, DateTime dateOfBirth, 
            int age, string city, string street, string house_number);
        bool Update(int id, string name, string surname, DateTime dateOfBirth,
            int age, string city, string street, string house_number);
        bool Delete(int id);
        Person ShowById(int id);
        IEnumerable<Person> GetAll();

        bool AddReward(int personID, int medalID);
        bool DeleteReward(int personID, int medalID);
        IEnumerable<string> GetAllRewards();
    }
}
