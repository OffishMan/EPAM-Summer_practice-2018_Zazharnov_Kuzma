using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Entities;
using EpamSummerPractice.BLL.Logic;
using EpamSummerPractice.DAL.Interface;
using System.Linq;
using System.Collections.Generic;

namespace UnitTests
{
    [TestClass]
    public class RewardsLogicUnitTests
    {
        [TestMethod]
        public void TryGetAll()
        {
            var mock = new Mock<IRewardDao>();
            mock.Setup(item => item.GetAll()).Returns(new List<string>()
            {
                "Ivanov Petr: Gold For Moqing Update",
                "Petrov Ivan: Silver For Moqing Delete",
                "Bad fantasy: Bronze For nothing"
            });

            var logic = new RewardsLogic(mock.Object);
            var list = logic.GetAll().ToList();
            Assert.AreEqual(list.Count, 3);
        }
    }
}
