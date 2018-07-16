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
        [ClassInitialize]
        public static void Init(TestContext context)
        {
            NinjectCommon.Registration();
        }
            

        [TestMethod]
        public void TestAdding()
        {
            var medalLogic = NinjectCommon.Kernel.Get<IMedalsLogic>();
            id = medalLogic.Add("For test", "Bronze");

            var medal = new Medal
            {
                Title = "For test",
                Material = "Bronze"
            };

            Assert.AreEqual(medalLogic.ToString(medalLogic.ShowById(id)), medalLogic.ToString(medal),
                "Adding data about person incorrect");
        }

        [TestMethod]
        public void TestUpdating()
        {            
            var medalLogic = NinjectCommon.Kernel.Get<IMedalsLogic>();

            Medal medal = medalLogic.ShowById(id);
            medal.Title = "For update";

            medalLogic.Update(id, "For update", "Bronze");

            Assert.AreEqual(medalLogic.ToString(medalLogic.ShowById(id)), medalLogic.ToString(medal),
                "Adding data about person incorrect");
        }

        [ExpectedException(typeof(NullReferenceException), "This item must be null")]
        [TestMethod]
        public void TestDeleting()
        {
            //NinjectCommon.Registration();
            var medalLogic = NinjectCommon.Kernel.Get<IMedalsLogic>();

            Medal medal = medalLogic.ShowById(id);

            medalLogic.Delete(id);

            Assert.AreEqual(medalLogic.ToString(medalLogic.ShowById(id)), medalLogic.ToString(medal),
                "Adding data about person incorrect");
        }
    }
}
