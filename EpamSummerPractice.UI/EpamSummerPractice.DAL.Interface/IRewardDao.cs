using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace EpamSummerPractice.DAL.Interface
{
    public interface IRewardDao
    {
        void Add(Reward reward);
        void Delete(Reward reward);
        IEnumerable<Reward> GetAll();
    }
}
