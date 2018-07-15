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
            var medalLogic = NinjectCommon.Kernel.Get<IMedalsLogic>();
            id = medalLogic.Add("For test", "Bronze");
        }

        [TestMethod]
        public void TestAdding()
        {
            //NinjectCommon.Registration();
            var medalLogic = NinjectCommon.Kernel.Get<IMedalsLogic>();


            //id = medalLogic.Add("Vyacheslav", "Soloviev", new DateTime(1995, 12, 27), 23,
            //    "Samara", "Chapaeva", "22/24");

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
            //NinjectCommon.Registration();
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
