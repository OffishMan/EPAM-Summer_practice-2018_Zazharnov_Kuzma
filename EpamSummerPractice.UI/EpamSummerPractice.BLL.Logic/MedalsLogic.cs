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
    public class MedalsLogic : IMedalsLogic       
    {
        private readonly IMedalDao _medalDao;
        public MedalsLogic(IMedalDao medalDao)
        {
            _medalDao = medalDao;
        }

        public void Add(string title, string material)
        {
            if (!String.IsNullOrEmpty(title))
            {
                if (!String.IsNullOrEmpty(material))
                {
                    var medal = new Medal
                    {
                        Title = title,
                        Material = material
                    };
                    _medalDao.Add(medal);
                }
                else
                    throw new ArgumentNullException("You can't add medal without material");
            }
            else
                throw new ArgumentNullException("You can't add medal without title");
            
        }

        public bool UsedInReward(int id)
        {
            return _medalDao.UsedInReward(id);
        }

        public void Delete(int id)
        {
            if (!UsedInReward(id))
            {
                _medalDao.Delete(id);
            }
            else
                throw new Exception("Some person was rewarded by this medal. You can't delete this medal.");
        }

        public IEnumerable<Medal> GetAll()
        {
            return _medalDao.GetAll().ToList<Medal>();
        }

        public void Update(int id, string title, string material)
        {
            if (!String.IsNullOrEmpty(title))
            {
                if (!String.IsNullOrEmpty(material))
                {
                    var medal = new Medal
                    {
                        Title = title,
                        Material = material
                    };
                    _medalDao.Update(id, medal);
                }
                else
                    throw new ArgumentNullException("You can't add medal to null material");
            }
            else
                throw new ArgumentNullException("You can't update medal to null title");
        }
    }
}
