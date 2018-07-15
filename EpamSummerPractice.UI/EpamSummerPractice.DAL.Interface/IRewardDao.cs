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
        //Reward GetFirstByPersonId(int id);  //Возвращает первое вхождение
        //Reward GetFirstByMedalId(int id);
        void Delete(Reward reward);
        bool IsPersonCreated(int id);
        bool IsMedalCreated(int id);
        IEnumerable<string> GetAll();
    }
}
