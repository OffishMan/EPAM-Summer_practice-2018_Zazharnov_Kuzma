using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace EpamSummerPractice.BLL.Interface
{
    public interface IMedalsLogic
    {
        void Add(string title, string material);
        void Delete(int id);
        void Update(int id, string title, string material);
        bool UsedInReward(int id);
        IEnumerable<Medal> GetAll();

    }
}
