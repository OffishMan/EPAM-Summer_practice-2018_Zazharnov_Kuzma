using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using EpamSummerPractice.DAL.DAO;
using EpamSummerPractice.DAL.Interface;
using EpamSummerPractice.BLL.Logic;
using EpamSummerPractice.BLL.Interface;


namespace NinjectContainer
{
    public static class NinjectCommon
    {
        private static readonly IKernel _kernel = new StandardKernel();

        public static IKernel Kernel => _kernel;

        public static void Registration()
        {
            _kernel.Bind<IMedalDao>().To<MedalDao>();
            _kernel.Bind<IPeopleDao>().To<PeopleDao>();
            //_kernel.Bind<IRewardDao>().To<RewardDao>();

            
            _kernel.Bind<IMedalsLogic>().To<MedalsLogic>();
            _kernel.Bind<IPeopleLogic>().To<PeopleLogic>();
            //_kernel.Bind<IRewardsLogic>().To<RewardsLogic>();
            
        }
    }
}
