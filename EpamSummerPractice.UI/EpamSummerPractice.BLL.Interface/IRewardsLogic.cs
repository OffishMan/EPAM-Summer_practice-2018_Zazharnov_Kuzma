using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace EpamSummerPractice.BLL.Interface
{
    public interface IRewardsLogic
    {
        void Add(int personID, int medalID);
        void Delete(int personID, int medalID);
        IEnumerable<string> GetAll();
    }
}
