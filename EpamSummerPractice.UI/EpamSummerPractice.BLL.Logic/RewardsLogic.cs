using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EpamSummerPractice.BLL.Interface;
using Entities;
using EpamSummerPractice.DAL.Interface;

namespace EpamSummerPractice.BLL.Logic
{
    public class RewardsLogic : IRewardsLogic
    {
        private readonly IRewardDao _rewardDao;

        public RewardsLogic(IRewardDao rewardDao)
        {
            _rewardDao = rewardDao;
        }
        public void Add(int personID, int medalID)
        {
            if (_rewardDao.IsMedalCreated(medalID) && _rewardDao.IsPersonCreated(personID))
            {
                var reward = new Reward
                {
                    PersonID = personID,
                    MedalID = medalID
                };
                _rewardDao.Add(reward);
            }
            else
                throw new Exception("Medal or person wasn't created");
        }

        public void Delete(int personID, int medalID)
        {
            if (_rewardDao.IsMedalCreated(personID) && _rewardDao.IsPersonCreated(medalID))
            {
                var reward = new Reward
                {
                    PersonID = personID,
                    MedalID = medalID
                };
                _rewardDao.Delete(reward);
            }
            else
                throw new Exception("Medal or person wasn't created");
        }

        public IEnumerable<string> GetAll()
        {
            return _rewardDao.GetAll();
        }
    }
}
