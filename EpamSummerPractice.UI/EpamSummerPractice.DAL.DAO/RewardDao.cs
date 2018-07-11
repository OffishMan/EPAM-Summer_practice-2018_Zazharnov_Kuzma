using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EpamSummerPractice.DAL.Interface;
using System.Configuration;
using Entities;
using System.Data.SqlClient;
using System.Data;

namespace EpamSummerPractice.DAL.DAO
{
    public class RewardDao : IRewardDao
    {
        public void Add(Reward reward)
        {
            throw new NotImplementedException();
        }

        public void Delete(Reward reward)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Reward> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Reward> GetByMedalId(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Reward> GetByPersonId(int id)
        {
            throw new NotImplementedException();
        }
    }
}
