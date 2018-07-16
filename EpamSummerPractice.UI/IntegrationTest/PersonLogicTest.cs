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
    public class PersonLogicTest
    {
        private static int id;
        private static IPeopleLogic logic;

        [ClassInitialize]
        public static void Init(TestContext context)
        {
            NinjectCommon.Registration();
            logic = NinjectCommon.Kernel.Get<IPeopleLogic>();
        }

        [TestMethod]
        [Priority (0)]          //Не работает
        public void TestAdding()
        {  
            id = logic.Add("Vyacheslav", "Soloviev", new DateTime(1995, 12, 27), 23,
                "Samara", "Chapaeva", "22/24");

            var person = new Person
            {
                Name = "Vyacheslav",
                Surname = "Soloviev",
                DateOfBirth = new DateTime(1995, 12, 27),
                Age = 23,
                City = "Samara",
                Street = "Chapaeva",
                NumberOfHouse ="22/24"
            };

            Assert.AreEqual(logic.ToString(logic.ShowById(id)), logic.ToString(person),
                "Adding data about person incorrect");
        }

        [TestMethod]
        [Priority(1)]
        public void TestUpdating()
        {
            Person person = logic.ShowById(id);
            person.Name = "Igor";

            logic.Update(id, "Igor", "Soloviev", new DateTime(1995, 12, 27), 23,
                "Samara", "Chapaeva", "22/24");

            Assert.AreEqual(logic.ToString(logic.ShowById(id)), logic.ToString(person),
                "Adding data about person incorrect");
        }

        [ExpectedException(typeof(NullReferenceException), "This item must be null")]
        [TestMethod]
        [Priority(2)]
        public void TestDeleting()
        {
            Person person = logic.ShowById(id);

            logic.Delete(id);

            Assert.AreEqual(logic.ToString(logic.ShowById(id)), logic.ToString(person),
                "Adding data about person incorrect");
        }

    }
}
