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
        int Add(string title, string material);
        bool Delete(int id);
        bool Update(int id, string title, string material);
        bool UsedInReward(int id);
        Medal ShowById(int id);
        IEnumerable<Medal> GetAll();        
    }
}
