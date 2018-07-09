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
        void Add(int PersonID, int MedalID);
        void Delete(int PersonID, int MedalID);
        IEnumerable<Reward> GetAll();
    }
}
