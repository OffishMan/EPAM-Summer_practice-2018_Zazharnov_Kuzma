using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EpamSummerPractice.DAL.Interface;
using EpamSummerPractice.BLL.Interface;
using NinjectContainer;
using Ninject;
using Entities;

namespace IntegrationTest
{
    [TestClass]
    public class MedalLogicTest
    {
        private static int id;
        private static IMedalsLogic logic;

        [ClassInitialize]
        public static void Init(TestContext context)
        {
            NinjectCommon.Registration();
            logic = NinjectCommon.Kernel.Get<IMedalsLogic>();
        }
            

        [TestMethod]
        public void TestAdding()
        {
            id = logic.Add("For test", "Bronze");

            var medal = new Medal
            {
                Title = "For test",
                Material = "Bronze"
            };

            Assert.AreEqual(logic.ToString(logic.ShowById(id)), logic.ToString(medal),
                "Adding data about person incorrect");
        }

        [TestMethod]
        public void TestUpdating()
        {
            Medal medal = logic.ShowById(id);
            medal.Title = "For update";

            logic.Update(id, "For update", "Bronze");

            Assert.AreEqual(logic.ToString(logic.ShowById(id)), logic.ToString(medal),
                "Adding data about person incorrect");
        }

        [ExpectedException(typeof(NullReferenceException), "This item must be null")]
        [TestMethod]
        public void TestDeleting()
        {
            Medal medal = logic.ShowById(id);

            logic.Delete(id);

            Assert.AreEqual(logic.ToString(logic.ShowById(id)), logic.ToString(medal),
                "Adding data about person incorrect");
        }
    }
}
