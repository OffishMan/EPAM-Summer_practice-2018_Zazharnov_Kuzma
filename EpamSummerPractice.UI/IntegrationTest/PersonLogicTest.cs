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
        private static IPeopleLogic logic;

        [ClassInitialize]
        public static void Init(TestContext context)
        {
            NinjectCommon.Registration();
            logic = NinjectCommon.Kernel.Get<IPeopleLogic>();
        }

        [TestMethod]
        public void TestAdding()
        {  
            int id = logic.Add("Vyacheslav", "Soloviev", new DateTime(1995, 12, 27), 23,
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

            Assert.AreEqual(Person.ToString(logic.ShowById(id)), Person.ToString(person),
                "Adding data about person incorrect");

            logic.Delete(id);
        }

        [TestMethod]
        public void TestUpdating()
        {
            int id = logic.Add("Vyacheslav", "Soloviev", new DateTime(1995, 12, 27), 23,
               "Samara", "Chapaeva", "22/24");

            Person person = logic.ShowById(id);
            person.Name = "Igor";

            logic.Update(id, "Igor", "Soloviev", new DateTime(1995, 12, 27), 23,
                "Samara", "Chapaeva", "22/24");

            Assert.AreEqual(Person.ToString(logic.ShowById(id)), Person.ToString(person),
                "Adding data about person incorrect");

            logic.Delete(id);
        }

        [ExpectedException(typeof(NullReferenceException), "This item must be null")]
        [TestMethod]
        public void TestDeleting()
        {
            int id = logic.Add("Vyacheslav", "Soloviev", new DateTime(1995, 12, 27), 23,
              "Samara", "Chapaeva", "22/24");

            Person person = logic.ShowById(id);

            logic.Delete(id);

            Assert.AreEqual(Person.ToString(logic.ShowById(id)), Person.ToString(person),
                "Adding data about person incorrect");
        }

    }
}
