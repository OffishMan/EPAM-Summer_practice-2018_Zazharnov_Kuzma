﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EpamSummerPractice.DAL.Interface;
using EpamSummerPractice.BLL.Interface;
using NinjectContainer;
using Ninject;
using Entities;

namespace IntegrationTest
{
    [TestClass]
    public class RewardLogicTest
    {
        private static IRewardsLogic logic;

        [ClassInitialize]
        public static void Init(TestContext context)
        {
            NinjectCommon.Registration();
            logic = NinjectCommon.Kernel.Get<IRewardsLogic>();
        }

        [ExpectedException(typeof(Exception), "Person and medal with id = 1 is exist. Method Add")]
        [TestMethod]
        public void TestAdding()
        {
            logic.Add(1, 1);
        }

        [ExpectedException(typeof(Exception), "Person and medal with id = 1 is exist. Method Delete")]
        [TestMethod]
        public void TestDeleting()
        {
            logic.Delete(1, 1);
        }
    }
}